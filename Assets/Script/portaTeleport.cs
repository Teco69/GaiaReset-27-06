using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portaTeleport : MonoBehaviour
{
    public Transform destino; // Arraste aqui o ponto para onde o player vai

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = destino.position;
        }
    }
}
