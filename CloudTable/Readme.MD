# Azure Table Storage

## Introdução

Este projeto é um exemplo de como realizar a integração com o Azure Table Storage.
O Azure Table Storage pode ser utilizado armazenar informações em forma de colunas na Azure Storage.

## Requisitos

Para executar o projeto, além de possuir uma conta na Azure, é necessário ter os itens abaixo:

* .NET Core 2.2 para compilar e rodar o projeto.
* Uma conta do tipo *Storage Account* na Azure. 

## Como executar o projeto

O projeto é um .NET Core Console Application, e deve ser executado com os argumentos abaixo:

* *c ou connection-string*: string de conexão da *Storage Account* criada na Azure.
* *t ou table*: nome da tabela que será utilizada na *Storage Account*.

Exemplo:

`dotnet CloudTableConsole.dll -c <STRING DE CONEXÃO> -t <NOME DA TABELA>`

## Packages utlizados no projeto

Os seguintes packages foram utilizados no projeto:

* *Microsoft.Azure.Cosmos.Table*: responsável pela manipulação de tabelas na *Storage Account*.
* *CommandLineParser*: responsável por fazer o parse dos argumentos para um objeto.

## Referências

*Get started with Azure Cosmos DB Table API and Azure Table storage using the .NET SDK*
[https://docs.microsoft.com/en-us/azure/cosmos-db/tutorial-develop-table-dotnet](https://docs.microsoft.com/en-us/azure/cosmos-db/tutorial-develop-table-dotnet)