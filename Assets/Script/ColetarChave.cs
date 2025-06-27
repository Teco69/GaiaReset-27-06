using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetarChave : MonoBehaviour
{
     private void OnMouseDown()
    {
        GameData.temChave = true;
        Destroy(gameObject); // Remove a chave da cena
        Debug.Log("Chave coletada!");
    }

    //GameData.temChave = true; usar na segunda chave
}