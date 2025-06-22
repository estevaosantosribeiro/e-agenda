# Projeto Web E-Agenda

![]( https://i.imgur.com/jnmwLpB.gif )
## Projeto

Desenvolvido durante o curso Fullstack da [Academia do Programador](https://www.academiadoprogramador.net) 2025

## Descrição

Este projeto tem como objetivo desenvolver um sistema de gestão para um ambiente relacionado à gestão de medicamentos, pacientes, fornecedores, funcionários e prescrições médicas. Este sistema é responsável
por registrar, visualizar, editar e excluir dados de fornecedores, pacientes, medicamentos, funcionários, requisições de entrada e saída de medicamentos, além de gerar relatórios relacionados às prescrições médicas.

## Detalhes e Funcionalidades

### Contatos

- Cadastro, visualização, edição e exclusão de contatos.
- Validação de campos obrigatórios:
  - Nome (2–100 caracteres)
  - Email (formato válido)
  - Telefone (formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX)
- Campos opcionais: Cargo e Empresa.
- Não permite contatos com email ou telefone duplicados.

### Compromissos

- Cadastro, visualização, edição e exclusão de compromissos.
- Campos obrigatórios:
  - Assunto (2–100 caracteres)
  - Data de Ocorrência
  - Hora de Início e de Término
  - Tipo de Compromisso (Remoto ou Presencial)
  - Local (caso presencial) ou Link (caso remoto)
- Campo opcional: Contato vinculado.
- Impede agendamentos com conflito de horário.

### Categorias

- Cadastro, visualização, edição e exclusão de categorias.
- Exibição de todas as despesas associadas a uma categoria.
- Campos obrigatórios:
  - Título (2–100 caracteres)
- Impede duplicidade de títulos.

### Despesas

- Cadastro, visualização, edição e exclusão de despesas.
- Campos obrigatórios:
  - Descrição (2–100 caracteres)
  - Valor (em R$)
  - Forma de Pagamento (À Vista, Crédito ou Débito)
  - Uma ou mais Categorias

### Tarefas

- Cadastro, visualização, edição e exclusão de tarefas.
- Visualização de tarefas pendentes, concluídas e agrupadas por prioridade.
- Campos obrigatórios:
  - Título (2–100 caracteres)
  - Prioridade (Baixa, Normal, Alta)
  - Data de Criação e de Conclusão
  - Status de Conclusão
  - Percentual Concluído
- Permite adicionar itens relacionados à tarefa.

## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.

## Como Usar

#### Clone o Repositório
```
https://github.com/alquimia-do-programador/e-agenda
```

#### Navegue até a pasta raiz da solução
```
cd EAgenda
```

#### Restaure as dependências
```
dotnet restore
```

#### Navegue até a pasta do projeto
```
cd EAgenda
```

#### Execute o projeto
```
dotnet run
```
