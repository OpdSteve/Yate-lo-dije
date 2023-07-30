using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Variables
    public int maxHealth = 2;       // Máxima vida del enemigo
    public float cooldownTime = 4f; // Tiempo de espera entre disparos
    public int scoreValue = 300;    // Valor de puntuación al derrotar al enemigo
    public GameObject deathEffect;  // Efecto de muerte (animación o partículas)

    private int currentHealth;      // Vida actual del enemigo
    private bool canShoot = true;   // Indicador si el enemigo puede disparar o no

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Función para recibir un impacto
    public void TakeDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Función para manejar el cooldown de disparo
    private void ShootCooldown()
    {
        if (!canShoot)
        {
            cooldownTime -= Time.deltaTime;

            if (cooldownTime <= 0)
            {
                canShoot = true;
                cooldownTime = 4f;
            }
        }
    }

    // Función para derrotar al enemigo
    private void Die()
    {
        // Aumentar la puntuación
        //GameManager.Instance.AddScore(scoreValue);

        // Reproducir la animación de muerte (si existe)
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        // Destruir el objeto
        Destroy(gameObject);
    }
}
