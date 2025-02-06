# Sistema de Gerenciamento de Ótica - API

Este repositório contém a implementação de uma API RESTful desenvolvida em **ASP.NET Core**, utilizando **arquitetura em camadas**, para um sistema de gerenciamento de ótica. A API permite o gerenciamento de clientes, produtos, serviços, atendimentos (vendas) e fluxo de caixa.

## 📁 Estrutura do Projeto

O projeto está estruturado nas seguintes camadas:

- **`API`**: Contém os controllers e define as rotas RESTful da API.
- **`Model`**: Contém os modelos de domínio que representam as entidades do sistema.
- **`Infra`**: Responsável pela comunicação com o banco de dados utilizando **Entity Framework Core**.
- **`Communication`**: Contém os DTOs (Data Transfer Objects) para requests/responses e serviços de mapeamento entre DTOs e modelos.
- **`Application`**: Implementa os **casos de uso (UseCases)** e validações utilizando **FluentValidation**.

## 🚀 Tecnologias Utilizadas

- **ASP.NET Core 8**
- **Entity Framework Core**
- **FluentValidation**
- **MySql**
- **Swagger para documentação**

## 📌 Funcionalidades Implementadas

- **📂 Clientes**: Cadastro, edição, exclusão e consulta de clientes.
- **🛍️ Produtos**: Gestão de produtos como óculos, lentes e acessórios.
- **💳 Serviços**: Registro e gerenciamento de serviços oferecidos.
- **🛒 Atendimentos (Vendas)**: Controle de vendas e atendimentos ao cliente.
- **💰 Fluxo de Caixa**: Monitoramento de entradas e saídas financeiras.

## 📜 Convenções de Código

- Utilização de **padrão RESTful** para os endpoints da API.
- Uso de **DTOs (Data Transfer Objects)** para separação entre as camadas.
- Aplicação de **FluentValidation** para validação de dados.
- Implementação do **Repository Pattern** para abstração da camada de dados.

## 🛠️ Contribuição

1. Faça um **fork** do repositório.
2. Crie uma **branch** para a sua feature (`git checkout -b minha-feature`).
3. Realize os commits das suas alterações (`git commit -m 'Minha nova feature'`).
4. Envie para o repositório remoto (`git push origin minha-feature`).
5. Abra um **Pull Request** para revisão.

## 📄 Licença

Este projeto é distribuído sob a licença [MIT](LICENSE).
