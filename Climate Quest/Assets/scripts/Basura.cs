using UnityEngine;

public class Basura : MonoBehaviour
{
    private Collider colliderBasura; // Referencia al collider de la basura
    private ContenedorBasura contenedor; // Referencia al contenedor de basuras

    void Start()
    {
        colliderBasura = GetComponent<Collider>(); // Obtiene el componente Collider del GameObject de la basura
        contenedor = GetComponentInParent<ContenedorBasura>(); // Obtiene el contenedor de basuras
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el objeto es de la etiqueta "Player"
        {
            contenedor.RecogerBasura(this); // Llama al método RecogerBasura del contenedor
        }
    }

    // Método para recoger la basura
    public void Recoger()
    {
        colliderBasura.enabled = false; // Desactiva el collider para evitar que se recolecte la basura otra vez
        Destroy(gameObject); // Destruye la basura al recogerla (destruye el GameObject actual, que es la basura)
    }
}
