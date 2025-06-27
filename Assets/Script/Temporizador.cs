using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporizador : MonoBehaviour
{
    [SerializeField] private float intervalo = 5f; // tempo entre execuções
    private float contador;
    public GameObject gota;

    void Start()
    {
        contador = intervalo;
    }

    void Update()
    {
        contador -= Time.deltaTime;

        if (contador <= 0f)
        {
            FazerAlgo();
            contador = intervalo; // reseta a contagem
        }
    }

    void FazerAlgo()
    {
        Debug.Log("Executando ação no tempo!");
            Instantiate(gota, new Vector3(Random.Range(-35.53f, 26.8f), 63f,0f), Quaternion.identity);
    }
}
