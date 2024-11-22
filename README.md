# EnerGenius

EnerGenius é uma aplicação desenvolvida em .NET com integração a MongoDB, projetada para oferecer um acompanhamento detalhado e personalizado do consumo de energia. O sistema ajuda usuários e empresas a monitorar o consumo em tempo real, identificar desperdícios, otimizar a eficiência energética e integrar recomendações baseadas em inteligência artificial para redução de custos e impacto ambiental.

## Alunos: 

- Felipe Torlai RM 550263
- Felipe Pinheiro RM 550244
- Gabriel Girami RM 98017
- Gustavo Vinhola RM 98826
- Jean Carlos RM 550430

## Introdução

EnerGenius é um sistema projetado para monitorar o consumo de energia de forma eficiente e flexível. Utilizando MongoDB e .NET, ele oferece:

- Monitoramento em Tempo Real: Acompanhamento contínuo do consumo de energia.
- Identificação de Desperdícios: Relatórios detalhados para encontrar ineficiências.
- Otimização com IA: Recomendações personalizadas baseadas em inteligência artificial generativa.
- Arquitetura Escalável: Ideal para sistemas que precisam crescer rapidamente sem perda de desempenho.
Este projeto é uma solução robusta para empresas e indivíduos que buscam reduzir custos e melhorar a sustentabilidade no consumo de energia.

## Índice

- Tecnologias Utilizadas
- Estrutura do Projeto
- Instalação e Configuração
- Endpoints
- Testes
- Contribuições
- Licença

## Tecnologias Utilizadas

- C# / .NET 8: Framework principal para desenvolvimento da aplicação.
- MongoDB: Banco de dados NoSQL para persistência de dados.
- Swagger: Documentação e teste da API.
- XUnit: Framework de testes unitários.
- FluentValidation: Validação de dados de entrada.
- Docker: Para deploy local do MongoDB em containers.
- ML.NET: Para recursos de inteligência artificial generativa e preditiva.

## Estrutura do Projeto

O projeto segue uma estrutura modular para facilitar a escalabilidade e a manutenção:

- Models: Entidades que representam os objetos principais do sistema, como Caixa e ContaConsumo.
- HttpObjects: Objetos usados para requisições e respostas da API.
- Controllers: Ponto de entrada para os endpoints RESTful.
- Repositories: Camada de acesso aos dados no MongoDB.
- Services: Lógica de negócios, incluindo o uso de IA generativa.
- Tests: Testes unitários e de integração para validação do sistema.

## Instalação e Configuração


Pré-requisitos
- .NET 8 SDK
- MongoDB (local ou em container Docker)
- Docker (opcional, para rodar o MongoDB)

Configure o MongoDB:
- Se estiver usando Docker: docker run -d -p 27017:27017 --name mongodb mongo

Conexão em appsettings.json:
{
  "MongoDbSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "EnerGeniusDB"
  }
}

## Endpoints

Abaixo estão os principais endpoints fornecidos pela API.

### Caixa
Criar Caixa
POST /api/Caixa

Body:
{
  "nome": "Caixa Principal",
  "usuarioId": 1,
  "saldo": 500.00
}

### Consultar Caixa por ID
GET /api/Caixa/{id}

### Atualizar Caixa
PUT /api/Caixa/{id}

Body:
{
  "id": "123",
  "nome": "Caixa Atualizado",
  "usuarioId": 1,
  "saldo": 1000.00,
  "ativo": true
}

### Excluir Caixa
DELETE /api/Caixa/{id}

## Testes

O projeto inclui testes unitários para garantir o funcionamento correto da lógica de negócios e dos controladores.

## Licença

Este projeto é licenciado sob a licença MIT. Veja o arquivo LICENSE para mais informações.
