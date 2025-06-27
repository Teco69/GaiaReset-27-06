using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pegarItem : MonoBehaviour
{
    public GameObject dialogoitem;

   public void OnMouseDown()
   {
    dialogoitem.SetActive(true);
    Destroy(gameObject);
}
}
