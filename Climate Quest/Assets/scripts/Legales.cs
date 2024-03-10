using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legales : MonoBehaviour
{
    public GameObject canvasLegal;
    public GameObject canvasDos;

    // Método para activar el canvas legal
    public void MostrarCanvasLegal()
    {
        canvasLegal.SetActive(true);
        canvasDos.SetActive(false);
    }

    // Método para desactivar el canvas legal
    public void OcultarCanvasLegal()
    {
        canvasLegal.SetActive(false);
        canvasDos.SetActive(true);
    }
}
