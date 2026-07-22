using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArbolComportamiento;

//codigo para buscar enemigos
public class CheckEnemyInFOVRange : Node
{
    //define una mascara de capa para detectar enemigos, asumiendo que los enemigos estan en la capa 6
    private static int _enemyLayerMask = 1 << 6;
    //el transform del personaje usado como origen de deteccion
    private Transform _transform;

    //constructor, recibe el transform del game object para usarlo dentro del evaluate
    public CheckEnemyInFOVRange (Transform transform)
    {
        _transform = transform;
    }
    public override NodeState Evaluate()
    {
        //verifica si hay un objetivo guardado por ejemplo desde algo anterior
        object t = GetData("target");
        //si no hay objetivo guardado procede a escanear el area
        if (t == null)
        {
            //crea un overlap en forma de esfera y usa en base al GuardiaBT como campo de vision
            //detectando solo en la capa de enemigos(layer enemigo)
            Collider[] colliders = Physics.OverlapSphere(
                _transform.position, GuardiaBT.fovRange, _enemyLayerMask);
            
            if (colliders.Length > 0)
            {
                //si el collider del largo es mayor a cero el parent setdata para guardar al enemigo como target
                parent.parent.SetData("target", colliders[0].transform);
                //OJO: todo este esta dentro de una secuencia, osea el parent es el selector, donde esta el diccionario compartido de Node
                //si funciona el if, retorna success
                state = NodeState.SUCCESS;
                return state;
            }
            //si t es null asi tal cual es fracaso
            state = NodeState.FAILURE; 
            return state;
        }
        //si agarra el target es un success
        state = NodeState.SUCCESS;
        return state;
    }
}
