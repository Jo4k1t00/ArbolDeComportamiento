using System.Collections.Generic;


namespace ArbolComportamiento
{
    //define el selector hereda de node
    public class Selector : Node
    {
        //estos son constructores
        //el primero es uno vacio en el caso de añadir nodos hijos en algun otro codigo
        //Otro que permite pasar la lista de hijos al crear el nodo.
        public Selector() : base() { }
        public Selector(List<Node> children) : base(children) { }

        //esta funcion sobreescrita de node state es la funcion de selector, si uno es fracaso, se continua, si es exito se retorna el estado succes y si esta corriendo devuelve el estado running
        public override NodeState Evaluate()
        {

            foreach (Node node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        continue;
                    case NodeState.SUCCESS:
                        state = NodeState.SUCCESS;
                        return state;
                    case NodeState.RUNNING:
                        state = NodeState.RUNNING;
                        return state;
                    default:
                        continue;

                }
            }
            //cuando todo falla o algun error ocurre, algo que no deberia pasar, devuelve el estado de fracaso.
            state = NodeState.FAILURE;
            return state;

        }
    }

}
