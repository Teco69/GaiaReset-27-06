using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chave2 : MonoBehaviour
{
    public GameObject sair;
    
     private void OnMouseDown()
    {
        GameData.temChave2 = true;
        Destroy(gameObject); // Remove a chave da cena
        Debug.Log("Chave coletada!");
        sair.SetActive(true);
    }

    
}
