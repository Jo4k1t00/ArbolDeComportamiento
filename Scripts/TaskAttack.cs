using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArbolComportamiento;
public class TaskAttack : Node
{
    //el objeto guardia
    private Transform _lastTarget;
    //acceso al script del enamigo para aplicar daño
    private EnemyManager _enemyManager;

    //tiempo entre cada ataque
    private float _attackTime = 1f;
    //mide cuanto tiempo ha pasado desde el ultimo golpe
    private float _attackCounter = 0f;

    //una inicializacion aunque no implementada al no necesitarla por que el codigo es para saber a quien atacar
    public TaskAttack(Transform transform)
    {

    }

    public override NodeState Evaluate()
    {
        //en esteevualate se utiliza lo siguiente
        //obtiene al enemigo guardado de target
        Transform target = (Transform)GetData("target");
        if (target == null)
        {
            state = NodeState.FAILURE;
            return state;
        }
        // si el objetivo cambio se busca su enemy manager y se actualiza last target
        if(_enemyManager == null || target != _lastTarget)
        {
            //evita el get component cada frame
            _enemyManager = target.GetComponent<EnemyManager>();
            if (_enemyManager == null)
            {
                ClearData("target");
                state = NodeState.FAILURE;
                return state;
            }
            _lastTarget = target;

        }
        //controla el ritmo de ataque
        _attackCounter += Time.deltaTime;
        if( _attackCounter >= _attackTime )
        {
            //en este si el enemigo muere, se borra el target del arbol, si no muere se reinicia el contador para que ataque otravez cada 1 seg
            bool enemyIsDead = _enemyManager.TakeHit();
            if( enemyIsDead )
            {
                ClearData("target");
            }
            else
            {
                _attackCounter = 0f;
            }
        }
        //devuelve un running para que  el ataque siga en curso mientras este vivo y cerca
        state = NodeState.RUNNING;
        return state;
    }

}
