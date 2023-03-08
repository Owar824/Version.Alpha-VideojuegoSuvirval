using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class controladorenemigos : MonoBehaviour
{
    private float minX, maxX, minY, maxY;

    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] enemigos ;
    [SerializeField] private float tiempoEnemigos;
    private float tiempoSiguienteEnemigo;

    public float tiempoTranscurrido;

    private void Start()
    {
        maxX = puntos.Max(puntos => puntos.position.x);
        minX = puntos.Min(puntos => puntos.position.x);
        maxY = puntos.Max(puntos => puntos.position.y);
        minY = puntos.Min(puntos => puntos.position.y);
    }

    private void Update()
    {
        tiempoSiguienteEnemigo += Time.deltaTime;

        tiempoTranscurrido += Time.deltaTime;

        //cuando se den los retoques modificar las conciciones para que se adapten a la dificultad del videojuego.

        while ((tiempoEnemigos >= 4 && tiempoTranscurrido >= 40) || (tiempoEnemigos >= 2 && tiempoTranscurrido >= 90))
        {
            tiempoEnemigos--; 
        }

        if (tiempoSiguienteEnemigo >= tiempoEnemigos) 
        {
            tiempoSiguienteEnemigo = 0;
            CrearEnemigos();
        }
    }
    private void CrearEnemigos() {
        int numeroEnemigo = Random.Range(0, enemigos.Length);
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(enemigos[numeroEnemigo], posicionAleatoria, Quaternion.identity);
    }
}
