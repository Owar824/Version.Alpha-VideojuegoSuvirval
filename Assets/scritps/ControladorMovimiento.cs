using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMovimiento : MonoBehaviour
{
    Rigidbody2D rb2D;

    public LayerMask cSuelo;

    private BoxCollider2D bxc;

    [SerializeField] private float velocidad;

    [SerializeField] private float velocidadSalto;

    [SerializeField] private int saltosMaximos;

    public int saltosRestantes;

    private bool mirandoM = true;

    private Animator animatorPlayer;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        bxc = GetComponent<BoxCollider2D>();
        saltosRestantes = saltosMaximos;
        animatorPlayer = GetComponent<Animator>();   
    }

    void Update()
    {
        MovimientoPersonaje();
        Salto();
    }

    void MovimientoPersonaje()
    {
        //Utiliza el input manager para obtener una variable en 1 o -1 
        float move = Input.GetAxis("Horizontal");

        //Hace que se mueva
        rb2D.velocity = new Vector2(move * velocidad, rb2D.velocity.y);

        //funcion para ver la orientacion del personaje
        Orientacion(move);

        if (move != 0)
        {
            animatorPlayer.SetBool("run", true);
        }
        else
        {
            animatorPlayer.SetBool("run", false);
        }
    }

    void Salto()
    {
        if (EstaSuelo())
        {
            saltosRestantes = saltosMaximos;
        }
        if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0f);
            rb2D.AddForce(Vector2.up * velocidadSalto, ForceMode2D.Impulse);
            saltosRestantes--;
        }
        if (EstaSuelo() != true)
        {
            animatorPlayer.SetBool("jump", true);
        }
        else
        {
            animatorPlayer.SetBool("jump", false);
        }
    }

    bool EstaSuelo()
    {
        RaycastHit2D hit = Physics2D.BoxCast(bxc.bounds.center, new Vector2(bxc.bounds.size.x, bxc.bounds.size.y), 0f, Vector2.down, 0.2f, cSuelo);
        return hit.collider != null;
    }
    
    void Orientacion(float move1)
    {
        if ((mirandoM == true && move1 < 0) || (mirandoM == false && move1 > 0))
        {
            mirandoM = !mirandoM;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
