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

## Como executar o projeto

O projeto é um .NET Core Console Application, e deve ser executado com os argumentos abaixo:

* *k ou key-vault-address*: endereço do Key Vault criado na Azure.
* *s ou secret-name*: nome do secret a ser recuperado do Key Vault.
* *c ou client-id*: client id do projeto cadastrado no Azure AD.
* *p ou client-secret*:  client secret do cadastrado no Azure AD. 

Exemplo:

`dotnet KeyVaultIntegration.dll -k <URL DO KEY VAUL> -s <SECRET A SER RECUPERADO> -c <CLIENT ID> -p <CLIENT SECRET>`

## Packages utlizados no projeto

Os seguintes packages foram utilizados no projeto:

* *Microsoft.Azure.KeyVault*: responsável por fazer a integração com o Azure Key Vault.
* *Microsoft.IdentityModel.Clients.ActiveDirectory*: responsável por fazer a integração com o Azure AD.
* *CommandLineParser*: responsável por fazer o parse dos argumentos para um objeto.

## Referências

*How to: Use the portal to create an Azure AD application and service principal that can access resources*
[https://docs.microsoft.com/pt-br/azure/active-directory/develop/howto-create-service-principal-portal](https://docs.microsoft.com/pt-br/azure/active-directory/develop/howto-create-service-principal-portal)

*Provide Key Vault authentication with an access control policy*
[https://docs.microsoft.com/en-us/azure/key-vault/general/group-permissions-for-apps](https://docs.microsoft.com/en-us/azure/key-vault/general/group-permissions-for-apps)