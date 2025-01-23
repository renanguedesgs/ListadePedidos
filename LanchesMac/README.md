Descri��o do Projeto
A aplica��o foi projetada para gerenciar pedidos feitos por clientes em um site de lanches. Atrav�s da API REST, � poss�vel criar, visualizar, atualizar e excluir pedidos, al�m de filtrar pedidos por nome de cliente e data.

Funcionalidades:
CRUD de Pedidos: Criar, listar, atualizar e excluir pedidos.
C�lculo de Valor Total: O valor total do pedido � calculado automaticamente com base nos itens.
Valida��o: Valida��o de dados (n�o permite quantidades ou pre�os negativos).

Guia para Acessar e Testar o Projeto
Este projeto � uma aplica��o para gerenciar pedidos de clientes em um site de vendas de lanches. Abaixo est�o as instru��es para que voc� possa acessar o reposit�rio, rodar a aplica��o localmente e testar todas as funcionalidades.

Passo a Passo
1. Instalar o Git (se ainda n�o estiver instalado)
Para poder clonar o reposit�rio, voc� precisa ter o Git instalado na sua m�quina. Caso n�o tenha, siga esses passos:

Acesse https://git-scm.com/downloads e baixe o Git para o seu sistema operacional.
Durante a instala��o, marque a op��o de adicionar o Git ao PATH do sistema, para poder us�-lo diretamente no terminal ou PowerShell.

2. Clonar o Reposit�rio
Depois de instalar o Git, abra o PowerShell (ou o terminal de sua prefer�ncia) e execute o seguinte comando para clonar o reposit�rio:

git clone https://github.com/renanguedesgs/ListadePedidos.git
Isso vai criar uma c�pia local do reposit�rio na sua m�quina.

3. Entrar no Diret�rio do Projeto
Ap�s clonar o reposit�rio, navegue at� a pasta do projeto:
"cd ListadePedidos"

4. dotnet restore
Este comando vai garantir que o .NET baixe todos os pacotes necess�rios para rodar o projeto.

5. Rodar a Aplica��o
Agora, execute a aplica��o com o comando: dotnet run

6.Fazer o Login

Login como Administrador:
Permiss�es: Criar, editar e excluir lanches e categorias, gerar relat�rios, adicionar e gerenciar imagens, e realizar outras opera��es administrativas.
Login: admin@localhost
Senha: Numsey#2022

Login como Cliente:
Permiss�es: Navegar pelos lanches, escolher um lanche favorito, selecionar a quantidade desejada, adicionar itens ao carrinho e finalizar a compra.
Login: usuario@localhost
Senha: Numsey#2022

7. Testar a API

8. Banco de Dados Configurado
O banco de dados j� est� configurado e n�o � necess�rio realizar nenhuma configura��o adicional. Ao rodar a aplica��o, j� sera possivel testar todas as funcionalidades do projeto sem necessidade de configura��o extra.