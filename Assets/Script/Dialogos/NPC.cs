using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public ControleDialogo controle;
    public Dialogo[] dialogo;

    private void OnMouseDown(){
        //Verifica se já foi o ultimo dialog, se sim reinia a lista de diag
        if(controle.indiceFala == dialogo.Length ){
                 controle.indiceFala=0;
            }    
        if(controle.indiceFala <= dialogo.Length -1){
             Debug.Log("Depois do IF" + controle.indiceFala);
            controle.iniciarDialogo(dialogo[controle.indiceFala]);
       
        }
   }
}
