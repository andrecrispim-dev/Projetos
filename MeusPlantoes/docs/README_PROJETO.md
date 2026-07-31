# Meus Plantões

## Objetivo

Aplicativo para controlar os plantões mensais da minha esposa, permitindo cadastrar plantões por dia, informar período, horas, valores, pacientes extras e calcular automaticamente o total a receber no mês.

## Tecnologia

- Flutter
- Dart
- Android Studio
- SQLite local
- Git/GitHub

## MVP

A primeira versão do aplicativo terá:

1. Calendário mensal
2. Cadastro de plantão por dia
3. Plantão diurno, tarde ou noturno
4. Quantidade de horas
5. Valor do plantão
6. Quantidade de pacientes extras
7. Valor por paciente extra
8. Cálculo total diário
9. Cálculo total mensal
10. Tela de configuração de valores padrão

## Funcionalidades futuras

- Exportar relatório em PDF
- Backup em nuvem
- Gráficos mensais
- Relatório anual
- Cadastro automático de feriados
- Senha ou biometria
- Publicação na Play Store

## Regras de negócio dos plantões

### Tipos de plantão

| Tipo     | Horário        | Duração |
| -------- | --------------:| -------:|
| Diurno   | 07:00 às 13:00 | 6h      |
| Tarde    | 13:00 às 19:00 | 6h      |
| Noturno  | 19:00 às 07:00 | 12h     |
| Especial | 19:00 às 01:00 | 6h      |

### Valores em dias úteis

| Tipo     | Valor do plantão | Valor por extra |
| -------- | ----------------:| ---------------:|
| Diurno   | R$ 693,00        | R$ 47,47        |
| Tarde    | R$ 693,00        | R$ 47,47        |
| Noturno  | R$ 1.549,00      | R$ 60,00        |
| Especial | R$ 774,50        | R$ 47,47        |

### Valores em finais de semana e feriados

| Tipo     | Valor do plantão | Valor por extra |
| -------- | ----------------:| ---------------:|
| Diurno   | R$ 856,00        | R$ 61,71        |
| Tarde    | R$ 856,00        | R$ 61,71        |
| Noturno  | R$ 1.712,00      | R$ 67,00        |
| Especial | R$ 856,00        | R$ 61,71        |

### Regras adicionais

- Um mesmo dia pode possuir mais de um plantão.
- Diurno e Tarde têm a mesma regra de valor.
- Plantão Noturno começa em um dia e termina no dia seguinte.
- Plantão Especial começa às 19:00 e termina às 01:00 do dia seguinte.
- Sexta-feira à noite conta como valor de final de semana para Noturno e Especial.
- Os valores padrão podem ser editados no futuro.
- Ao cadastrar um plantão, o app deve salvar o valor aplicado naquele momento, para preservar histórico.
- Pacientes extras pertencem ao plantão, não ao dia inteiro.
