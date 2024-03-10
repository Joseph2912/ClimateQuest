using UnityEngine;

public class Hablar : MonoBehaviour
{
    public GameObject canvasLegal;

    void Update()
    {
        // Si se presiona la tecla de espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Mostrar el canvas legal
            canvasLegal.SetActive(true);
        }
    }

    // Método para desactivar el canvas legal
    public void OcultarCanvasLegal()
    {
        canvasLegal.SetActive(false);
    }
}
