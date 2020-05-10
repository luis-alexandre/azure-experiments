# Azure App Configuration

## Introdução

Este projeto é um exemplo de como utilizar o Azure App Configuration com .NET Core.
O Azure App Configuration permite armazenar e gerenciar as configurações da sua aplicação.

## Requisitos

Para executar o projeto, além de possuir uma conta na Azure, é necessário ter os itens abaixo:

* .NET Core 3.1 para compilar e rodar o projeto.
* Uma conta no *Azure App Configuration* na Azure. 

## Como executar o projeto

O projeto é um .NET Core Console Application, e deve ser executado com os argumentos abaixo:

* *c ou connection-string*: connection string do Azure App Configuration.

Exemplo:

`-c <CONNECTION STRING>

## Packages utlizados no projeto

Os seguintes packages foram utilizados no projeto:

* *Microsoft.Azure.AppConfiguration.AspNetCore*: responsável pela integração do Azure App Configuration com o .NET Core.
* *CommandLineParser*: responsável por fazer o parse dos argumentos para um objeto.

## Referências

*Azure App Configuration documentation* 
[https://docs.microsoft.com/en-us/azure/azure-app-configuration](https://docs.microsoft.com/en-us/azure/azure-app-configuration)