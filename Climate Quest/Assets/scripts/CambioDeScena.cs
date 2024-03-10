using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeScena : MonoBehaviour
{
    public void IrNivel1()
    {
        SceneManager.LoadScene("Nivel#1");
    }

    public void IrNivel2()
    {
        SceneManager.LoadScene("Nivel#2");
    }

    public void IrNivel3()
    {
        SceneManager.LoadScene("Nivel#3");
    }

    public void Salir()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
