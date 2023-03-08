using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    [SerializeField] private float vida;

    private Animator animatorEnemi;

    public float tiempoVida;

    private void Start()
    {
        animatorEnemi = GetComponent<Animator>();
    }
    public void TomarDaño(float daño)
    {
        vida -= daño;

        if (vida <= 0)
        {
            animatorEnemi.SetBool("Muerte", true);
            Destroy(gameObject, tiempoVida);
        }

    }

} 