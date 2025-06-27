using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxDistancieXandY : MonoBehaviour
{
   
   public float maxDistanceX = 5f; // Limite máximo no eixo X
    public float maxDistanceY = 3f; // Limite máximo no eixo Y

    private Vector3 initialPosition;
    private Vector3 offset;
    private bool isDragging = false;

    void Start()
    {
        initialPosition = transform.position; // Salva a posição inicial do objeto
    }

    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            newPosition.z = transform.position.z; // Mantém a posição Z original

            // Aplica os limites baseados na posição inicial
            float clampedX = Mathf.Clamp(newPosition.x, initialPosition.x - maxDistanceX, initialPosition.x + maxDistanceX);
            float clampedY = Mathf.Clamp(newPosition.y, initialPosition.y - maxDistanceY, initialPosition.y + maxDistanceY);

            transform.position = new Vector3(clampedX, clampedY, newPosition.z);
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
}
