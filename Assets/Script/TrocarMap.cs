using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrocarMap : MonoBehaviour
{
    public string cena;
    public GameObject capitulos;
    public GameObject botoesmenu;

    public void Play()
    {
        SceneManager.LoadScene(cena);
    }

    public void OnMouseDown(){
        Application.Quit();
    }

    public void caps(){
        capitulos.SetActive(true);
        botoesmenu.SetActive(false);
    }
    public void voltarDoCaps(){
        capitulos.SetActive(false);
        botoesmenu.SetActive(true);

    }
}
