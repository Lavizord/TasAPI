# Configuração Inicials

## Pontos a fazer:

Ver isto e implementar DTOS:
https://learn.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-5

0. Fazer um trello (Implementação dos Models já criados com FrontEnd - Endpoints + integração com frontend)
   0.1. ~~Fazer DockerFile para FrontEnd / API.~~  
   0.2. ~~Fazer script para criação das scenes com DockerFile / Docker Composer~~
   0.3. Com os pontos atrás fazer um dockercontainer geral.
   0.4. Fazer docker geral a puxar de repos master do github.
1. Limpar lista de TODS em Program.cs e TasContext.cs
2. ~~Ter os POSTS de criação de entidades funcionais.~~
3. Migração das Fixtures iniciais para DB, usando endpoints acima. (Este ponto pode ser feito em paralelo ao 2).
   A. ~~Ter as Scenes importadas.~~
   B. ~~Ter os SceneEffects Importados.~~
   C. ~~Ter as Choices importadas.~~
   E. ~~Ter os Items importados.~~
4. Imlementar items
   A. ~~Entities, Items, Types, ItemTypes. C/ fluent API~~
   B. ~~Implementar DTO de Items.~~
   C. ~~Implementar auto mapper de Items.~~
   NOTA: Está a funcionar nos endpoints das scenes, não sei se requer mais código para o outro endpoint.

   D. Testar fazer get de Item por ID
   E. ~~Implementar SceneItem, com fluent API.~~
   F. ~~Implementar DTO de SceneItem~~.
   G. ~~Implementar AutoMapper de SceneItem.~~
   H. ~~Implementar o SceneItem a ser retornado em conjunto com o Scene.~~
   I. Reavaliar endpoints atuais. Adaptar / apagar.
   J. Simplificar os types retornados (TypeDTO? Vai ter que ser para os Items e para as Scenes, bem como os outros types que possamos ter.), não é necessário retornar o id, deveria de seruma lista de strings simples.
   L. Criar Endpoints para Items.
   M. Criar group endpoints para Items

5. Passar type da scene para a tabela de types e fazer tabela relacional.

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

# Ef dotnet Information.

Julgo haver uns problemas quando estamos a trabalhar com EF e docker, parece que ao fazer deploy é um pouco 'manhoso' de automatizar as migrações.
Independentemente, segue uma lista de commandos para ajudar no processo de dev.

#### Commands

- dotnet ef database drop

Dá delete á base de dados. Útil na fase inicial, é mais rápido que estar a lidar com o sistema de migração.

- dotnet ef database update

Faz update á base de dados com os models e ligações definidas na API.
Se as tabelas / db não estiver criada é criada, juntamente com as tabelas.
O nome da DB é o que está na Connection string.

- dotnet ef migration add <name>

Adiciona uma nova migração, isto significa que vai construir os scripts para criar tabelas, julgo que também prepara as coisas para manter os dados de uma DB para a outra.

- dotnet ef migrations script --idempotent --output "script.sql"

Este commando gera os scripts para criação da base de dados.
Como o sistema de migração é um pouco estranho com docker, podemos executar os scripts após a criação do container. Assim a DB é criada logo após a criação dos containers, já com dados lá dentro (TESTAR MELHOR.)
