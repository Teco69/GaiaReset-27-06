using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruir : MonoBehaviour
{
    [SerializeField] private float tempoParaDestruir = 3f;

    void Start()
    {
        Destroy(gameObject, tempoParaDestruir);
    }
}
