[![Finalizado](https://img.shields.io/badge/Status-Conclu%C3%ADdo-brightgreen)](https://github.com/isabelamendesx/AdaTech.CodeManager)

<p>
<img src="docs/imgs/HomeManager.png" alt="Logo Dev Tasker" height="100">
</p>

Seja bem vindo ao meu repositório da aplicação DevTasker, um aplicativo intuitivo e prático desenvolvido pra simplificar a gestão de times de desenvolvedores. No DevTasker, existem dois tipos de usuário: TechLead e Developer, sendo o primeiro mais poderoso que o segundo.
O aplicativo permite com que time acompanhe diversos projetos, visualizando tanto de maneira geral quanto individual, facilitando o desenvolvimento.

## Índice
- 🔨 [Funcionalidades](#-funcionalidades)
- 📁 [Estrutura de diretórios](#-estrutura-de-diretórios)
- 📊 [Diagrama de classes](#-diagrama-de-classes)
- 💻 [Técnicas e tecnologias utilizadas](#-técnicas-e-tecnologias-utilizadas)
  - 🗃️ [Classes e Componentes JavaFX Utilizados](#%EF%B8%8F-classes-e-componentes-javafx-utilizados)
- 🔧 [Como executar](#-como-executar)
- 📄 [Documentação](#-documentação)
- 👥 [Autores](#-autores)

# 🔨 Funcionalidades
<p align="center">
  <img src="docs/imgs/telas.png" alt="Telas do programa">
</p>
-**Cadastro de Time 👥:** O TechLead tem o poder de criar diferentes times, cadastrando os Desenvolvedores disponíveis como membros.

-**Gerenciamento de Time ⚙️:** É possível adicionar ou remover membros de um time e ainda excluir o time completamente.

-**Estatísticas visuais 📊:** Através de estatísticas visuais, o TechLead pode acompanhar o desempenho do time como tarefas completadas, em progresso, atrasadas, abandonadas e em fase de revisão.

-**Quadro Kanban do Projeto 📈:** Os usuários podem visualizar o quadro Kanban de cada projeto.

-**Armazenamento em JSON: 📁** Os dados dos usuários e times são armazenados em um arquivo JSON, permitindo a persistência de dados.

-**Gerenciamento de Projetos e Tarefas 📋:** Os usuários podem criar, editar, e excluir tarefas e projetos. Além disso, é possível atribuir tarefas a membros específicos do time, facilitando a distribuição de responsabilidades.

-**Sistema de Aprovação de Tarefas ✅:** Desenvolvedores têm a capacidade de editar tarefas, mas qualquer modificação requer a aprovação do TechLead. Isso garante um controle rigoroso sobre as alterações e mantém a integridade do projeto.

-**Visualização Estatística de Tarefas 📊:** Os usuários podem visualizar estatísticas detalhadas sobre as tarefas, incluindo aquelas completadas, em andamento, atrasadas, abandonadas e em fase de revisão. Isso fornece uma compreensão abrangente do progresso do projeto.

-**Criptografia de Senhas 🔐:** As senhas dos usuários são criptografadas para garantir a segurança das informações confidenciais.

-**Dashboard para TechLead e Developer 📈:** O aplicativo oferece dashboards distintos para TechLead e Developers. O TechLead pode acessar informações mais abrangentes sobre o desempenho do time, enquanto os Developers têm uma visão mais específica de suas tarefas e projetos.

-**Carregamento de JSON: ⬆️** Todos os usuários, times, tarefas e projetos são carregados a partir de um arquivo JSON, permitindo a recuperação do estado anterior do programa.

Essas funcionalidades combinadas tornam o DevTasker uma ferramenta abrangente e eficaz para a gestão de times de desenvolvedores, proporcionando uma experiência simplificada e intuitiva para todos os usuários envolvidos.

# 📁 Estrutura de diretórios
- **/docs:** Contém a documentação do projeto;
- **/properties:** Centraliza configurações e recursos para personalização da aplicação;
- **/src:** Contém o código fonte do projeto;
- - **/application:** Contém a classe principal da aplicação;
  - **/infrastructure:** Contém os arquivos JSON com os dados de usuários e times;
  - **/model:** Contém os modelos (models) do projeto;
  - **/controller:** Contém os controles (controllers) da aplicação;
  - **/view:** Contém o designer dos Forms do projeto;
  - **/repository:** Repositório envolvendo operações de armazenamento e recuperação de dados;
- **.gitignore:** Arquivo do Git para ignorar arquivos no controle de versão;
- **README.md:** Documentação essencial do projeto em texto;
- **resources:** Contém os recursos utilizados pelo programa como imagens;

# 💻 Técnicas e tecnologias utilizadas

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
<img alt="Windows Form" src = "https://img.shields.io/badge/-windows_form-800080?logo=googleforms&logoColor=white&style=for-the-badge" />
![GitHub](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)
![Git](https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white)
<img alt="MVC" src = "https://img.shields.io/badge/-MVC-800080?logo=googleforms&logoColor=white&style=for-the-badge" />

### Tecnologias
- **C#:** Linguagem de programação de alto nível, amplamente usada para desenvolvimento de aplicativos de software;
- **JavaFX:** Plataforma para criar aplicativos de interface gráfica de usuário (GUI) em Java;
- **Intellij IDEA:** Um dos ambientes de desenvolvimento integrado (IDE) mais populares para programação em várias linguagens, incluindo Java;
- **CSS:** Linguagem de estilo usada para estilizar a aparência das interfaces gráficas JavaFX;
- **FXML:** Linguagem de marcação utilizada no JavaFX para criar interfaces de usuário de forma declarativa;
- **Scene Builder:** Ferramenta de design visual que permite criar interfaces gráficas de usuário para aplicativos JavaFX de forma interativa e visual;
- **Javadoc:** Ferramenta para gerar documentação a partir de código-fonte Java, fornecendo referências e documentação dos métodos;
- **Maven:** Ferramenta de automação de compilação e gerenciamento de projetos em Java;
- **Git & Github:** Sistema de controle de versão distribuído (Git) e plataforma de hospedagem de código (Github);

### Técnicas e Paradigmas
- **Generics:** Recurso do Java que permite a criação de classes, interfaces e métodos genéricos que aceitam tipos como parâmetros;
- **Polimorfismo:** Capacidade de objetos de diferentes classes serem tratados por um mesmo tipo genérico, permitindo que métodos se comportem de maneiras diferentes em diferentes classes;
- **Diagrama UML:** Conjunto de notações e diagramas para modelar sistemas de software;
- **Estrutura de dados:** Métodos, estruturas e algoritmos para armazenar e organizar dados de forma eficiente;
- **Modularização:** Técnica de dividir um sistema em módulos independentes para melhorar a manutenção e a escalabilidade;
- **Event Handling:** Tratamento de eventos gerados por interações do usuário (por exemplo, cliques de botões, teclas pressionadas, etc.);
- **Design Patterns:** Soluções recorrentes para problemas comuns de design de software, fornecendo abordagens testadas e comprovadas;
- **Princípios SOLID:** Conjunto de princípios de design de software (Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation e Dependency Inversion);
- **Segurança de dados:** Práticas e técnicas para proteger informações sensíveis contra acesso não autorizado ou alterações indevidas, incluindo criptografia hash para senhas;
- **Persistência de dados:** Mecanismos e técnicas para salvar e recuperar dados de forma permanente.
- **Separation of Concerns:** Princípio de design para separar diferentes preocupações em módulos independentes;
- **Manipulação de arquivos:** Operações de leitura, gravação e manipulação de arquivos em um sistema de arquivos;
- **Programação Orientada a Objetos:** Paradigma de programação baseado em objetos, incluindo conceitos como classes, objetos, herança, polimorfismo, etc;
- **Arquitetura Model-View-Controller:** Padrão de design que separa os componentes de uma aplicação em modelo (dados), visão (interface gráfica) e controlador (lógica de controle).

## 🗃️ Classes e Componentes JavaFX Utilizados
- FXML: Utilizado para definir a interface do usuário de forma declarativa.
- FXMLLoader: Utilizado para carregar arquivos FXML.
- Controller: Controlador responsável por gerenciar a lógica da interface do usuário.
- ScrollPane: Utilizado para adicionar uma barra de rolagem em torno de componentes maiores.
- ComboBox: Componente que oferece uma lista suspensa de opções para escolha.
- TextField: Caixa de texto que permite a entrada de dados do usuário.
- PasswordField: Campo de texto para entrada de senhas, ocultando os caracteres digitados.
- CheckBox: Componente que permite ao usuário selecionar ou desmarcar uma opção.
- Button: Componente para botões na interface gráfica.
- VBox: Container de layout vertical na interface gráfica.
- HBox: Contêiner de layout horizontal para organizar elementos lado a lado.
- Label: Componente para exibir texto na interface gráfica.
- ProgressBar: Utilizado para exibir o progresso em barras.
- Scene: Define o conteúdo do palco (Stage) em JavaFX.
- Stage: Janela principal do aplicativo JavaFX.
  
