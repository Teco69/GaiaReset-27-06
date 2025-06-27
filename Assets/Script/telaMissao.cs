using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telaMissao : MonoBehaviour
{
  public GameObject aparecer;

  public GameObject saindo;
  public Animator anima;
   

  public bool aparecendo;

    public void start()
    {
        aparecendo = false;
    }
    public void OnMouseDown()
    {
        if (aparecendo ==  false){
            
            anima.SetBool("aparecendo", true);
            aparecendo = true;
        
      } else if ( aparecendo == true){
       
            anima.SetBool("aparecendo", false);
            aparecendo = false;

    }
  }
}
