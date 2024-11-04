
# MyTrendApp API

## Overview
MyTrendApp is a .NET application that provides various endpoints for handling resources like Avaliações, Categorias, Produtos, and more.

### Recent Enhancements
The following enhancements have been made to improve functionality and code structure:

1. **Authentication Integration**: Integrated a simulated external authentication service using RESTful API calls. The `AuthService` is injected as a dependency using `IAuthService`, allowing controllers to securely validate user credentials.
2. **Refactored Code with SOLID and Clean Code Principles**:
   - Implemented `IAvaliacaoService` to adhere to Dependency Inversion Principle (DIP) in SOLID.
   - Controllers and services were refactored to focus on single responsibilities.
3. **Tests Using xUnit**:
   - **Unit Tests**: `AuthServiceTests` verifies the authentication service for valid and invalid credentials.
   - **Integration Tests**: `AvaliacoesControllerTests` validates the secure route in `AvaliacoesController`, ensuring unauthorized, not found, and success cases work as expected.

## Usage of ML.NET
Currently, the project is configured for future expansion with ML.NET, allowing for potential features like recommendation engines and sentiment analysis.

## Running Tests
To run all tests:
```bash
dotnet test MyTrendApp.Tests
```

### API Endpoints (Summary)
- **GET** `/api/avaliacoes/secure/{id}` - Secured route to fetch a specific avaliação after successful authentication.

## Project Structure
- **Controllers**: Handle HTTP requests and responses.
- **Services**: Business logic, including integration with external authentication services.
- **Models**: Data structures representing application entities.


## Funcionalidade de Análise de Sentimento

Este projeto inclui um endpoint de IA para análise de sentimento, implementado com ML.NET.

### Treinamento do Modelo
O modelo é treinado na inicialização do aplicativo e é salvo no diretório `MLModels`. Utilizamos dados de exemplo para treino inicial.

### Endpoint para Análise de Sentimento
- **Endpoint**: `POST /api/sentiment/analyze`
- **Descrição**: Envia uma string de texto para o endpoint para prever se o sentimento é positivo ou negativo.
- **Exemplo de Corpo da Requisição**:
  ```json
  {
    "text": "Este produto é incrível!"
  }
  ```
