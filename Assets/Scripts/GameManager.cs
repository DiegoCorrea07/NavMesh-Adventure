using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public ControllerEnemy enemyPrefab; // Prefab del enemigo
    public Transform player;           // Referencia al jugador
    public Transform[] spawnPoints;    // Puntos de aparición de los enemigos

    private List<ControllerEnemy> enemies = new List<ControllerEnemy>(); // Lista de enemigos actuales
    private float gameTimer = 0f;      // Tiempo total de la partida
    private float spawnTimer = 0f;     // Tiempo para generar nuevos enemigos
    private float speedIncreaseTimer = 0f; // Tiempo para aumentar velocidad
    private int score = 0;             // Puntaje del jugador
    private int lastMilestone = 0;     // Último múltiplo de 100 alcanzado
    private float enemySpeed = 25f;   // Velocidad inicial de los enemigos
    private float maxSpeed = 100f;     // Velocidad máxima de los enemigos

    void Start()
    {
        // Crear el enemigo inicial
        SpawnEnemy();
    }

    void Update()
    {
        // Incrementar los temporizadores
        gameTimer += Time.deltaTime;
        spawnTimer += Time.deltaTime;
        speedIncreaseTimer += Time.deltaTime;

        // Incrementar velocidad del enemigo cada 10 segundos
        if (speedIncreaseTimer >= 10f)
        {
            if (enemySpeed < maxSpeed)
            {
                enemySpeed = Mathf.Min(enemySpeed + 25f, maxSpeed); // Aumentar velocidad
                foreach (var enemy in enemies)
                {
                    enemy.agent.speed = enemySpeed; // Actualizar velocidad de los enemigos actuales
                }
            }
            speedIncreaseTimer = 0f; // Reiniciar temporizador de aumento de velocidad
        }

        // Generar nuevos enemigos cada 20 segundos si la velocidad es 100
        if (enemySpeed >= maxSpeed && spawnTimer >= 10f)
        {
            SpawnEnemy();
            if (enemies.Count > 2) // Si hay más de 2 enemigos, elimina el más antiguo
            {
                RemoveOldestEnemy();
            }
            spawnTimer = 0f; // Reiniciar temporizador de spawn
        }

        // Actualizar el puntaje basado en el tiempo
        score = Mathf.FloorToInt(gameTimer*10);

        // Verificar si se alcanzó un nuevo múltiplo de 100
        if (score >= lastMilestone + 100)
        {
            lastMilestone += 100; // Actualizar el último múltiplo alcanzado
            SpawnEnemy();         // Generar un enemigo adicional
        }
    }

    void SpawnEnemy()
    {
        // Seleccionar un punto de aparición aleatorio
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instanciar un nuevo enemigo
        ControllerEnemy newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        newEnemy.player = player; // Asignar al jugador como objetivo

        // Configurar la velocidad del NavMeshAgent del enemigo recién generado
        newEnemy.agent.speed = enemySpeed;

        // Añadir el nuevo enemigo a la lista
        enemies.Add(newEnemy);
    }


    void RemoveOldestEnemy()
    {
        if (enemies.Count > 0)
        {
            ControllerEnemy oldestEnemy = enemies[0];
            enemies.RemoveAt(0); // Eliminarlo de la lista
            Destroy(oldestEnemy.gameObject); // Destruir el GameObject
        }
    }

    private void OnGUI()
    {
        // Mostrar el tiempo, el puntaje y la velocidad de los enemigos en pantalla
        GUI.Label(new Rect(10, 10, 200, 20), "Score: " + score);
        GUI.Label(new Rect(10, 30, 200, 20), "Time: " + Mathf.FloorToInt(gameTimer));
        GUI.Label(new Rect(10, 50, 200, 20), "Enemy Speed: " + enemySpeed);
    }
}
