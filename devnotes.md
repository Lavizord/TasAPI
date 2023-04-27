# Configuração Inicials

## Pontos a fazer:

0. Fazer um trello (Implementação dos Models já criados com FrontEnd - Endpoints + integração com frontend)
   0.1. Fazer DockerFile para FrontEnd / API.
   0.2. Fazer script para criação das scenes com DockerFile / Docker Composer
   0.3. Com os pontos atrás fazer um dockercontainer geral.
1. Limpar lista de TODS em Program.cs e TasContext.cs
2. Ter os POSTS de criação de entidades funcionais.
3. Migração das Fixtures iniciais para DB, usando endpoints acima. (Este ponto pode ser feito em paralelo ao 2).
   A. Ter as Scenes importadas.
   B. Ter os SceneEffects Importados.
   C. Ter as Choices importadas.
   D. Ter os Items importados.

# Docker / Deply

Este repositório comtem dois containers.

1. Para a base de dados, deve ser inicializado usando o Docker Compose file na pasta de Database.
2. Para a API, deve ser usado o Docker file + Docker Composer.

Para aceder a shell de um container podemos usar os commandos neste post:
https://stackoverflow.com/questions/30172605/how-do-i-get-into-a-docker-containers-shell

docker exec -it <mycontainer> bash


### Para usar um DockerCompose file deve-se usar o comando:

-> docker-compose up -d

Este comando inicia o nosso container no docker, pronto a funcionar.

## Database Container

## API Container

# User Authentication

Estive a ver sobre como implementar autenticação, parece-me que a microsoft já tem ferramentas para adicionar isso, ver links abaixo.

1. https://education.launchcode.org/csharp-web-development/chapters/auth/scaffolding.html
2. https://learn.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-7.0&tabs=netcore-cli

Tenho a ideia que podemos usar isto como base para identificar os users, pode ser necessário criar mais tabelas relacionadas com as que são criadas pelas ferramentas do dotnet.

# Ef dotnet Commands.

- dotnet ef database drop

Dá delete á base de dados. Útil na fase inicial, é mais rápido que estar a lidar com o sistema de migração.

- dotnet ef database update

Faz update á base de dados com os models e ligações definidas na API.
Se as tabelas / db não estiver criada é criada, juntamente com as tabelas.
O nome da DB é o que está na Connection string.
