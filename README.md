# Clube da Leitura - Sistema de Gerenciamento

Este é um sistema de gerenciamento para um Clube da Leitura, desenvolvido em C# (.NET 8), com interface de console. O sistema permite o controle de amigos, revistas e empréstimos, facilitando a organização e o acompanhamento das atividades do clube.

## Funcionalidades

- **Cadastro de Amigos:** Adicione, edite, visualize e exclua amigos do clube.
- **Cadastro de Revistas:** Gerencie as revistas disponíveis para empréstimo.
- **Empréstimos:** Realize, visualize e devolva empréstimos de revistas para amigos.
- **Controle de Status:** Acompanhe o status dos empréstimos (aberto, atrasado, devolvido).

## Como Usar

1. **Execute o projeto:**  
   Abra o projeto no Visual Studio e pressione `F5` ou utilize o comando `dotnet run` no terminal.

2. **Navegação:**  
   Utilize o menu principal para acessar as telas de Amigos, Revistas ou Empréstimos.  
   Siga as instruções exibidas para cadastrar, editar, visualizar ou excluir registros.

3. **Empréstimos:**  
   - Para registrar um novo empréstimo, selecione a opção correspondente e escolha o amigo e a revista.
   - Para devolver um empréstimo, acesse a tela de empréstimos e selecione a devolução.

## Estrutura do Projeto

- `Compartilhado/`  
  Classes base e utilitários compartilhados.
- `ModuloAmigos/`  
  Telas e repositórios para gerenciamento de amigos.
- `ModuloRevistas/`  
  Telas e repositórios para gerenciamento de revistas.
- `ModuloEmprestimo/`  
  Telas e repositórios para controle de empréstimos.
- `Program.cs`  
  Ponto de entrada do sistema e controle do fluxo principal.

## Requisitos

- .NET 8 SDK
- Visual Studio 2022 ou superior (recomendado)

## Observações

- Todos os dados são mantidos em memória durante a execução.
- O sistema é totalmente operado via console.

---

Desenvolvido para fins didáticos.
