using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //vida del enemigo
    private int _healthpoints;

    //lo inicializa con 30 en escena
    private void Awake()
    {
        _healthpoints = 30;
    }

    //cada vez que se llama quita 10 de via, si llega a 0 llama a die y devuelve true si murio
    public bool TakeHit()
    {
        _healthpoints -= 10;
        bool isDead = _healthpoints <= 0;
        Debug.Log("ATACANDO");
        if (isDead) _Die();
        Debug.Log("el objetivo murio");
        return isDead;
    }
    //destruyye el enemigo si esta muerto en la escena
    private void _Die()
    {
        Destroy(gameObject);
    }
}