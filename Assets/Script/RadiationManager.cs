using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RadiationManager : MonoBehaviour
{
    public float radiacao = 0f;
    public float radiacaoMax = 100f;
    public float taxaAumento = 10f;
    public float taxaReducao = 20f;
    public bool estaNaZonaSegura = false;
    public bool estaSendoExposto = false;
    public string cenaAoMorrer;

    public Image imagemOverlay; // <- arraste aqui no Inspector

    private bool morreu = false;

    void Start()
    {
        radiacao = GameData.nivelDeRadiacao;
    }

    void Update()
    {
        if (estaSendoExposto && !estaNaZonaSegura)
        {
            radiacao += taxaAumento * Time.deltaTime;
        }
        else if (estaNaZonaSegura && radiacao > 0)
        {
            radiacao -= taxaReducao * Time.deltaTime;
        }

        radiacao = Mathf.Clamp(radiacao, 0f, radiacaoMax);
        GameData.nivelDeRadiacao = radiacao;

        // Transparência proporcional à radiação
        if (imagemOverlay != null)
        {
            float alpha = radiacao / radiacaoMax;
            Color corAtual = imagemOverlay.color;
            corAtual.a = Mathf.Clamp01(alpha);
            imagemOverlay.color = corAtual;
        }

        if (radiacao >= radiacaoMax && !morreu)
        {
            morreu = true;
            GameData.nivelDeRadiacao = 0f;
            SceneManager.LoadScene(cenaAoMorrer);
        }
    }
}
