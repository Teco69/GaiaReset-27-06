using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamera : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimentação
    public float limitDistance = 10f; // Distância máxima que a câmera pode se mover para cada lado
    public ControleDialogo controle;
    public Dialogo dialogo;
    
    private float initialX;

    void Start()
    {
        initialX = transform.position.x; // Salva a posição inicial da câmera
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal"); // Entrada do jogador (A/D ou Setas Esquerda/Direita)
        float newX = transform.position.x + moveInput * moveSpeed * Time.deltaTime;
        
        // Garante que a câmera não ultrapasse os limites
        newX = Mathf.Clamp(newX, initialX - limitDistance, initialX + limitDistance);
        
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

    
    }

}
