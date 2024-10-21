<h1><b>REPOSITÓRIO PARA O TESTE DA ARCO EDUCAÇÃO</b></h1>

<h4>*** INSTRUÇÕES ***</h4>
<ul>
  <li>Conteúdo pricnipal disponível em: <b>ARCO-TEST-PROJECT/Assets/... </b> </li>
  <li>Todos os modelos 3D estão dentreo de <b>../Assets/3D Models</b></li>
  <li>Todas as texturas estão disponíveis em <b>../Assets/Textures/AR Objects</b></li>
  <li>Todos os materiais estão disponíveis em <b>../Assets/Materials</b></li>
  <li>Todos os scripts estão disponíveis em <b>../Assets/Scripts</b></li>
</ul>

<h4>*** FERRAMENTAS UTILIZADAS ***</h4>
<ul>
  <li> Unity Engine - 2021.3.7f1 </li>
  <li> Blender - 4.1 </li>
  <li> Vuforia - 10.27.3 </li>
  <li> Figma - Web Version </li>
</ul>

<h4>*** VÍDEOS ***</h4>
<ul>
 <li> VÍDEO 01: EXECUTANDO: https://drive.google.com/file/d/1NpMa4DzoqQnhiNmDeWT2aIgMYq6nh_Ct/view?usp=sharing</li>
 <li> VÍDEO 02: EXPLICAÇÕES: https://drive.google.com/file/d/1BnhmNYtQUGDOQRODoNt2SCl--BmeVB0G/view?usp=sharing</li>
</ul>

<h4>*** POLÍGONOS ***</h4>
</br>
O projeto conta com três modelos, sendo que um deles é uma malha unificada para diminuir a quantidade de Draw Calls (uma malha unificada faz uma chamada para todas, o que aumenta a performance de renderização).
Abaixo vou colocar a quantidade de polígonos de cada prop/asset.
</br>
<ul>
 <li> Amostra DNA: 4.436 tris </li>
 <li> Mesa Alquimia COMPLETA: 5k tris </li>
 <li> Planeta Terra: 4k tris </li>
  -----------------------------------
  <li>Livro: 760 tris</li>
  <li>Vidro Grande: 528 tris</li>
  <li>Proveta Completa: 800 tris</li>
  <li>Poção Pequena: 150 tris</li>
  <li>Corda: 720 tris</li>
  <li>Lupa: 384 tris</li>
  <li>Segurador Proveta + Proveta: 1.500 tris</li>
  <li>Tábua: 249 tris</li>
</ul>

<h4>*** TEXTURAS ***</h4>
</br>
As texturas foram feitas utilizando o Figma e o Blender. Texturas do DNA e do Segurador de proveta foram feitas de forma procedural e depois trabsformadas em arquivo. 
Utilizei da técnica de Normal Mapping e Height Mapping para alguns objetos.
Além disso foi feito do uso da técnica de Atlas, onde varias malhas e objetos partilham de uma mesma textura e mateiral, para diminuir a quantidade de Draw Calls.
</br>
As texturas são todas em 'power of two', para a Unity Engine conseguir comprimir seu tamanho com o UNorm.
