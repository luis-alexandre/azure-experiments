# Azure Cosmos DB

## Introdução

Este projeto é um exemplo de como utilizar o Azure Cosmos DB com o .NET Core.
O Azure Cosmos DB é um banco de dados distribuído da Azure.

É possível criar base de dados utilizando as API abaixo:
* Cassandra
* MongoDB
* SQL
* Gremlin
* Etcd
* Tabela

## Requisitos

Para executar o projeto, além de possuir uma conta na Azure, é necessário ter os itens abaixo:

* .NET Core 3.1 para compilar e rodar o projeto.
* Uma conta no *Azure Cosmos DB* na Azure. 

## Como executar o projeto

O projeto é um .NET Core Console Application, e deve ser executado com os argumentos abaixo:

* *e ou endpoint-uri*: endpoint do Azure Cosmos DB.
* *k ou key-cosmodb*: access key para acessar o recurso Cosmos DB.
* *d ou database-name*: nome do banco de dados que será criado no Cosmo DB.
* *c ou collection-name*: nome da coleção de documentos que será criada no banco de dados.

Exemplo:

`-e <ENDPOINT DO AZURE COSMO DB> -k <KEY DO AZURE COSMO DB> -d <NOME DA BASE DE DADOS> -c <NOME DA COLLECTION>`

## Packages utlizados no projeto

Os seguintes packages foram utilizados no projeto:

* *Microsoft.Azure.DocumentDB.Core*: responsável pela criação de banco de dados, collections e documentos no Azure Cosmos DB.
* *CommandLineParser*: responsável por fazer o parse dos argumentos para um objeto.

## Referências

*Build a .NET console app to manage data in Azure Cosmos DB SQL API account* 
[https://docs.microsoft.com/pt-br/azure/cosmos-db/sql-api-get-started](https://docs.microsoft.com/pt-br/azure/cosmos-db/sql-api-get-started)