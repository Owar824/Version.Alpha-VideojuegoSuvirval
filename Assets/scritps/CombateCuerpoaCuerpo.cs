using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CombateCuerpoaCuerpo : MonoBehaviour
{
    [SerializeField] private Transform controladorgolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;
    private Animator animator;
    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float TiempoSiguienteAtaque;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
      
    private void Update()
    {    
        if(TiempoSiguienteAtaque > 0)
        {
            TiempoSiguienteAtaque -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.X) && TiempoSiguienteAtaque <= 0)
        { 
            Golpe();
            TiempoSiguienteAtaque = tiempoEntreAtaques;
        }
    }
  
    private void Golpe() 
    {
        animator.SetTrigger("Golpe");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorgolpe.position, radioGolpe);

        foreach (Collider2D collider2 in objetos)
        {
            if (collider2.CompareTag("Enemigo"))
            {
                collider2.transform.GetComponent<VidaEnemigo>().TomarDaño(dañoGolpe);
            }
        }
    }

  /*  private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorgolpe.position, radioGolpe); 
    } */

}
