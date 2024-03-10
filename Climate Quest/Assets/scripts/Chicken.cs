using UnityEngine;

public class Chicken : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del enemigo
    public float smoothness = 0.5f; // Suavidad del movimiento
    public float minChaseDistance = 30f; // Distancia m�nima para iniciar la persecuci�n

    private Transform player; // Referencia al jugador
    private Vector3 randomDirection; // Direcci�n aleatoria para moverse cuando no est� persiguiendo al jugador
    [SerializeField] private int golpesRecibidos = 0;
    private bool golpe = false;
    public int damagePerHit = 1; // Da�o por cada golpe de la gallina

    private santa jugador; // Referencia al jugador

    public void RecibirGolpe()
    {
        golpesRecibidos++;

        if (golpesRecibidos >= 2) // Verificar si el enemigo ha recibido 2 golpes
        {
            Debug.Log("Enemigo eliminado tras recibir 2 golpes.");
            Destroy(this.gameObject); // Destruir al enemigo al recibir 2 golpes
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Buscar al jugador por su etiqueta
        GenerateRandomDirection();
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<santa>(); // Obtener el componente santa del jugador
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= minChaseDistance)
        {
            MoveTowardsPlayer();
        }
        else
        {
            MoveRandomly();
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 targetPosition = player.position;
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime); // Interpolaci�n suave hacia la posici�n del jugador
        transform.rotation = Quaternion.LookRotation(moveDirection); // Orientar al enemigo hacia la direcci�n de movimiento
    }

    void MoveRandomly()
    {
        transform.Translate(randomDirection * speed * Time.deltaTime); // Mover al enemigo en una direcci�n aleatoria
        transform.rotation = Quaternion.LookRotation(randomDirection); // Orientar al enemigo hacia la direcci�n aleatoria
    }

    void GenerateRandomDirection()
    {
        randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized; // Generar una direcci�n aleatoria normalizada
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            randomDirection = Vector3.Reflect(randomDirection, collision.contacts[0].normal).normalized;
            return;
        }
        if (collision.gameObject.CompareTag("Player")) // Verificar si la gallina golpea al jugador
        {
            jugador.TakeDamage(damagePerHit); // Llamar al m�todo TakeDamage del jugador para causarle da�o
        }
    }
}
