using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
 
public class ControleDialogo : MonoBehaviour
{
   public GameObject caixaDialogo;

   public GameObject botaoVoltar;
 
   public Image expressaoPersonagem;
 
   public TextMeshProUGUI nomePersonagem;
 
   public TextMeshProUGUI falaPersonagem;
 
   private Dialogo dialogoAtual;

   public int indiceFala=0; //controla qual dialogo está

   public string cena;
 
 
    int indice;
 
    Queue<string> filaDialogo;
 
    public void iniciarDialogo(Dialogo dialogo){
        caixaDialogo.SetActive(true);
        filaDialogo = new Queue<string>();
        dialogoAtual = dialogo;
        indice = 0;
        proximoDialogo();
    }
 
    public void proximoDialogo(){
        if (filaDialogo.Count == 0){
            if (indice < dialogoAtual.falas.Length){
                expressaoPersonagem.sprite = dialogoAtual.falas[indice].personagem.expressoesPersonagem[dialogoAtual.falas[indice].IdExpressao];
                expressaoPersonagem.SetNativeSize();
                nomePersonagem.text = dialogoAtual.falas[indice].personagem.NomePersonagem;
                foreach (string textoFalas in dialogoAtual.falas[indice].textoFalas){
                    filaDialogo.Enqueue(textoFalas);
                }
                indice++;
            }
            else
            {
                botaoVoltar.SetActive(true);
                caixaDialogo.SetActive(false);
                 indiceFala++; // quando chegar ao fim do dialogo , vai para o proximo
                return;
                
            }
        }
        falaPersonagem.text = filaDialogo.Dequeue();
    }
    public void trocarCena(){

        SceneManager.LoadScene(cena);

    }
}
