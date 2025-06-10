# Clube da Leitura - Sistema de Gerenciamento

Este � um sistema de gerenciamento para um Clube da Leitura, desenvolvido em C# (.NET 8), com interface de console. O sistema permite o controle de amigos, revistas e empr�stimos, facilitando a organiza��o e o acompanhamento das atividades do clube.

## Funcionalidades

- **Cadastro de Amigos:** Adicione, edite, visualize e exclua amigos do clube.
- **Cadastro de Revistas:** Gerencie as revistas dispon�veis para empr�stimo.
- **Empr�stimos:** Realize, visualize e devolva empr�stimos de revistas para amigos.
- **Controle de Status:** Acompanhe o status dos empr�stimos (aberto, atrasado, devolvido).

## Como Usar

1. **Execute o projeto:**  
   Abra o projeto no Visual Studio e pressione `F5` ou utilize o comando `dotnet run` no terminal.

2. **Navega��o:**  
   Utilize o menu principal para acessar as telas de Amigos, Revistas ou Empr�stimos.  
   Siga as instru��es exibidas para cadastrar, editar, visualizar ou excluir registros.

3. **Empr�stimos:**  
   - Para registrar um novo empr�stimo, selecione a op��o correspondente e escolha o amigo e a revista.
   - Para devolver um empr�stimo, acesse a tela de empr�stimos e selecione a devolu��o.

## Estrutura do Projeto

- `Compartilhado/`  
  Classes base e utilit�rios compartilhados.
- `ModuloAmigos/`  
  Telas e reposit�rios para gerenciamento de amigos.
- `ModuloRevistas/`  
  Telas e reposit�rios para gerenciamento de revistas.
- `ModuloEmprestimo/`  
  Telas e reposit�rios para controle de empr�stimos.
- `Program.cs`  
  Ponto de entrada do sistema e controle do fluxo principal.

## Requisitos

- .NET 8 SDK
- Visual Studio 2022 ou superior (recomendado)

## Observa��es

- Todos os dados s�o mantidos em mem�ria durante a execu��o.
- O sistema � totalmente operado via console.

---

Desenvolvido para fins did�ticos.