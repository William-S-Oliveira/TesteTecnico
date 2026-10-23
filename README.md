# Sistema de Gestão de Tickets

##  Objetivo do Projeto
Este projeto foi desenvolvido como resolução para um teste técnico. O objetivo principal é gerenciar o cadastro de funcionários e o controle de entrega de tickets, aplicando regras de negócio específicas e gerando relatórios gerenciais por período e/ou por funcionário.

##  Tecnologias Utilizadas
*   **Linguagem:** C# (.NET)
*   **Interface:** Windows Forms (WinForms)
*   **Banco de Dados:** SQLite
*   **ORM:** Entity Framework Core (Abordagem Code-First)

##  Arquitetura e Separação de Responsabilidades

Para garantir a manutenibilidade e a testabilidade do código, a aplicação foi estruturada seguindo o princípio de separação de responsabilidades, dividida nas seguintes camadas:

*   **Models:** Contém as entidades de domínio (`Funcionario` e `Ticket`).
*   **Data:** Contém o `TesteTecnicoContext` (DbContext), onde são configurados o mapeamento das entidades, relacionamentos e a conexão com o SQLite via Fluent API.
*   **Services:** O coração da aplicação. Todas as regras de negócio (validações, bloqueios e agrupamentos) estão centralizadas aqui. As telas não sabem como o banco funciona, elas apenas solicitam ações aos serviços.
*   **Views:** As telas do Windows Forms, responsáveis apenas por capturar dados do usuário, chamar os serviços e exibir os resultados (mantendo a UI "burra").

##  Decisões de Projeto e Regras de Negócio

Durante o desenvolvimento, algumas decisões foram tomadas para atender aos requisitos de forma robusta:

1.  **Integridade do CPF:** A unicidade do CPF é garantida em duas camadas. O `FuncionarioService` valida antes de salvar (para dar uma mensagem amigável), e o banco de dados possui um índice `UNIQUE` na coluna CPF, impedindo duplicações a nível de SGBD.
2.  **Bloqueio de Funcionário Inativo:** Um funcionário com situação 'I' não pode receber novos tickets. A validação estrita ocorre no `TicketService`. Além disso, a tela de cadastro de tickets (UX) já carrega o ComboBox apenas com os funcionários ativos.
3.  **Diferencial - DataCriacao vs DataModificacao:** O enunciado exigia o campo `DataModificacao`. No entanto, como o relatório filtra por período, editar um ticket antigo alteraria sua `DataModificacao` e o "moveria" de período no relatório, gerando distorções. Para evitar esse problema, foi adicionada a propriedade imutável `DataCriacao` na entidade `Ticket`, garantindo a precisão histórica do relatório.
4.  **Relacionamento e Exclusão:** O relacionamento 1:N entre Funcionário e Ticket foi configurado com `OnDelete(DeleteBehavior.Restrict)`. Isso garante que inativar (ou tentar excluir) um funcionário não afete o histórico de tickets atrelados a ele.
5.  **Filtro de Datas Preciso:** Para garantir que o dia final do relatório seja incluído por inteiro, o `TicketService` utiliza a lógica `datafim.Value.Date.AddDays(1).AddTicks(-1)`, capturando tickets criados até 23:59:59 do dia selecionado.

##  Funcionalidades Implementadas
*   **Módulo de Funcionários:** Cadastro com máscara de CPF, edição e botão para alternar status (Ativo/Inativo).
*   **Módulo de Tickets:** Lançamento e edição de quantidade de tickets para funcionários ativos.
*   **Módulo de Relatórios:** Consulta com filtros combináveis (Funcionário, Data Inicial e Data Final independentes), agrupamento por funcionário, soma total de registros e de quantidades, e **exportação para CSV**.

##  Script de Criação do Banco de Dados

**Atenção:** O script SQL solicitado encontra-se na raiz deste repositório no arquivo: 
 **[`ScriptCriacaoBanco.sql`](./ScriptCriacaoBanco.sql)** 

O arquivo contém a estrutura completa do banco (CREATE TABLE, chaves primárias, chaves estrangeiras, índices e restrições). Ele foi gerado automaticamente a partir do modelo do Entity Framework Core.

*Nota de execução:* Em tempo de execução, a aplicação utiliza o método `Database.EnsureCreated()` no `Program.cs` para criar o banco SQLite (`TesteTecnico.db`) automaticamente na primeira inicialização. O script `.sql` em anexo serve como documentação explícita do schema e pode ser executado manualmente em ferramentas como o *DB Browser for SQLite*, se desejado.

---
*Desenvolvido por William Oliveira*