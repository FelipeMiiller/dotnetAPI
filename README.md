
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
| POST   | /api/task               | N/A       | Schema Task   |
| PATCH  | /api/task/{id}          | id        | Schema Task   |
| GET    | /api/task/{id}          | id        | N/A           |
| DELETE | /api/task/{id}          | id        | N/A           |
| GET    | /api/tasks/allByUser    | N/A       | userId        |
| GET    | /api/task/allByTitle    | N/A       | userId, title |
| GET    | /api/task/allByStatus   | N/A       | status, userId|
| GET    | /api/task/allByDate     | N/A       | date, userId  |
| POST   | /api/user               | N/A       | Schema User   |
| PATCH  | /api/user               | N/A       | Schema User   |
| DELETE | /api/user               | N/A       | date, userId  |
| GET    | /api/user/{id}          | id        | N/A           |
| GET    | /api/user/all           | N/A       | N/A           |


## Variáveis de Ambiente

Para rodar esse projeto, você vai precisar adicionar as seguintes variáveis de ambiente no seu .env

`` 


## Tecnologias

- .NET Framework
- Entity Framework
- Teste


