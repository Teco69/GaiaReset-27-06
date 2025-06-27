using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerapersoX : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimentação
    public float leftLimit = 2f; // Limite para a esquerda
    public float rightLimit = 5f; // Limite para a direita
     private Rigidbody2D rb;
     private Animator anim;
    
    private float initialX;
    public bool tacomachave;
    public bool comecoDeJogo = true;
   
    /*
       06/06 - 10:47: やったよ、マジでクールだ、ありえない
    */















    void Start()
    {
        
        
        initialX = transform.position.x; // Salva a posição inicial da câmera
        

        rb = GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();

        

        // Carrega posição salva (se existir)
        float x = PlayerPrefs.GetFloat("PlayerX", transform.position.x);
        float y = PlayerPrefs.GetFloat("PlayerY", transform.position.y);
        transform.position = new Vector3(x, y, 0f);
        tacomachave = false;
        /*if(comecoDeJogo == true){
            transform.position = new Vector3(-19.98f, -2.74f, 0f);
            comecoDeJogo = false;
        }*/
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal"); // Entrada do jogador (A/D ou Setas Esquerda/Direita)
        float newX = transform.position.x + moveInput * moveSpeed * Time.deltaTime;
        
        // Garante que a câmera não ultrapasse os limites personalizados
        newX = Mathf.Clamp(newX, initialX - leftLimit, initialX + rightLimit);
        
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        /*
        if(Input.GetKey(KeyCode.D)){
            anim.SetTrigger("AndarDireita");

        } else {
            anim.SetTrigger("PararDireita");
        }*/
        if(moveInput > 0){
            anim.SetBool("direita",true);
             anim.SetBool("esquerda",false);
        }
        else if (moveInput < 0){
             anim.SetBool("esquerda",true);
              anim.SetBool("direita",false);
        }else{
             anim.SetBool("direita",false);
             anim.SetBool("esquerda",false);
        }

        

    }
    public void SalvarPosicao()
    {
        PlayerPrefs.SetFloat("PlayerX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", transform.position.y);
        PlayerPrefs.Save();
        
    }

}