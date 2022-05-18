Para usar o webapp.testes precisa instalar os pacotes:
- Selenium.WebDriver (4.1.0)
- E para usar no crhome precisa instalar tbm: Selenium.WebDriver.ChromeDriver (na versão do seu browser)

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
