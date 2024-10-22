# Teste Prático Ambev

Escrever uma API (CRUD completo) que manipule os registros de vendas. A API precisa ser capaz de informar:
- Número da venda
- Data em que a venda foi efetuada
- Cliente
- Valor total da venda
- Filial em que a venda foi efetuada
- Produtos
- Quantidades
- Valores unitário
- Descontos
- Valor total de cada item
- Cancelado/Não Cancelado

### Diferencial
Não será obrigatório, mas seria um diferencial a construção de um código para publicação de eventos de:
- `CompraCriada`
- `CompraAlterada`
- `CompraCancelada`
- `ItemCancelado`

Se fizer o código, é dispensável publicar em algum Message Broker (Rabbit ou Service Bus, por exemplo) de fato. Pode logar uma mensagem no log da aplicação ou como você achar mais conveniente.

### Projetos a serem executados
- `Ambev.API` - Manipula os registros de vendas
- `Ambev.ConsumerQueue` - Lê as filas `CompraCriada`, `CompraAlterada`, `CompraCancelada`, `ItemCancelado`

### JSON de requisição inicial para criar uma venda:
```json
{
  "ClienteId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "Filial": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "Itens": [
    {
      "ProdutoId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "Quantidade": 1,
      "ValorUnitario": 200,
      "Desconto": 12
    },
    {
      "ProdutoId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
      "Quantidade": 100,
      "ValorUnitario": 200,
      "Desconto": 12
    },
    {
      "ProdutoId": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
      "Quantidade": 1,
      "ValorUnitario": 200,
      "Desconto": 12
    }
  ]
}

### Observações
Executando o endpoint /getAll, é possível obter elementos para utilização nos outros endpoints, como:

- Id da Venda
- Id do Item
- JSON para atualização