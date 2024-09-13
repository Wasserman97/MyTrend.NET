# MyTrend API

## Integrantes do Grupo

- **552477 - MARIA EDUARDA SOUSA DE OLIVEIRA**
- **550712 - MATHEUS WASSERMAN FERNANDES SILVA**
- **99396 - GUILHERME ROCHA TOLEDO DOS SANTOS**
- **552522 - ISADORA TATAJUBA MOREIRA PINTO**
- **551496 - GUSTAVO NUNES**

## Descrição do Projeto

O **MyTrend API** é uma aplicação desenvolvida como parte do desafio de **Desenvolvimento Avançado de Negócios com .NET**.
A API é projetada para fornecer recomendações personalizadas de moda, integrando com um banco de dados Oracle para gerenciar dados de usuários e produtos.

### Funcionalidades

- **Recomendações Personalizadas**: Sugestões de roupas e looks baseadas nas preferências e dados dos usuários.
- **Gerenciamento de Dados**: Operações CRUD para usuários, produtos, avaliações, categorias, cores, pedidos e feedbacks.
- **Documentação Interativa**: Utilização do Swagger para visualizar e testar os endpoints da API.

### Arquitetura da API

Optamos por uma **arquitetura monolítica** para este projeto, garantindo simplicidade e eficiência durante o desenvolvimento e manutenção.

#### Vantagens da Arquitetura Monolítica

- **Simplicidade de Implementação**: Menos complexidade na configuração e integração de diferentes serviços.
- **Facilidade de Manutenção**: Toda a lógica está centralizada, facilitando alterações e atualizações.

#### Desvantagens

- **Escalabilidade**: Pode ser mais desafiador escalar conforme o crescimento do projeto.
- **Acoplamento**: Aumentos na base de código podem levar a problemas de manutenção a longo prazo.

### Implementação da Arquitetura

A API é organizada em camadas:

- **Controllers**: Expõem os endpoints da API.
- **Data**: Contém o `ApplicationDbContext` para a comunicação com o banco de dados Oracle.
- **Models**: Define as entidades e seus relacionamentos.
- **Services**: Implementa a lógica de negócios e interage com o banco de dados.

### Endpoints CRUD

A API disponibiliza endpoints para as seguintes operações CRUD:

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

Cada endpoint suporta operações de **criação**, **leitura**, **atualização** e **exclusão**.

### Design Patterns Utilizados

- **Singleton**: Implementado para o gerenciamento de configurações da aplicação, garantindo que uma única instância seja usada.

### Documentação da API

A documentação é gerada automaticamente usando Swagger/OpenAPI. Para acessar:

1. **Inicie a aplicação** com o comando:
   
   dotnet run

   
Acesse a documentação no seu navegador:

Documentação Swagger

Instruções para Rodar a API
Clone o Repositório


git clone https://github.com/Wasserman97/MyTrend.NET.git
Navegue até o Diretório do Projeto


cd MyTrend.NET
Restaurar as Dependências

dotnet restore


Executar a Aplicação

dotnet run


Visualizar a Documentação

Após iniciar a aplicação, abra seu navegador e vá para Documentação Swagger.

Observações
Configuração do Banco de Dados: Certifique-se de que o banco de dados Oracle está configurado corretamente conforme os detalhes em appsettings.json.
Testes: Inclui testes básicos para verificar o funcionamento dos endpoints CRUD. Recomenda-se executar os testes após configurar a aplicação.
Licença
Este projeto está licenciado sob a Licença MIT - veja o arquivo LICENSE para mais detalhes.
