using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambioscena : MonoBehaviour

{
    // Método para ser llamado cuando se hace clic en el botón
    public void IrATutorial()
    {
        // Cargar la escena del tutorial por su nombre
        SceneManager.LoadScene("tutorial");
    }

    public void IrAJuego()
    {
        // Cargar la escena del tutorial por su nombre
        SceneManager.LoadScene("nivel1");
    }
}

