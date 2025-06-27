using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartas : MonoBehaviour
{
   public GameObject Carta;

   public void OnMouseDown()
   {
    Carta.SetActive(true);
    Destroy(gameObject);
   }
}
