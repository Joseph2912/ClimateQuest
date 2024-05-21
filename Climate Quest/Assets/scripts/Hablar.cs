using UnityEngine;

public class Hablar : MonoBehaviour
{
    public GameObject canvasDialogo;
    public GameObject canvasBarraEspaciadora;

    void Update()
    {
        // Si se presiona la tecla de espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Mostrar el canvas legal
            canvasDialogo.SetActive(true);
            canvasBarraEspaciadora.SetActive(false);
        }
    }

    // Método para desactivar el canvas legal
    public void OcultarCanvasLegal()
    {
        canvasDialogo.SetActive(false);
    }
}
