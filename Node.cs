using System.Collections;
using System.Collections.Generic;


namespace ArbolComportamiento
{

    //Estados que se resumen en exito, corriendo(que se sigue ejecutandose)
    //y fracaso,
    //estos estados son importante para saber el estado del arbol y como se va a comportar
    public enum NodeState
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }


    public class Node
    {
        protected NodeState state;


        //en lo siguiente se crea un campo parent y una lista dedicada al nombre Node
        //lo cual es importante por que la lista ayudara a nuestro composite a juntarse con sus hijos
        public Node parent;
        protected List<Node> children = new List<Node>();//se le dice datos compartidos

        private Dictionary<string, object> _dataContext = new Dictionary<string, object>();


        //Constructor, de otra manera estos terminos estararn vacios si se usan asi sin mas
        public Node()
        //inicializa el padre como null(sin hijos ni padre)
        {
            parent = null;
        }
        public Node(List<Node> children)
        {
            //patron para el arbol
            foreach (Node child in children)
                _Attach(child);//attach(adjuntar) al children(hijo)
        }
        //establece la relacion padre e hijo
        private void _Attach(Node node)
        {
            node.parent = this;
            children.Add(node);
        }


        //creamos el evaluate, donde se retornara cada estado que suelte un hijo
        //sera virual para que cada clase de nodo derivada lo manipule
        //con su propia funcion
        public virtual NodeState Evaluate() => NodeState.FAILURE;

        public void SetData(string key, object value)
        {
            _dataContext[key] = value;
        }

        public object GetData(string key)
        {
            object value = null;
            if (_dataContext.TryGetValue(key, out value))
                return value;

            Node node = parent;
            while (node != null)
            {

                value = node.GetData(key);
                if (value != null)
                    return value;
                node = node.parent;
            }
            return null;
        }
        public bool ClearData(string key)
        {
            if (_dataContext.ContainsKey(key))
            {
                _dataContext.Remove(key);
                return true;
            }
            Node node = parent;
            while (node != null)
            {
                bool cleared = node.ClearData(key);
                if (cleared)
                    return true;
                node = node.parent;
            }
            return false;
        }
    }
}







