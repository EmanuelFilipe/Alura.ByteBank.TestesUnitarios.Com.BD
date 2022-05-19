Para usar o webapp.testes precisa instalar os pacotes:
- Selenium.WebDriver (4.1.0)
- E para usar no chrome precisa instalar tbm: Selenium.WebDriver.ChromeDriver (na versão do seu browser)

Para usar a ferramenta você deve primeiro rodar o projecto com o Ctrl+F5 e depois executar os testes.

*************************************

DevOps

Integrando o Github ao Azure

- Logando no Azure.DevOps, crie um novo projeto
- clique na opção "Project Settings"
- Pipelines > Service Connections > create service connection > selecione o Github
- OAuth Configuration > AzurePipelines > Authorize > Logue no Github > Save



Portal.Azure - criando servidor de BD
- pesquise o banco: ex > mysql
- selecione "Servidores do Banco de Dados do Azure para MySQL" > Criar
- servidor individual > criar
  - grupo de recursos > criar (insira o nome e salvar)
- criar nome e senha do admin do BD

**************************************************************************************************
INTEGRACAO CONTINUA

Criando Pipelines
- pipelines > create > Github
- repostitory > clique nos tres pontos > selecione o projeto desejado > continue
  selecione o tipo de projeto > apply

- agent specification > windows-2022
- Agent job 1 > Agent seleciont: azure pipelines > agent specification > windows-2022
- desabilitar a task de Test por hora, com botão direito do mouse
- save e queue > save and run

Editando pipeline
- clique no menu > no job criado > editar
  menu Triggers > Continuous integration > selecionar a opção Enable continuous integration
  com essa opção ativa todo qualquer commit irá disparar o publish no azure automaticamente

Habilitando a task "Test"
- clique no menu > no job criado > editar
- selecionar Test > botão direito > Enable
  se seu(s) projeto(s) de teste estiverem em portugues... deve realizar essa alteração:
  - Path to project(s) clique no icone de elo > UnLink
  - ajuste a string com o nome do projeto desejado. 
    Ex: **/*[Tt]estes/ByteBank.WebApp.Testes.csproj

**************************************************************************************************

PUBLICANDO PROJETO NO AZURE

- acione o publish no projeto desejado > selecione AZURE > Azure App Service (Windows)
  > vincule sua conta do azure > feche a janela e reinicie para pegar as configurações da sua conta como Assinatura e Groupo
  > clique em + > Edite o nome se quiser > create
    se der erro semelhante: Try selecting different region or SKU.
    tente outras diferentes regiões > finish
- na tela seguinte clique em 'publicar'

**************************************************************************************************

ENTREGA CONTINUA

- pipelines > project settings > service connection > new service connection > 
  azure classic > next > informe o nome da assinatura e seu id em seus respectivos campos > username é o email e preenche a senha >
  service connection name coloque "Azure Classico" > save


RELEASE
no azure devops
- clique na opção Release > new pipeline > azure app service deployment > apply
- clique no link stage 1 "1 job, 1 taks"
- no lado direito selecione a assinatura > authorize e logue
- app service name > selecione o projeto desejado > save
- na guia de menus superior horizontal, clique em pipeline para voltar para a tela anterior
- na area de Artifacts clique em "add" > Source selecione a build desejada > add
- clique no icone de raio > ative a opção de continuous deployment trigger > save