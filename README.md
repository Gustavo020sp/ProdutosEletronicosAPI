*API de Produtos Eletrônicos

  

Descrição

Esta é uma API desenvolvida em .NET 8 para gerenciar produtos eletrônicos. A API oferece um CRUD completo (Create, Read, Update e Delete) e outras funcionalidades adicionais, como a alteração da quantidade de itens em estoque utilizando o método HttpPatch.

O projeto segue os princípios da Clean Architecture, com as pastas organizadas e nomeadas de acordo com suas responsabilidades.

Funcionalidades

CRUD de Produtos:

Cadastro de novos produtos.

Consulta de produtos.

Atualização completa de produtos.

Exclusão de produtos.

Gestão de Estoque:

Atualização da quantidade de itens no estoque usando o método HttpPatch.

Organização com DTOs:

Utiliza objetos de transferência de dados (DTOs) para gerenciar a quantidade de estoque separadamente da entidade principal.

Estrutura do Projeto

A organização segue o padrão da Clean Architecture, com separação clara de responsabilidades:

Entidades: Contém as definições principais dos objetos do domínio, como Produto.

DTOs: Gerencia dados específicos para atualização parcial, como o estoque de produtos.

Serviços: Contém a lógica de negócio para manipulação dos produtos.

Controllers: Implementação dos endpoints da API.

Tecnologias Utilizadas

Linguagem: C#

Framework: .NET 8

Arquitetura: Clean Architecture

Banco de Dados: SQL Server (ou substituível conforme necessidade)

Documentação: Swagger

Como Executar o Projeto

Clone o repositório:

git clone https://github.com/seu-usuario/api-produtos-eletronicos.git

Navegue até a pasta do projeto:

cd api-produtos-eletronicos

Restaure as dependências:

dotnet restore

Atualize o banco de dados:
Certifique-se de que a string de conexão está correta no arquivo appsettings.json e execute os comandos:

dotnet ef database update

Execute a aplicação:

dotnet run

Acesse a documentação:

Abra seu navegador e acesse: http://localhost:5000/swagger

Exemplos de Uso

Atualizar Estoque de um Produto

Endpoint: PATCH /api/produtos/{id}

Exemplo de corpo da requisição:

{
  "quantidade": 50
}

Cadastrar um Novo Produto

Endpoint: POST /api/produtos

Exemplo de corpo da requisição:

{
  "nome": "Mouse Gamer",
  "quantidade": 100,
  "valorUnitario": 99.99
}

Contribuições

Contribuições são bem-vindas! Siga os passos abaixo para contribuir:

Fork o repositório.

Crie um branch para sua feature: git checkout -b minha-feature.

Commit suas alterações: git commit -m 'Adicionando uma nova feature'.

Envie para o branch principal: git push origin minha-feature.

Abra um Pull Request.

Licença

Este projeto está licenciado sob a licença MIT. Consulte o arquivo LICENSE para mais detalhes.

Autor: Seu NomeContato: LinkedIn | GitHub

