# 🏗️ Arquitetura do Projeto

Este projeto segue uma arquitetura baseada em camadas e princípios de **Domain-Driven Design (DDD)**, visando a separação de responsabilidades, testabilidade e manutenibilidade. A estrutura respeita os princípios **SOLID** e utiliza **Injeção de Dependência** para gerenciar o acoplamento entre os módulos.

## 📐 Visão Geral da Estrutura

O sistema está dividido em projetos (camadas) com responsabilidades bem definidas. Abaixo, o detalhamento de cada componente conforme ilustrado no diagrama de arquitetura:

### 1. 🟢 API Project (Camada de Apresentação)
* **Responsabilidade:** É o ponto de entrada da aplicação.
* **Função:** Recebe as requisições dos clientes (Desktop, Mobile, Web Site), valida os dados de entrada iniciais e repassa a execução para a camada de *Application*.
* **Interações:** Depende dos projetos *Application*, *Communication* e *Exception*.

### 2. 🟣 Application Project (Camada de Aplicação)
* **Responsabilidade:** Orquestração dos casos de uso.
* **Função:** Atua como a "cola" entre a apresentação e o domínio. Não contém regras de negócio complexas, apenas coordena o fluxo de dados e chama os serviços de domínio ou repositórios.
* **Interações:** Acessa o *Domain Project*, utiliza o *Communication Project* para DTOs e trata erros via *Exception Project*.

### 3. 🟡 Domain Project (Camada de Domínio)
* **Responsabilidade:** O coração do negócio.
* **Função:** Contém as Entidades, Interfaces (contratos), Value Objects e as regras de negócio puras. Esta camada deve ser agnóstica a tecnologias externas (como banco de dados ou frameworks de UI).
* **Interações:** É referenciada pela *Application* e implementada pela *Infrastructure*.

### 4. ⚫ Infrastructure Project (Camada de Infraestrutura)
* **Responsabilidade:** Implementação técnica e acesso a dados.
* **Função:** Implementa as interfaces definidas no *Domain* (ex: Repositórios, acesso a banco de dados, integrações com serviços externos).
* **Interações:** Depende do *Domain Project* para saber o que deve implementar (Inversão de Dependência).

### 5. 🔵 Communication Project (Camada de Comunicação/Cross-Cutting)
* **Responsabilidade:** Padronização de mensagens.
* **Função:** Provavelmente contém DTOs (Data Transfer Objects), ViewModels e contratos de resposta (Requests/Responses) que são compartilhados entre a API e a Aplicação para evitar expor as entidades de domínio diretamente.

### 6. 🔴 Exception Project (Tratamento de Erros)
* **Responsabilidade:** Gestão centralizada de exceções.
* **Função:** Define exceções personalizadas e estruturas de erro para garantir que a aplicação trate falhas de forma consistente e padronizada em todas as camadas.

---

## 🚀 Princípios e Tecnologias
* **DDD (Domain-Driven Design):** Foco no núcleo e lógica do negócio.
* **SOLID:** Princípios para design de software orientado a objetos.
* **Injeção de Dependência:** Para desacoplar as camadas (ex: a API não instancia a Application diretamente, ela recebe a instância via injeção).