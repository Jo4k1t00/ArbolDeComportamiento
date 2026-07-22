using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArbolComportamiento;
public class CheckEnemyInAttackRange : Node
{
    //este layermask no se utiliza directamente, iomplementada en FOV
private static int _enemyLayerMask = 1 << 6;
    //el transform del guardia o que evalua si el enemigo esta cerca
    private Transform _transform;
    
    //constructor para mandar el transform al setuptree
    public CheckEnemyInAttackRange(Transform transform)
    {
        _transform = transform;
    }

    //en el metodo evaluate es corto
    public override NodeState Evaluate()
    {
        //se detecta un objeto que tiene la data target(siendo guardada por el codigo Fov)
        object t = GetData("target");
        if(t == null)
        {
            //si no hay ningun enemigo guardado como target, devuelve logicamente un fracaso
            state = NodeState.FAILURE;
            return state;
        }
        //se convierte el objeto a transform para medir distancia
        Transform target = (Transform)t;

        //si la distancia al objetivo es menor o igual al rango de ataque, se considera que esta dentro de ahi
        if(Vector3.Distance(_transform.position, target.position) <= GuardiaBT.attackRange)
        {
            //devuelve exito
            state = NodeState.SUCCESS;
            return state;
        }
        //si el objetivo esta fuera del rango, no se debe atacar todavia, asi que devuelve failure
        state = NodeState.FAILURE;
        return state;
    }
}
