# Orientações
## Clone
Clonar [repositório](https://github.com/CesarBrito/Test.Backend.git) para maquina local.

## Instalação
Caso não tenha o Dot.Net 3.1 instalado, instalar a partir do seguinte [link](https://dotnet.microsoft.com/download/dotnet/3.1).

## Migrations
Para a criação do banco de dados executar os seguintes passos:
1. Criar um usuário no banco de dados com a seguintes credenciais: 
	1. Usuário: usr_teste_backend, Senha: 2ed7bdb95eeb428f93fc89d5819ade44
	2. O usuário deve ter permissão de leitura, escrita e criação de banco de dados;
2. Após a criação do usuário, executar o seguinte comando para execução do Migrations:
	1. dotnet ef database update --project Test.Backend.Repository
3. Importante o servidor está com o nome: Local, caso o nome seja outro mudar a na connection string dentro do arquivo appsettings.json;

## Build
### Após o clone e a instalação caso necessário.
#### Executar o batch clean seguindo os seguintes passos:
1. Clicar com o botão direito na solution.
2. Batch Build...
3. Na janela que se abrirá clicar em Select All(Selecionar todos).
4. Então clicar em Clear(Limpar).
5. Repetir o processo até o passo 3.
6. Então clicar em Build(Construir).
## Testes
### Após o build completo, seguir para os testes.
1. Clicar no menu Test(Testes).
2. Clicar na aba Windows.
3. Clicar em Test Explorer(Gerenciador de Testes).
4. Na janela que se abrirá, executar os teste com Ctrl+R,A ou clicar na seta de play com a legenda: Run All(Executar todos).

Após essa execução é esperado que todos os testes fiquem com o icone verde de sucesso.

## Executando a aplicação
### Após a execução dos teste, executar a aplicação seguindo os seguintes passos.
#### Caso o projeto "Test.Backend.WebApi" não estiver selecionado, seguir os seguintes passos:
1. Clicar com o botão direito no projeto "Test.Backend.WebApi".
2. Clicar no item: Set as StartUp Project(Definir como Projeto de Inicialização).
#### Após a verificação, seguir os seguites passos:
1. Precionar a teclar F5 ou clicar em Start(Iniciar) no menu superior.
2. Após o navegador abrir com a aplicação,será apresentado swagger da aplicação;
3. Você terá os seguinte metodos: Get (All), Get, Post, Put e Delete, para fazer o crud de um cliente, apelidado de Customer na solução;

# Sobre o projeto
## Arquitetura
Tentei implementar uma aquitetura simples utilizando DDD e TDD, utilizando inversão de dependência e segregação de interface.\
Dividimos nossa aplicação de 3 camadas principais: WebApi, Domain, Repository.
### Application
Tem como finalidade fazer a intermediação entre o usuário e o sistema.
### Repository
Tem como finalidade manter os repositório e o Migrations do projeto.
### Domain	
Essa camada pode ser considerada o core da aplicação, aonde possui todas as classes, interfaces, serviços, extenções.
## Tests
A camada de teste tem como finalidade fazer os teste de dominio, e validar regras de negócios para que o fluxo da aplicação aconteça normalmente, caso exista uma modificação em alguma classe core.

# O que pode melhorar
Não gostei muito de como encontrei a solução tanto para execução do Migration quanto para a string de conexão utilizando um configurationBuilder na classe ConfigurationTestBackendContext.
Foi a solução que encontrei para tanto execução do contexto do entity quando para execução do migration, acredito que tenha espaço para melhorar nesse ponto.



