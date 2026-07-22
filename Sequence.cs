using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ArbolComportamiento
{
    public class Sequence : Node
        //este codigo de secuencia es un concepto compuesto de los arboles de comportamiento
        //basicamente es decir, haz esto , esto y esto, si alguno de estos falla, paramos ahi
    {
        //constructores
        //uno sin parametros para añadirlos despues y otro para añadir hijos en la lista
        public Sequence() : base() { }
        public Sequence(List<Node> children) : base(children) { }
        public override NodeState Evaluate()
            //en esta funcion sobreescrita se pregunta si algun hijo esta ejecutandose como una booleana
        {
            bool anyChildRunning = false;
            //se recorre cada hijo del sequence
            foreach (Node node in children)
            {
                switch (node.Evaluate())
                {
                    //si uno falla el codigo se detiene de inmediato devolviendo el estado
                    case NodeState.FAILURE:
                    state = NodeState.FAILURE;
                    return state;
                        //este tiene exito se continua con el siguiente hijo
                        case NodeState.SUCCESS:
                        continue;
                    //Si un hijo aún se está ejecutando, se marca anyChildRunning = true y se evalua la que sigue
                    case NodeState.RUNNING:
                        anyChildRunning = true;
                        continue;
                    //En caso de un estado inesperado (por seguridad), se asume que todo esta bien. Esto se podría mejorar, porque puede ocultar errores logicos.
                    default:
                        state = NodeState.SUCCESS;
                        return state;

                }
            }
            //este estado se devuelve con la incognita ¿si el?, si sigue corriendo devuelve running, si todos tuvieron exito, se devuelve success
            state = anyChildRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            return state;

        }
    }

}

