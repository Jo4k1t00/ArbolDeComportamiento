using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
namespace ArbolComportamiento
{
    //Es una clase abstracta, por lo tanto no se puede instanciar directamente.
    public abstract class TreeStructure : MonoBehaviour
    {
        //_root será el nodo raíz del árbol de comportamiento (por ejemplo, un Sequence o Selector).
        //Este nodo contendrá o enlazará todos los demás nodos.
        private Node _root = null;
        protected void Start()
            //este construye el arbol en el inicio 
        {
            _root = SetupTree();
        }
        protected void Update()
            //este update hace que constantemente se analice el arbol y su logica de este
        {
            if (_root != null)
                _root.Evaluate();
        }

        //todo figura en el _root que esta relacionado con setuptree
        //Método abstracto donde defines cómo es tu árbol (debes implementarlo).
        protected abstract Node SetupTree();

    }

}
