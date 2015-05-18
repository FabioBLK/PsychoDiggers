# PsychoDiggers
Projeto para a aula de T�cnica de programa��o para games

Changelog:

Versao 6.1.6 

- Adicionada a scene_boss:
- Criacao do prefab ZumbiMonsterBoss;
- criacao do script ControllerBoss;
- criacao do triggerBoss;

- Criacao do prefab de Tiro do Boss (BossShot)
- Script com 2 Tipos de Tiro:
	Metodo Tiro Reto
	Metodo Tiro Caindo

____________________________________________________________________________________________________




Versao 6.1.5

Corre��o de bugs:

- Adicionado um segundo GroundCheck nos 2 personagens, para evitar que eles ficassem "Flutuando" quando ficavam na beirada de uma plataforma.
- Alterado o m�todo de troca de personagens, agora durante a troca de personagens, o novo player 2 � instanciado apontando para a mesma dire��o que o player 1 estava. 

____________________________________________________________________________________________________


Vers�o 6.1.4

- Adicionada a nova tela no jogo (Fase 2 que na verdade � a Fase 1 :-P
- Pequenos fixes nos scripts dos personagens. Havia um bug que n�o deixava o personagem invencivel ap�s receber um ataque do inimigo.

____________________________________________________________________________________________________

Vers�o 6.1.3

- Novo Prefab, vers�o 2, para o NecroAtiraParado.
- Para efeitos de teste, desabilitado o tiro do Necro comum (aquele que anda)

____________________________________________________________________________________________________

Vers�o 6.1.2

- Cria��o de Checkpoints na tela. Ap�s passar por um checkpoint, a tela ser� sempre reiniciada nesse �ltimo ponto.
- Estrutura da tela modificada.
- Tela finalizada.

____________________________________________________________________________________________________

Vers�o 6.1.0

changes:
- novos prefabs de plataformas
- organiza��o dos objetos na scene hierarchy
- altera��o no tamanho da altura da tela
- pequena mudan�a de posicionamento da camera
- aumento de velocidade do prefab de tiro "P�"
- alterado o script do "Trigger Enemy" - IMPORTANTE - Os inimigos foram separados por grupos. Cada grupo de inimigo deve ser adicionado ao "filho" do objeto Trigger Enemy. Isso � necess�rio pois agora o script procura apenas os inimigos que s�o filhos desse objeto. Ao contr�rio do modelo anterior, onde o script buscava todos os inimigos da tela.
- Reposicionado v�rios objetos na tela e adicionado algumas plataformas m�veis na tela

____________________________________________________________________________________________________

Vers�o 6.08 

Inclus�o de Tiro do Inimigo:
Um inimigo atirando e andando e outro atirando parado;
Cria��o de um PreFab SkullShot;
A Tag de SkullShot foi marcada como Hazard;

OBS:Foi alterado o nome do antigo Script ControllerNecro para EnemyController para ficar mais gen�rico;

____________________________________________________________________________________________________
Vers�o 6.07 - Prefabs

- Cria��o de v�rios prefabs de Plataformas fixas, com v�rios tamanhos

- Cria��o de uma plataforma que gira. Velocidade, Distancia do raio e sentido podem ser alterados em vari�veis p�blicas no objeto

- Cria��o de uma plataforma que se movimenta para cima e para baixo. Velocidade e distancia podem ser alterados em vari�veis p�blicas no objeto

- Cria��o de uma plataforma que cai no momento que o player pula em cima dela.

- Cria��o de um objeto "Spike" que se comporta como a plataforma, mas pode ferir o player.

- Cria��o deprefabs de itens obrigat�rios em todas as cenas:
	- Camera + backuground
	- Player Shadow (Obrigat�rio para a troca de personagens ocorrer sem "quebrar" o jogo)
	- Trigger Enemy (Obrigat�rio para os inimigos seguirem o player)

- Bug/Melhoria identificado. O trigger enemy talvez tenha que ser alterado em uma futura vers�o. Da forma que est� ele ativa todos os inimigos na tela. Talvez o correto fosse que ele ativasse apenas um pequeno grupo de inimigos.

____________________________________________________________________________________________________

Alterado - Vers�o 6.05

- Adicionado um efeito de explos�o na troca dos personagens

- Alterado a forma que o pulo do personagem 2 afeta os inimigos. Agora o personagem 2 s� mata os inimigos quando estiver caindo

- Inclus�o de danos nos personagens 1 e 2:
	-Quando eles tocam um inimigo, uma anima��o de dano � iniciada, 
	-O personagem � "empurrado" para tr�s por um pouco menos de 1 segundo e o jogador n�o consegue movimentar o personagem durante esse per�odo.
	-Ap�s receber o dano, o player fica invenc�vel por 2 segundos. Visualmente o player fica "piscando" na tela para representar a invencibilidade
	-Durante a invencibilidade, o player n�o colide com os inimigos, justamente para permitir que o jogador fuja do local.
	-Ao receber dano, uma caveira � reduzida do contador.

- Adicionado anima��es de tiro para o player 1 e player 2

- Ao cair fora da tela, o jogador perde as 3 caveiras de uma vez e morre. Um box colider "Destruidor" foi adicionado embaixo das plataformas que inicia essa a��o ao tocar com  algum dos players.

- Ap�s matar um inimigo, o box colider dele � desativado, para que ele n�o colida mais com o player ou com os tiros durante a anima��o da morte do inimigo.
	- Essa a��o causou uma anima��o estranha durante a morte dos inimigos, podemos reve-la.


______________________________________________________________________________________________________

Vers�o 6.03 Barra de Energia

Implementa��es:

1) Pontos do Player:

