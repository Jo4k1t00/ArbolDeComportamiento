using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArbolComportamiento;

public class TaskPatrol : Node
{
    // este es el primer nodo para el arbol
    //cabe destacar que cada accion del selector y sequence son instrucciones a seguir
    //y nosotros somos los encargados de hacer que todo funcione correctamente

    //el objeto que se movera
    private Transform _transform;
    //puntos donde va a patrullar
    private Transform[] _waypoints;

    //indice del waypoint actual
    private int _currentWaypointIndex = 0;

    //cuanto tiempo se detiene cada waypoint
    private float _waitTime = 1f;
    //mide el tiempo esperado
    private float _waitCounter = 0f;
    //si el guardia esta en espera o no, en este caso no
    private bool _waiting = false;
    //al necesitar informacion para patrullar necesita un constructor
    //se inicializa con el transform del guardia y la lista de puntos que patrullara
    //se van a pasar desde el setuptree en el guardiabt
    public TaskPatrol(Transform transform, Transform[] waypoints)
    {
        _transform = transform;
        _waypoints = waypoints;
    }

    //hora de evaluate, que define como se comportara el nodo y que tipo de resultada retornara
    public override NodeState Evaluate()
    {
        if (_waiting)
        {
            //si esta esperando se cuenta el counter y si este es mas o igual al tiempo de espera
            //waiting es false
            _waitCounter += Time.deltaTime;
            if (_waitCounter >= _waitTime)
                _waiting = false;
        }
        else
        {
            /*Si el personaje llega al waypoint actual (comparando distancia)
        Ajusta su posición exactamente al punto (para evitar errores de redondeo).
        Reinicia el contador de espera.
        Marca que debe esperar.
        Avanza al siguiente waypoint en la lista (ciclicamente con %).*/
            Transform wp = _waypoints[_currentWaypointIndex];
            if(Vector3.Distance(_transform.position, wp.position) < 0.01f)
            {
                _transform.position = wp.position;
                _waitCounter = 0f;
                _waiting = true;
                Debug.Log("patrullando");

                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
            }
            else
            {
                //si aun no ha llegado se mueve hacia el waypoint con vector3.movetowards
                //ademas gira para mirar en esa direccion con look at
                _transform.position = Vector3.MoveTowards(_transform.position,
                    wp.position, GuardiaBT.speed * Time.deltaTime);
                _transform.LookAt(wp.position);
                Debug.Log("patrullando");
            }
        }
        //al ser de patrulla devuelve running al ser un actitud continua
        state = NodeState.RUNNING;
        return state;
    }
}
