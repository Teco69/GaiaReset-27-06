using UnityEngine;
[CreateAssetMenu(fileName ="DialogoPersonagens", menuName ="Dialogo/Dialogos")]
 
public class Dialogo : ScriptableObject
{
    public FalasDaConversa[] falas;
    public FalasSegundaOpc[] falasSegundaOpc;
    
}
[System.Serializable]
public class FalasDaConversa{
    public Personagem personagem;
    public int IdExpressao;
    [TextArea]
    public string[] textoFalas;
}
[System.Serializable]
public class FalasSegundaOpc{
    public Personagem personagem;
    public int IdExpressao;
    [TextArea]
    public string[] textoFalas2;
    
}