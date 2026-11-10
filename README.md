# Árbol De Comportamiento
Gameplay:

<img width="800" height="336" alt="Arbol de comportamiento Demostracion audiovisual" src="https://github.com/user-attachments/assets/6e7b5b27-eba4-4ff3-bf69-f839d37f90e6" />

Una frase: Gameplay de una inteligencia artificial usando el árbol de comportamiento, el script funciona como un enemigo quien ataca al jugador.

## Como Jugar

[En el portafolio encontraran la simulacion.](https://jo4k1t00.github.io/PortafolioJoakito/)
Si quieren probarlo, pueden probarlo descargando el proyecto por medio de la carpeta de proyecto de unity.

## Controles
Se requiere de un ordenador para poder presenciar la simulacion entera.

## Requisitos e instalación
Unity 2022.3.45f1

## Mi aporte
Me encargue de llevar el proyecto para hacer una IA, por medio de la Programación y la Programación Orientado a Objetos. El objetivo de este proyecto es aprender a como construir una interaccion por medio de una inteligencia artificial en un juego y exponerlo al curso, en mi caso elegi un BEHAVIOR TREE una estructura jerárquica utilizada en inteligencia artificial y robótica para controlar cómo un agente (como un personaje de videojuego o un robot) toma decisiones y ejecuta acciones.

### Primera Fase: Grafico visual

Crear visualmente el orden del árbol de comportamiento, este tiene su propia definición para referirse a selectores y secuencias.

<img width="1238" height="697" alt="ArbolDeComportamiento" src="https://github.com/user-attachments/assets/53fe1923-78ba-4006-920b-306fa8c6c391" />

La idea es usar un selector para poder recorrer de izquierda a derecha todos los comportamientos secuenciales para que infinitamente siga patrullando hasta encontrar al jugador y atacarlo.

### Segunda Fase: Codificar

Crear los codigos importantes para este, este son:

#### NODO

<img width="695" height="830" alt="image" src="https://github.com/user-attachments/assets/2a9629eb-933c-410f-887d-b83d8d029ada" />

<img width="555" height="770" alt="image" src="https://github.com/user-attachments/assets/14c60c1d-bd3e-4ec3-8822-19a955bcda30" />

#### TREESTRUCTURE

<img width="682" height="498" alt="image" src="https://github.com/user-attachments/assets/4d7957b8-19fc-4d27-b944-af2ba4950c78" />

#### Código Secuencia y Selector 

##### Selector

<img width="1316" height="702" alt="image" src="https://github.com/user-attachments/assets/5b1a822b-c5fa-403e-9c11-acdbd7c5d3c3" />

##### Secuencia

<img width="1085" height="787" alt="image" src="https://github.com/user-attachments/assets/5af2cced-6d52-4db3-b5b6-69a63191640c" />

#### Nodos Interactivos

##### TaskPatrol: el código de constante trabajo del arbol

<img width="460" height="886" alt="image" src="https://github.com/user-attachments/assets/71964530-32b7-41e9-b35a-acc28ecb3faf" />

##### CheckEnemyInFOVRange

<img width="655" height="552" alt="image" src="https://github.com/user-attachments/assets/ae291878-888c-44d6-97d3-3e9ad793d4dc" />

##### TaskAttack

<img width="697" height="772" alt="image" src="https://github.com/user-attachments/assets/db69dd6a-a85a-4853-878b-d125cef44d1b" /> 

##### CheckEnemyInAttackRange

<img width="532" height="496" alt="Captura de pantalla 2026-11-10 172140" src="https://github.com/user-attachments/assets/5d02548c-bf18-4da1-ab82-62c9f917453d" />

##### TaskGoToTarget

<img width="500" height="467" alt="Captura de pantalla 2026-11-10 172151" src="https://github.com/user-attachments/assets/55bf2a64-fd51-4b76-a675-f8ec0c93b9d0" />

##### GuardiaBT

<img width="692" height="546" alt="Captura de pantalla 2026-11-10 172158" src="https://github.com/user-attachments/assets/337976a8-25be-4548-8483-0919ff1ddfcd" />

##### EnemyManager (Codigo para el jugador)

<img width="448" height="332" alt="image" src="https://github.com/user-attachments/assets/9af91cc7-7567-454c-a6c4-de9a1db72517" />

#### MONTAJE

Con estos codigos tendremos que compilarlos a las capsulas o modelos de tus objetos en la escena. 

##### ENEMIGO (Principal objeto)

El enemigo solo tendra el codigo GuardiaBT, debido a que **su estructura de arbol es una composicion todo se encarga de reproducirlo a traves de la sobreescritura de SetupTree de Node a traves de la Programacion Orientada a objetos:**

<img width="252" height="113" alt="image" src="https://github.com/user-attachments/assets/a0dd5ce1-ceba-425d-8989-c42f5f12ed80" />

<img width="710" height="237" alt="image" src="https://github.com/user-attachments/assets/eff23dc9-2a8b-4b50-ba00-5eeb502a2d42" />

##### Jugador (Objeto que interactua con enemigo)

El jugador recibira el daño recibido por el enemigo, **EnemyManager se encargara de que se cumpla la interaccion y destruya el objeto cuando el integer llege a 0:**

<img width="255" height="22" alt="image" src="https://github.com/user-attachments/assets/e4a855fc-80da-480a-ac9e-6e6ecbfad897" />

<img width="706" height="65" alt="image" src="https://github.com/user-attachments/assets/604bb299-4a26-49e2-bb47-b3ed8c9c3797" />

# LISTO, TIENES EL CODIGO HECHO DE UN ENEMIGO PATRULLANDO

<img width="800" height="336" alt="Arbol de comportamiento Demostracion audiovisual" src="https://github.com/user-attachments/assets/6e7b5b27-eba4-4ff3-bf69-f839d37f90e6" />
