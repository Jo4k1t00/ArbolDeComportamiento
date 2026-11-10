using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArbolComportamiento;
using System;
//este nodo esta al lado de el fovrange, busca un enemigo guardado anteriormente en ese codigo
public class TaskGoToTarget : Node
{
    //el guardia(Transform) se mueve o sera el modificado 
    private Transform _transform;

    //se crea el constructor de este para que setuptree() se reciba

    public TaskGoToTarget(Transform transform)
    {
        _transform = transform;
    }


    
    public override NodeState Evaluate()
    {
        //en este evualate para este codigo, recupera el target que se guardo
        Transform target = (Transform)GetData("target");
        //comprueba si esta lo suficientemente lejos del objetivo para moverse(el margen es de 0.01)
        if(Vector3.Distance(_transform.position, target.position) > 0.01f)
        {
            //SE MUEVE HACIA EL OBJETIVO A VELOCIDAD INTEGRADA EN GUARDIABT
            //Ademas gira para mirar al enemigo
            _transform.position = Vector3.MoveTowards(
                _transform.position, target.position, 
                GuardiaBT.speed * Time.deltaTime);
            _transform.LookAt(target.position);
            Debug.Log("se esta acercando para atacar!!");
        }
        //siempre retorna running por ser movimiento continuo y no se encarga de decidir cuando detenerse
        //otro nodo se encargara de eso
        state = NodeState.RUNNING;
        return state;
    }
}
