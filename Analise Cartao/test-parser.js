const pdfjsLib = require('pdfjs-dist/legacy/build/pdf.js');
const fs = require('fs');
const { parseTransacoes, moneyToNumber } = require('./parser-core.js');

async function main() {
  const data = new Uint8Array(fs.readFileSync('BradescoCartoes2026-08-03.110215.pdf'));
  const doc = await pdfjsLib.getDocument({ data }).promise;
  const paginas = [];
  for (let p = 2; p <= doc.numPages; p++) {
    const page = await doc.getPage(p);
    const content = await page.getTextContent();
    paginas.push({ items: content.items.map(it => ({ str: it.str, x: it.transform[4] })) });
  }
  const { grupos, preamble } = parseTransacoes(paginas);

  console.log('Preâmbulo (antes do 1o grupo):', JSON.stringify(preamble, null, 1));
  console.log('\n=== GRUPOS ===');
  let grandTotal = 0;
  grupos.forEach(g => {
    const somaItens = g.itens.reduce((s, it) => s + (isNaN(it.v) ? 0 : it.v), 0);
    grandTotal += somaItens;
    console.log(`\n-- ${g.titularRaw} | ${g.cardRaw} | itens=${g.itens.length} | soma=${somaItens.toFixed(2)} | totalDeclarado=${g.totalDeclarado}`);
    const diff = Math.abs(somaItens - g.totalDeclarado);
    if (diff > 0.01) console.log('   !! DIVERGÊNCIA', diff.toFixed(2));
    g.itens.forEach(it => {
      const flag = it.ambiguous ? ' [AMBIGUO]' : (isNaN(it.v) ? ' [VALOR INVALIDO]' : '');
      console.log(`   ${it.d} | ${it.desc} | p=${it.p} | city=${it.city} | v=${it.v}${it.fx ? ' | fx='+it.fx : ''}${flag}`);
    });
  });
  console.log('\nGRAND TOTAL (sem preambulo):', grandTotal.toFixed(2));
}
main().catch(e => { console.error(e); process.exit(1); });
