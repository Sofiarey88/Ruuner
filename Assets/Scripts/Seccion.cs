using System.Collections.Generic;
using UnityEngine;

public class Seccion : MonoBehaviour
{
    public List<GameObject> obstaculos;
    public List<GameObject> puntos;

    public float speed = 8f;
    public float largo = 20f;
    public float ajuste = 1.2f;

    private Vector3 posicionInicial;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posicionInicial = transform.position;

        obstaculos = new List<GameObject>();
        puntos = new List<GameObject>();

        foreach (Transform t in transform)
        {
            if (t.CompareTag("obstaculo"))
                obstaculos.Add(t.gameObject);

            if (t.CompareTag("punto"))
                puntos.Add(t.gameObject);
        }

        ResetearPuntos();
        Randomm();
        RandomPuntos();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector3.back * speed * Time.fixedDeltaTime);

        if (rb.position.z < posicionInicial.z - (largo * ajuste))
        {
            // 🔥 1. mover primero
            rb.position = posicionInicial;

            // 🔥 2. resetear monedas
            ResetearPuntos();

            // 🔥 3. nuevo contenido
            Randomm();
            RandomPuntos();
        }
    }

    // 🔁 ACTIVA TODAS LAS MONEDAS
    public void ResetearPuntos()
    {
        foreach (GameObject p in puntos)
        {
            p.SetActive(true);
        }
    }

    // 🎲 OBSTÁCULOS RANDOM
    public void Randomm()
    {
        foreach (GameObject o in obstaculos)
            o.SetActive(false);

        if (obstaculos.Count > 0)
        {
            int i = Random.Range(0, obstaculos.Count);
            obstaculos[i].SetActive(true);
        }
    }

    // 🪙 MONEDAS RANDOM
    public void RandomPuntos()
    {
        foreach (GameObject p in puntos)
            p.SetActive(false);

        if (puntos.Count > 0)
        {
            int i = Random.Range(0, puntos.Count);
            puntos[i].SetActive(true);
        }
    }
}