using ArbolComportamiento;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//al final de toda accion hecha, este es el codigo que aplica el orden del arbol
public class GuardiaBT : TreeStructure
    //subclase de treestructure, ejecutara automaticamente en unity gracias a start y update
    //su trabajo principal es definir como se contruye el arbol gracias a SetupTree()
{
    // waypoints asignados desde el inspector, determinara puntos de patrullaje
    public UnityEngine.Transform[] waypoints;
    //velocidad de movimiento
    public static float speed = 2f;
    //rango de deteccion
    public static float fovRange = 6f;
    //rango de ataque
    public static float attackRange = 1f;

    //aqui se define el comportamiento usando nodos compuestos de sequence y selector
    protected override Node SetupTree()
    {
        //este comienza como raiz como un selector, elige entre varios comportamientos en orden, devolviendo en algo que funcione de manera rapida
        //poder hacer esto, no   esto?, no bueno, entonces patrullo
        Node root = new Selector(new List<Node> 
        { 
           //verifica si hay un enemigo al alcance, si lo hay ataca, si falla pasa al siguiente
        new Sequence(new List<Node>
        {
            new CheckEnemyInAttackRange(transform),
            new TaskAttack(transform),
        }),
        //verifica si hay un enemigo en el campo de vision, si lo ve se va al target, si no, pasa a patrulla
        new Sequence(new List<Node>
        {
            new CheckEnemyInFOVRange(transform),
            new TaskGoToTarget(transform),
        }),
        //nodo de ejecucion de patrulla si no hay enemigos
        //mueve al guardia entre puntos designados
        new TaskPatrol(transform, waypoints), 
        
        });
        //todo esto funciona devolviendo el root
       return root;
     }
}

        

