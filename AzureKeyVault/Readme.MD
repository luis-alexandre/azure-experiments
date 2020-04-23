# Azure Key Vault Integration

## Introdução

Este projeto é um exemplo de como realizar a integração com o Azure Key Vault.

O Azure Key Vault pode ser utilizado como um "cofre" para armazenar informações sensivas na Azure.
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
** Cadastrar uma nova política para o projeto que foi cadastrado no Azure AD.
** Criar um secret para rodar a aplicação de exemplo. 


## Estrutura da aplicação
Para a projeto de Web API foi construído utilizando .NET Core 2.2 e o DDD (Domain Drive Design).
O Projeto está dividido da seguinte forma:

* Guide.ObrasLiterarias.Api: responsável por expor as operações da api.
* Guide.ObrasLiterarias.Domain: contém todos as interfaces e entidades utilizado pelos demais projetos da solução.
* Guide.ObrasLiterarias.Infra: acesso ao banco de dados. Foi utilizado SQLite e Dapper para simular as transações com o banco de dados.
* Guide.ObrasLiterarias.Services: contém as regras de negócios especificadas no teste.
* Guide.ObrasLiterarias.UnitTest: teste unitário para as projetos da solução. Nesse projeto foram construídos os testes unitários focados na regra de negócio.
