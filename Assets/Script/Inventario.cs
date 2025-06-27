using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public bool invAparecendo;
    public Animator anim;
    public GameObject pedecabrainv;
    
    void Start()
    {
        invAparecendo = false;
        
    }
public void OnMouseDown()
    {
        if (invAparecendo ==  false){
            
            anim.SetBool("invAparecendo", true);
            invAparecendo = true;
        
      } else if ( invAparecendo == true){
       
            anim.SetBool("invAparecendo", false);
            invAparecendo = false;

    }
  }

 public void Update(){
    if (GameData.temChave2){
        pedecabrainv.SetActive(true);
    }


 }
    
}
