using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerenciarEvento : MonoBehaviour
{
    public GameObject fumacaDano;
    public GameObject fumacaHud;
    
    void Start()
    {
        var position = new Vector3(Random.Range(-9.33f, 46.14f), -3.94f);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        fumacaHud.SetActive(true);
        fumacaDano.SetActive(true);
        
        
    }
}
