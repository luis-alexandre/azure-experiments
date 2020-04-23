# Azure Key Vault Integration

## Introdução

Este projeto é um exemplo de como realizar a integração com o Azure Key Vault.

O Azure Key Vault pode ser utilizado como um "cofre" para armazenar informações sensíveis na Azure.
Através dele é possível armazenar:

* Senhas
* Strings de conexão com o banco de dados
* Certificados
* Chaves de Criptografia
* etc

## Requisitos

Para executar o projeto, além de possuir uma conta na Azure, é necessário ter os itens abaixo:

* .NET Core 2.2 para compilar e rodar o projeto.
* Cadastrar o projeto no Azure AD e obter o client id e client secret dessa aplicação.
* Dentro do Azure Key Vault:
    * Cadastre uma nova política para o projeto que foi cadastrado no Azure AD.
    * Cadastre um novo secret para rodar a aplicação de exemplo. 

## Estrutura do Projeto

O projeto é um .NET Core Console Application. Após a sua publicação, execute ele com os argumento abaixo:

`dotnet KeyVaultIntegration.dll -k <URL DO KEY VAUL> -s <SECRET A SER RECUPERADO> -c <CLIENT ID> -p <CLIENT SECRET>`
