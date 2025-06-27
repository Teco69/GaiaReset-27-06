using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarMapaEmJogo : MonoBehaviour
{
    private CamerapersoX cameraScript;
    void Start()
    {
        cameraScript = GameObject.Find("Player").GetComponent<CamerapersoX>();
    }
    public string cena;
    public void OnMouseDown(){
    
    SceneManager.LoadScene(cena);
    cameraScript.SalvarPosicao();
   
    
   }
}
