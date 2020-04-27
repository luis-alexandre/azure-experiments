# Azure Blob Storage

## Introdução

Este projeto é um exemplo de como realizar a integração com o .NET Core e o Azure Blob Storage.
O Azure Blob Storage permite armarzenar diversos tipos de aquivos de forma distribuída.

## Requisitos

Para executar o projeto, além de possuir uma conta na Azure, é necessário ter os itens abaixo:

* .NET Core 3.1 para compilar e rodar o projeto.
* Uma conta no *Azure Cosmos DB* na Azure. 

## Como executar o projeto

O projeto é um .NET Core Console Application, e deve ser executado com os argumentos abaixo:

* *c ou connection-string*: connection string do Azure Storage Account.
* *n ou container-name*: nome do container a ser criado no Azure Blob.
* *f ou file*: caminho completo do arquivo a ser manipulado no Azure Blob.

Exemplo:

`-c <CONNECTION STRING> -n <CONTAINER NAME> -f <CAMINHO COMPLETO DO ARQUIVO>`

## Packages utlizados no projeto

Os seguintes packages foram utilizados no projeto:

* *WindowsAzure.Storage*: responsável pela criação e manipulação de arquivos no Azure Blob Storage.
* *CommandLineParser*: responsável por fazer o parse dos argumentos para um objeto.

## Referências

*Azure Storage APIs for .NET* 
[https://docs.microsoft.com/pt-br/dotnet/api/overview/azure/storage?view=azure-dotnet](https://docs.microsoft.com/pt-br/dotnet/api/overview/azure/storage?view=azure-dotnet)