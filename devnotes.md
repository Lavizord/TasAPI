## Configuração Inicials

- Pontos a fazer:
  1. Limpar lista de TODS em Program.cs e TasContext.cs
  2. Ter os POSTS de criação de entidades funcionais.
  3. Migração das Fixtures iniciais para DB, usando endpoints acima. (Este ponto pode ser feito em paralelo ao 2).
     A. Ter as Scenes importadas.
     B. Ter os SceneEffects Importados.
     C. Ter as Choices importadas.
     D. Ter os Items importados.

### User Authentication

Estive a ver sobre como implementar autenticação, parece-me que a microsoft já tem ferramentas para adicionar isso, ver links abaixo.

1. https://education.launchcode.org/csharp-web-development/chapters/auth/scaffolding.html
2. https://learn.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-7.0&tabs=netcore-cli

Tenho a ideia que podemos usar isto como base para identificar os users, pode ser necessário criar mais tabelas relacionadas com as que são criadas pelas ferramentas do dotnet.

## Ef dotnet Commands.

- dotnet ef database drop

Dá delete á base de dados. Útil na fase inicial, é mais rápido que estar a lidar com o sistema de migração.

- dotnet ef database update

Faz update á base de dados com os models e ligações definidas na API.
Se as tabelas / db não estiver criada é criada, juntamente com as tabelas.
O nome da DB é o que está na Connection string.

## Sql Server Logins (because fuck security) :D

sa - SILcompus504

TasApi - 3818893tas
