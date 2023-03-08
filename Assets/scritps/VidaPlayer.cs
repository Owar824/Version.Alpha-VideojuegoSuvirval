using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    public float salud;
    public float maximoSalud;

    bool inmune;
    public float tiempoInmune;
    //Blink material;
    SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        salud = maximoSalud;
    }

    void Update()
    {

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo") && !inmune)
        {
            salud -= collision.GetComponent<DañoEnemigo>().damage;
            StartCoroutine(Inmunidad());
            if (salud <= 0)
            {
                Debug.Log("Muerto");
            }
        }  
        
    }

    IEnumerator Inmunidad()
    {
        inmune = true;
        yield return new WaitForSeconds(tiempoInmune);
        inmune = false;
    }
}
