## Configuração Inicials

- Pontos a fazer:
  1. Limpar lista de TODS em Program.cs e TasContext.cs
  2. Ter os POSTS de criação de entidades funcionais.
  3. Migração das Fixtures iniciais para DB, usando endpoints acima. (Este ponto pode ser feito em paralelo ao 2).
     A. Ter as Scenes importadas.
     B. Ter os SceneEffects Importados.
     C. Ter as Choices importadas.
     D. Ter os Items importados.

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
