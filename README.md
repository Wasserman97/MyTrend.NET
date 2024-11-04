

# MyTrend API

## Integrantes do Grupo

- **552477 - MARIA EDUARDA SOUSA DE OLIVEIRA**
- **550712 - MATHEUS WASSERMAN FERNANDES SILVA**
- **99396 - GUILHERME ROCHA TOLEDO DOS SANTOS**
- **552522 - ISADORA TATAJUBA MOREIRA PINTO**
- **551496 - GUSTAVO NUNES**

## Descrição do Projeto

O **MyTrend API** é uma aplicação desenvolvida como parte do desafio de **Desenvolvimento Avançado de Negócios com .NET**. A API fornece recomendações personalizadas de moda e gerenciamento de dados de usuários e produtos, integrando-se a um banco de dados Oracle e utilizando **ML.NET** para funcionalidades de inteligência artificial.

### Funcionalidades

- **Recomendações Personalizadas**: Sugestões de roupas e looks baseadas nas preferências dos usuários.
- **Análise de Sentimento**: Avalia o sentimento de textos de feedback, utilizando ML.NET.
- **Gerenciamento de Dados**: Operações CRUD para usuários, produtos, avaliações, categorias, cores, pedidos e feedbacks.
- **Documentação Interativa**: Swagger para visualização e teste dos endpoints da API.

### Arquitetura da API

Optamos por uma **arquitetura monolítica** para simplificar o desenvolvimento e a manutenção.

#### Vantagens

- **Simplicidade**: Configuração e integração mais fáceis.
- **Manutenção Centralizada**: Toda a lógica está em um único projeto, facilitando alterações.

#### Desvantagens

- **Escalabilidade Limitada**: Menos flexível para escalar partes específicas.
- **Acoplamento**: A base de código pode se tornar difícil de manter à medida que cresce.

### Organização do Projeto

A API é organizada em camadas:

- **Controllers**: Expõem os endpoints da API.
- **Data**: Contém o `ApplicationDbContext` para comunicação com o banco de dados Oracle.
- **Models**: Define as entidades e relacionamentos.
- **Services**: Implementa a lógica de negócios e interage com o banco de dados e a inteligência artificial.

### Aplicação dos Princípios SOLID

O projeto foi desenvolvido com base nos princípios SOLID:

1. **Single Responsibility Principle (SRP)**: Cada classe tem uma única responsabilidade. Os controladores apenas expõem os endpoints e delegam a lógica para os serviços, e cada serviço realiza operações específicas (e.g., `AuthService`, `SentimentPredictionService`).
2. **Open/Closed Principle (OCP)**: As classes foram projetadas para serem estendidas sem a necessidade de modificação. Por exemplo, novos métodos de recomendação podem ser adicionados sem modificar os serviços existentes.
3. **Liskov Substitution Principle (LSP)**: Interfaces e classes de base são substituíveis por suas subclasses ou implementações sem afetar a funcionalidade.
4. **Interface Segregation Principle (ISP)**: Interfaces específicas foram criadas para cada serviço, como `IAuthService` e `IAvaliacaoService`, permitindo injeção de dependência focada em interfaces específicas.
5. **Dependency Inversion Principle (DIP)**: A dependência é injetada através do construtor, como em `AuthService` e `SentimentPredictionService`, permitindo a fácil substituição ou teste das dependências.

### Endpoints CRUD

A API fornece endpoints CRUD para as seguintes entidades:

- **Avaliações**
- **Categorias de Produtos**
- **Cores**
- **Pedidos**
- **Produtos**
- **Usuários**
- **Perfis de Usuário**
- **Recomendações de Looks**
- **Feedbacks dos Usuários**
- **Roupas**

### Funcionalidade de Análise de Sentimento

Este projeto inclui um endpoint de IA para **análise de sentimento**, utilizando ML.NET.

#### Detalhes do Modelo
- **Modelo**: Treinado para prever se o sentimento de um texto é positivo ou negativo.
- **Treinamento**: Realizado automaticamente na inicialização do aplicativo com dados de exemplo.

#### Endpoint para Análise de Sentimento
- **Endpoint**: `POST /api/sentiment/analyze`
- **Descrição**: Recebe uma string de texto e prevê o sentimento associado.
- **Exemplo de Corpo da Requisição**:
  ```json
  {
    "text": "Este produto é incrível!"
  }
  ```

### Testes

O projeto inclui testes utilizando o **xUnit** para garantir a confiabilidade e o correto funcionamento dos endpoints e serviços.

- **Testes Unitários**: Testam métodos isolados para verificar se retornam os resultados esperados.
- **Testes de Integração**: Verificam a interação entre serviços e o banco de dados, garantindo que os dados sejam processados corretamente.
- **Testes de Sistema**: Validam o comportamento do sistema como um todo, incluindo endpoints críticos.

Os testes cobrem funcionalidades essenciais, como autenticação, CRUD de entidades, e análise de sentimento.

### Design Patterns Utilizados

- **Singleton**: Usado para gerenciar configurações da aplicação, garantindo uma única instância de certos serviços.
- **Dependency Injection**: Usado para injetar dependências e facilitar testes e manutenção.

### Documentação da API

A documentação da API é gerada automaticamente usando Swagger/OpenAPI. Para acessar:

1. **Inicie a aplicação**:
 
   dotnet run

   
2. **Acesse a documentação no navegador**:
   [Swagger UI](http://localhost:5000/swagger) (substitua `localhost:5000` pela porta de execução).

### Instruções para Rodar a API

1. **Clone o Repositório**:
  
   git clone https://github.com/Wasserman97/MyTrend.NET.git
 

2. **Navegue até o Diretório do Projeto**:
  
   cd MyTrend.NET
  

3. **Restaurar as Dependências**:

   dotnet restore
  

4. **Executar a Aplicação**:
   
   dotnet run
  

5. **Visualizar a Documentação**:
   Abra o navegador e vá para o Swagger (conforme descrito acima).

### Configuração do Banco de Dados

Certifique-se de que o banco de dados Oracle está configurado corretamente conforme os detalhes no arquivo `appsettings.json`.

### Licença

Este projeto está licenciado sob a Licença MIT - veja o arquivo LICENSE para mais detalhes.


