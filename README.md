
#  Api em NET/C#

Projeto para teste de conceitos e estudo de caso.


## Instalação

Para  restaurar as dependências
```bash
 dotnet restore
```

Para atualizar o banco
```bash
dotnet ef database update
```

Para  iniciar o serviço
```bash
dotnet run
```



    
## Endpoints

| Verbo  | Endpoint                | Parâmetro | Body          |
|--------|-------------------------|-----------|---------------|
| GET    | /Tarefa/{id}            | id        | N/A           |
| PUT    | /Tarefa/{id}            | id        | Schema Tarefa |
| DELETE | /Tarefa/{id}            | id        | N/A           |
| GET    | /Tarefa/ObterTodos      | N/A       | N/A           |
| GET    | /Tarefa/ObterPorTitulo  | titulo    | N/A           |
| GET    | /Tarefa/ObterPorData    | data      | N/A           |
| GET    | /Tarefa/ObterPorStatus  | status    | N/A           |
| POST   | /Tarefa                 | N/A       | Schema Tarefa |

## Variáveis de Ambiente

Para rodar esse projeto, você vai precisar adicionar as seguintes variáveis de ambiente no seu .env

`API_KEY` 

`ANOTHER_API_KEY`


## Tecnologias

- .NET Framework
- Entity Framework
- Teste


