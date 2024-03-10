using UnityEngine;
using UnityEngine.UI;

public class ContenedorBasura : MonoBehaviour
{
    private int basuraRecogida = 0; // Contador de basura recogida
    public Text contadorBasura; // Referencia al objeto de texto en el canvas
    public int maxBasura = 3; // Máximo número de basura que se pueden recoger
    public Basura[] basuras; // Arreglo para almacenar las basuras
    public GameObject portal;

    void Start()
    {
        // Inicializa el arreglo de basuras
        basuras = GetComponentsInChildren<Basura>();
        portal.SetActive(false);
    }

    // Método para recoger la basura
    public void RecogerBasura(Basura basura)
    {
        if (basuraRecogida < maxBasura)
        {
            basuraRecogida++;
            contadorBasura.text = "Basura recogida: " + basuraRecogida.ToString(); // Actualiza el texto del contador
            basura.Recoger(); // Llama al método Recoger de la basura correspondiente
            if (basuraRecogida == 3)
            {
                portal.SetActive(true);
            }
            
        }
        else
        {
            Debug.Log("¡Ya has recogido todas las basuras!");
          
        }
    }
}
