using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walksirvienta : MonoBehaviour
{
    public float velocidadeEnemigo = 1f;
    private Transform player;
    private GameObject p1;
    
   void Awake()
    {
        p1 = GameObject.Find("caballero");
        player = p1.transform;
    }

    void Update()
    {

       transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), velocidadeEnemigo * Time.deltaTime);
   
        
        


        if (transform.position.x <= player.position.x)
        {
       
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    } 
    
    
}
