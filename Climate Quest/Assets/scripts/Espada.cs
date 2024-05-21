using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
   // public Chicken chicken;
    private int golpes = 0;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            //golpes++;
            other.GetComponent<Enemies>().RecibirGolpe();

        }
    }
    public void AumentarGolpes()
    {
        golpes++;
    }
}
