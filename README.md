   Projeto Clientes – Clean Architecture (.NET 9)

Este projeto foi desenvolvido como parte de um desafio técnico com o objetivo de demonstrar boas práticas de arquitetura, modelagem de domínio e organização de código utilizando .NET 9 e Clean Architecture.

A aplicação expõe uma API REST para criação e consulta de clientes, seguindo o padrão CQRS e princípios SOLID.

   Funcionalidades

✅ Criar um cliente

✅ Consultar cliente por ID

✅ Validação de CNPJ como Value Object

✅ Repositório em memória

✅ Swagger configurado como página inicial

✅ Testes unitários com xUnit

  O projeto segue os princípios da Clean Architecture, separando claramente responsabilidades:


  Decisões de Design
        
✔ Clean Architecture

O Domínio não depende de nenhuma outra camada.

A Application orquestra os casos de uso.

A Infrastructure implementa detalhes técnicos.

A API apenas expõe os endpoints.

✔ CQRS

Separação clara entre Commands (escrita) e Queries (leitura).

✔ Value Object (CNPJ)

Garante integridade e validação do dado.

Evita regras espalhadas pela aplicação.

✔ Result Pattern

Evita uso excessivo de exceções.

Facilita o tratamento de erros na API.
