# Treasure Hunt
Ceci est le premier projet jeu vidéo auquel j'ai participé. 

C'est un jeu d'aventure / puzzle où le but est de trouver 5 enveloppe qui contiennt chacune une lettre qui forme un mot permettant d'ouvrir le coffre final. 

![Title](./img/title.png)

Dévelopé avec Unity en C#, par 2 personnes.

## Le jeu
La **première** enveloppe est donnée tout de suite au joueur et elle lui indique ce qu'il doit faire.

La **deuxième** est donnée lorsque le joueur sort de la première zone : un **labyrinthe**

![Labyrinthe](./img/labyrinthe.png)

A la sortie de ce dernier, nous entrons dans un "open world" avec 4 destinations possible : `Village`, `Mountain`, `Castle` ou `End House`. Les trois premières sont d'autres défis alors que la dernière est la fin du jeu.

Une des suites possible est dont le village. 

![village](./img/village.png)

Quand on arrive au village, il y a une personne a terre qui a besoin d'aide pour retrouver sa maison. Afin de trouver la bonne maison, il faut parler au autres habitants, mais ceux-ci répondront par "Je vis a côté d'Eric mais pas dans la maison à la porte brune" ou encore "Je vis loin de la maison d'Alex". Le but est donc, à l'aide ces indices de trouver la bonne maison. A la fin on obtient une enveloppe.

Vienne ensuite les deux autres zone `Mountain` et `Castle`. Pour y accéder il va falloir monter dans la montagne. 

Le jeu de la `Mountain` est le suivant : 

![mountain](./img/mountain.png)

Il s'agit d'un mini-jeu où le but est de rouler sur tout les cubes rouge à l'aide de la boule blanche.

Le dernier jeu est un jeu où le but est de mettre les cubes de couleur sur le sol de la meme couleur

![castle](./img/castle.png)

Il y a 5 niveaux qui augmente en difficulé (et en taille pour les deux derniers)

## La fin du jeu

Un fois les 5 enveloppes en main, on peut se diriger vers la zone final. 

![end](./img/the_end.png)

C'est une petite maison dans laquel se trouve un coffre. Afin de l'ouvrir, il faut s'aider des 5 enveloppes ; elles contiennent toute une lettre qui assemblée dans le bon ordre forme un mot qui permet de déverouiller le coffre et d'accéder aux crédits de fin.
