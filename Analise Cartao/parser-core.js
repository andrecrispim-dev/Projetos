// Núcleo de parsing da fatura Bradesco. Roda tanto no navegador (pdf.js) quanto no Node (para testes).
// Recebe: paginas = array de { items: [{str,x,y}] } na ordem natural de extração do pdf.js, uma entrada por página.
//
// Layout de colunas descoberto inspecionando as coordenadas reais do PDF (fatura Bradesco Visa Infinite):
//   x ~45      Data (DD/MM)
//   x ~66      Início da Descrição
//   x 95-145   Coluna secundária: parcela (NN/NN) e/ou continuação da descrição (quebra de linha)
//   x 145-265  Cidade (inclui continuações de cidade quebrada, ex: "CAMPINA" + "GRAND")
//   x 265-300  Sub-colunas de moeda estrangeira (US$ repetido, cotação)
//   x >=300    Valor final em R$

function moneyToNumber(s) {
  return parseFloat(s.replace(/\./g, '').replace(',', '.'));
}
function isMoneyTok(tok) {
  return /^[\d.]*\d,\d{2}\s?-?$/.test((tok || '').trim());
}
function isDateTok(tok) {
  return /^\d{2}\/\d{2}$/.test((tok || '').trim());
}
function isCurrencyCode(tok) {
  return /^[A-Z]{3}$/.test((tok || '').trim());
}
function isCardHeaderName(tok) {
  return /^[A-ZÀ-Ü][A-ZÀ-Ü .]{4,60}$/.test((tok || '').trim());
}
function isMaskedCard(tok) {
  return /^\d{4} XXXX XXXX \d{4}$/.test((tok || '').trim());
}

function splitDescParcela(raw) {
  const m = /(\d{2})\/(\d{2})$/.exec(raw);
  if (m) {
    const before = raw.slice(0, m.index);
    const charBefore = before.slice(-1);
    if (before.trim() !== '' && !/\d/.test(charBefore)) {
      return { desc: before.trim(), parcela: m[1] + '/' + m[2], ambiguous: false };
    }
  }
  return { desc: raw.trim(), parcela: null, ambiguous: /\d{2}\/\d{2}$/.test(raw) };
}

function parseTransacoes(paginasItens) {
  const toks = [];
  paginasItens.forEach(page => {
    page.items.forEach(it => {
      if (it.x < 360 && it.str && it.str.trim() !== '') toks.push({ s: it.str.trim(), x: it.x });
    });
  });

  const grupos = [];
  const preamble = [];
  let cur = null;
  let i = 0;

  function pushItem(item) {
    if (cur) cur.itens.push(item);
    else preamble.push(item);
  }

  while (i < toks.length) {
    const tok = toks[i].s;

    // cabeçalho de novo grupo (titular + cartão)
    if (isCardHeaderName(tok) && (toks[i + 1] || {}).s === 'Cartão' && isMaskedCard((toks[i + 2] || {}).s)) {
      cur = { titularRaw: tok, cardRaw: toks[i + 2].s, itens: [], totalDeclarado: null };
      grupos.push(cur);
      i += 3;
      continue;
    }

    // fim de grupo: "Total para <nome...>" [continuação nome] <valor>
    if (tok.startsWith('Total para')) {
      let j = i + 1;
      let valor = null;
      if (isMoneyTok((toks[j] || {}).s)) {
        valor = moneyToNumber(toks[j].s);
        j += 1;
      } else {
        j += 1; // continuação do nome (ex: "D")
        if (isMoneyTok((toks[j] || {}).s)) {
          valor = moneyToNumber(toks[j].s);
          j += 1;
        }
      }
      if (cur) cur.totalDeclarado = valor;
      i = j;
      continue;
    }

    // parcela isolada (quebra de linha), ex: "04/12" sozinho logo antes de "Total para..." ou de um novo cabeçalho
    if (isDateTok(tok)) {
      const nextS = (toks[i + 1] || {}).s || '';
      const looksLikeBoundary = nextS.startsWith('Total para') ||
        (isCardHeaderName(nextS) && (toks[i + 2] || {}).s === 'Cartão');
      const lastItem = cur ? cur.itens[cur.itens.length - 1] : preamble[preamble.length - 1];
      if (looksLikeBoundary && lastItem && !lastItem.p) {
        lastItem.p = tok;
        i += 1;
        continue;
      }
    }

    // linha de transação (data no início + próximo token com letras = descrição)
    if (isDateTok(tok) && (toks[i + 1] || {}).s && /[A-Za-zÀ-ÿ]/.test(toks[i + 1].s)) {
      const data = tok;
      let k = i + 1;

      // 1) descrição + coluna secundária (parcela/continuação), x < 145
      const descParts = [];
      while (toks[k] && toks[k].x < 145) {
        descParts.push(toks[k].s);
        k++;
      }
      const combinedDesc = descParts.join(' ');
      const split = splitDescParcela(combinedDesc);
      let desc = split.desc, parcela = split.parcela, ambiguous = split.ambiguous;

      // 2) coluna de cidade / moeda estrangeira, 145 <= x < 265
      let city = '';
      let fx = null;
      if (toks[k] && toks[k].x >= 145 && toks[k].x < 265 && isCurrencyCode(toks[k].s)) {
        // linha em moeda estrangeira: CODE, "valor cidade", valorRepetido, cotação, valorFinal
        const code = toks[k].s; k++;
        const amtCity = (toks[k] || {}).s || ''; k++;
        const mAmt = /^([\d.,]+)\s+(.+)$/.exec(amtCity);
        const fxAmount = mAmt ? mAmt[1] : '';
        city = mAmt ? mAmt[2] : amtCity;
        if (isMoneyTok((toks[k] || {}).s)) k++; // valor US$ repetido
        let cotacao = '';
        if (toks[k] && /^[\d.,]+$/.test(toks[k].s)) { cotacao = toks[k].s; k++; }
        fx = `${code} ${fxAmount} · câmbio ${cotacao}`;
      } else {
        while (toks[k] && toks[k].x >= 145 && toks[k].x < 265) {
          city = (city + ' ' + toks[k].s).trim();
          k++;
        }
      }

      // 3) valor final, x >= 265 (pula eventuais sub-colunas de câmbio remanescentes)
      while (toks[k] && toks[k].x < 300 && !isMoneyTok(toks[k].s)) k++;
      const valorTok = (toks[k] || {}).s || '';
      const isCredito = valorTok.includes('-');
      const valor = isMoneyTok(valorTok) ? moneyToNumber(valorTok) : NaN;
      if (toks[k]) k++;

      if (!isCredito) {
        pushItem({ d: data, desc, city, v: valor, p: parcela, fx, ambiguous, raw: combinedDesc });
      }
      i = k;
      continue;
    }

    i++;
  }

  return { grupos, preamble };
}

module.exports = { parseTransacoes, moneyToNumber, isMoneyTok, isDateTok };
