using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Transform centroDelCarrusel;
    public float velocidadRotacionCentro = 30f;
    public float velocidadRotacionHijos = 50f;

    private Transform[] hijos;

    void Start()
    {
        // Obtén los hijos del objeto actual.
        hijos = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            hijos[i] = transform.GetChild(i);
        }
    }

    void Update()
    {
        // Rotar el centro del carrusel alrededor de su propio eje vertical.
        centroDelCarrusel.Rotate(Vector3.up, velocidadRotacionCentro * Time.deltaTime);

        // Rotar cada hijo alrededor del centro.
        foreach (Transform hijo in hijos)
        {
            hijo.RotateAround(centroDelCarrusel.position, Vector3.up, velocidadRotacionHijos * Time.deltaTime);
        }
    }
}