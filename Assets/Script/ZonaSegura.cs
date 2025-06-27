using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaSegura : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<RadiationManager>().estaNaZonaSegura = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<RadiationManager>().estaNaZonaSegura = false;
        }
    }
}