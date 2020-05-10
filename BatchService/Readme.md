# Azure Batch Service

## Introdução

Este projeto é um exemplo de como executar os jobs criados no Azure Batch Service.
O Azure Batch Service permite executar tarefas batch que exigem muito processamento.

## Requisitos

Para executar o projeto, além de possuir uma conta na Azure, é necessário ter os itens abaixo:

* .NET Core 3.1 para compilar e rodar o projeto.
* Uma conta no *Batch Service* da Azure. 

## Como executar o projeto

Dentro do Azure Batch Service, registre a aplicação MathApplication para que ela seja executada após a criação das tasks.
O projeto AzureBatchService é um .NET Core Console Application, e deve ser executado com os argumentos abaixo:

* *c ou account-name*: conta do Azure Batch Service.
* *k ou account-key*: key conta do Azure Batch Service.
* *u ou account-url*: url do Azure Batch Service criado na Azure.

Exemplo:

`-c <ACCOUNT NAME> -k <KEY BATCH SERVICE ACCOUNT> -u <URL BATCH SERVICE ACCOUNT>`

## Packages utlizados no projeto

Os seguintes packages foram utilizados no projeto:

* *Microsoft.Azure.Batch*: responsável pela integração do Azure Batch Service com o .NET Core.
* *CommandLineParser*: responsável por fazer o parse dos argumentos para um objeto.

## Referências

*Quickstart: Run your first Batch job in the Azure portal* 
[https://docs.microsoft.com/en-us/azure/batch/quick-create-portal](https://docs.microsoft.com/en-us/azure/batch/quick-create-portal)
*Using Azure Batch to Orchestrate and Execute Code at Large-Scale* 
[https://kiltandcode.com/using-azure-batch-to-orchestrate-and-execute-code-at-large-scale](https://kiltandcode.com/using-azure-batch-to-orchestrate-and-execute-code-at-large-scale)
