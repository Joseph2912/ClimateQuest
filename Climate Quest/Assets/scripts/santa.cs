using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class santa : MonoBehaviour
{
    public float velocidadMovimiento = 5f; // Velocidad de movimiento normal
    public float velocidadCorrer = 10f; // Velocidad de movimiento al correr
    public Animator anim;
    public BoxCollider colliderEspada;
    public Espada espada;

    public Slider healthSlider; // Referencia al Slider de salud
    public int maxHealth = 4; // Salud máxima del jugador
    private int currentHealth; // Salud actual del jugador

    public Gradient healthGradient; // Gradiente de colores para la salud

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth; // Inicializar la salud actual con la máxima salud
        UpdateHealthUI(); // Actualizar el slider de salud al inicio
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 representa el botón izquierdo del mouse
        {
            anim.SetBool("golpe", true);
        }
        else
        {
            anim.SetBool("golpe", false);
        }
    }

    public void PrenderCollider()
    {
        espada.AumentarGolpes();
        colliderEspada.enabled = true;
    }

    public void ApagarCollider()
    {
        colliderEspada.enabled = false;
    }

    private void FixedUpdate()
    {
        float movimientoHorizontal = Input.GetAxisRaw("Vertical");
        float movimientoVertical = -Input.GetAxisRaw("Horizontal");
        anim.SetFloat("VelX", movimientoHorizontal);
        anim.SetFloat("VelY", movimientoVertical);

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical).normalized;

        if (movimiento != Vector3.zero)
        {
            float velocidadActual = Input.GetKey(KeyCode.LeftShift) ? velocidadCorrer : velocidadMovimiento;
            transform.Translate(movimiento * velocidadActual * Time.fixedDeltaTime, Space.World);

            Quaternion rotacionDeseada = Quaternion.LookRotation(movimiento);
            transform.rotation = rotacionDeseada;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reducir la salud del jugador
        UpdateHealthUI(); // Actualizar el slider de salud
        if (currentHealth <= 0)
        {
            Die(); // Llamar a la función de muerte si la salud del jugador es igual o menor a cero
        }
    }

    void Die()
    {
        // Reiniciar la escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth; // Actualizar el valor del slider de salud
        healthSlider.fillRect.GetComponent<Image>().color = healthGradient.Evaluate(healthSlider.normalizedValue);
    }
}
