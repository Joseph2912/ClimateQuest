using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    public float wanderRadius = 10f; // Radius for random wandering
    public float chaseRadius = 15f; // Radius within which the enemy will start chasing the player
    public float attackRadius = 2f; // Radius within which the enemy will attack the player
    public float wanderTimer = 5f; // Time to wait before choosing a new wander target

    private Transform player; // Reference to the player's transform
    private NavMeshAgent agent; // Reference to the NavMeshAgent component
    private float timer; // Timer to control wandering

    [SerializeField] private int golpesRecibidos = 0;
    public int damagePerHit = 1; // Daño por cada golpe de la gallina

    private santa jugador; // Referencia al jugador
    private Animator animator; // Referencia al componente Animator
    public AnimationClip dieClip;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Assumes the player has the tag "Player"
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        jugador = player.gameObject.GetComponent<santa>(); // Obtener el componente santa del jugador
        animator = GetComponent<Animator>(); // Obtener el componente Animator
    }

    void Update()
    {
        timer += Time.deltaTime;

        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= attackRadius)
        {
            // Attack the player
            Attack();
        }
        else if (distanceToPlayer <= chaseRadius)
        {
            // Chase the player
            Chase();
        }
        else
        {
            // Wander around randomly
            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }
        }
    }

    void Chase()
    {
        agent.SetDestination(player.position);
    }

    void Attack()
    {
        // Implement attack logic here
        Debug.Log("Attacking the player!");
        // You might want to stop the enemy from moving while attacking
        agent.SetDestination(transform.position);
        animator.SetTrigger("Attack"); // Cambiar a la animación de ataque
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Verificar si la gallina golpea al jugador
        {
            jugador.TakeDamage(damagePerHit); // Llamar al método TakeDamage del jugador para causarle daño
        }
    }

    public void RecibirGolpe()
    {
        golpesRecibidos++;

        if (golpesRecibidos >= 2) // Verificar si el enemigo ha recibido 2 golpes
        {
            Debug.Log("Enemigo eliminado tras recibir 2 golpes.");
            agent.SetDestination(transform.position);
            animator.SetTrigger("Die");
            Destroy(this.gameObject, dieClip.length); // Destruir al enemigo al recibir 2 golpes
        }
    }
}
