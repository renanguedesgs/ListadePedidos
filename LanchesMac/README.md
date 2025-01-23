Descrição do Projeto
A aplicação foi projetada para gerenciar pedidos feitos por clientes em um site de lanches. Através da API REST, é possível criar, visualizar, atualizar e excluir pedidos, além de filtrar pedidos por nome de cliente e data.

Funcionalidades:
CRUD de Pedidos: Criar, listar, atualizar e excluir pedidos.
Cálculo de Valor Total: O valor total do pedido é calculado automaticamente com base nos itens.
Validação: Validação de dados (não permite quantidades ou preços negativos).

Guia para Acessar e Testar o Projeto
Este projeto é uma aplicação para gerenciar pedidos de clientes em um site de vendas de lanches. Abaixo estão as instruções para que você possa acessar o repositório, rodar a aplicação localmente e testar todas as funcionalidades.

Passo a Passo
1. Instalar o Git (se ainda não estiver instalado)
Para poder clonar o repositório, você precisa ter o Git instalado na sua máquina. Caso não tenha, siga esses passos:

Acesse https://git-scm.com/downloads e baixe o Git para o seu sistema operacional.
Durante a instalação, marque a opção de adicionar o Git ao PATH do sistema, para poder usá-lo diretamente no terminal ou PowerShell.

2. Clonar o Repositório
Depois de instalar o Git, abra o PowerShell (ou o terminal de sua preferência) e execute o seguinte comando para clonar o repositório:

git clone https://github.com/renanguedesgs/ListadePedidos.git
Isso vai criar uma cópia local do repositório na sua máquina.

3. Entrar no Diretório do Projeto
Após clonar o repositório, navegue até a pasta do projeto:
"cd ListadePedidos"

4. dotnet restore
Este comando vai garantir que o .NET baixe todos os pacotes necessários para rodar o projeto.

5. Rodar a Aplicação
Agora, execute a aplicação com o comando: dotnet run

6.Fazer o Login

Login como Administrador:
Permissões: Criar, editar e excluir lanches e categorias, gerar relatórios, adicionar e gerenciar imagens, e realizar outras operações administrativas.
Login: admin@localhost
Senha: Numsey#2022

Login como Cliente:
Permissões: Navegar pelos lanches, escolher um lanche favorito, selecionar a quantidade desejada, adicionar itens ao carrinho e finalizar a compra.
Login: usuario@localhost
Senha: Numsey#2022

7. Testar a API

8. Banco de Dados Configurado
O banco de dados já está configurado e não é necessário realizar nenhuma configuração adicional. Ao rodar a aplicação, já sera possivel testar todas as funcionalidades do projeto sem necessidade de configuração extra.