Um HUD para o Player com Script ScoreManager.
Cada inimigo tem um n�mero de pontua��o, ao mat�-lo o player recebe os pontos do inimigo.

2) Vidas

Implementa��o de um GameObject Image com as vidas no HUD do Player;
OBS: Somente para efeito de teste, ao trocar de player perde-se uma vida. Quando as vidas acabam, volta-se ao �nicio da fase.

3) Troca da imagem do player ao lado dos pontos a cada troca de player.

Foi colocada a seguinte linha de c�digo no script controller de cada player na fun��o de troca:

PlayerFaceManager.iFace = 1;

______________________________________________________________________________________________________

vers�o 6.03

1) Corrigido o bug do inimigo necro que travava o jogo ao trocar de personagens.
No script do inimigo Necro, o c�digo que buscava o player estava fixa no Digger1. 
Al�m disso ele buscava uma vari�vel "direction" dentro do script do Digger1, que varia de -1 at� 1 de acordo com a movimenta��o do jogador. 
Como o Digger 1 era destru�do ao mudar de personagem, criei um gameObject vazio na tela que sempre recebe dos Digger1 ou 2 qual deles est� ativo na tela no momento e ent�o assume a posi��o do eixo X e tamb�m o LocalScale do Digger Ativo. 
Dessa forma O script do Necro, ou qualquer outro inimigo na tela deve buscar esse GameObject chamado PlayerSombra no lugar de especificar o Digger1. 
Outra altera��o, no lugar de buscar a vari�vel "direction" o necro agora busca o localScale do novo GameObject, que tamb�m varia de -1 a 1.

2) Altera��o na forma que o tiro da p� faz danos aos inimigos.
Ao invez de fazer o tiro buscar os componentes dos inimigos para causar hit, o tiro agora apenas manda a mensagem de que colidiu. O proprio objeto que recebeu o hit vai iniciar os proprios componentes como por exemplo receber o dano do tiro, iniciar a anima��o de dano, barra de energia, etc. 
Isso facilitar� no script do tiro que n�o precisar� de nenuma altera��o caso novos inimigos sejam adicionados com componentes diferentes.

3) Limita��o no n�mero m�ximo de tiros (p�s) visiveis na tela para apenas 3
Ao atirar uma p�, uma vari�vel de contador � somada. Ao passar de 3 um novo tiro n�o � mais permitido.
A vari�vel de contador � diminuida quando uma p� � destruida.

4) Destruir o tiro da p� quando ela sair da tela.
Ao sumir da tela, a p� � destruida

5) Digger 2 agora pode pular em cima dos inimigos para mata-los
Adicionado um objeto vazio com um trigger collider nos p�s do Digger2. Esse collider tem um script semelhante ao tiro da p�. Ou seja, ao colidir com um inimigo, ele recebe o dano do objeto Stomp. Al�m disso o collider aciona um m�todo do script do Digger2, fazendo com que se o bot�o de pulo estiver sendo pressionado, o Digger 2 � impulsionado ao pular sobre o inimigo.
