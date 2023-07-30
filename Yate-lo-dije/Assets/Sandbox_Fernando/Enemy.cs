using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public enum EnemyType
	{
		Fragata,
		Acorazado,
		Helicoptero
	}
	[SerializeField]
	private EnemyType enemyType = EnemyType.Fragata;
	public int health = 100;
	public GameObject drop;
	private GameObject gm;
	private float velocity;

	//public GameObject deathEffect;

    private void Start()
    {
		gm = GameObject.Find("GameManager");
		velocity = gm.GetComponent<GameManager>().enemySpeed;
		Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
		rb.velocity = Camera.main.GetComponent<Rigidbody2D>().velocity - new Vector2(velocity, 0f);
	}

    public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die ()
	{
		//Instantiate(deathEffect, transform.position, Quaternion.identity);
		if (Random.value < gm.GetComponent<GameManager>().dropProbabilities[(int)enemyType])
        {
			GameObject newDrop = Instantiate(drop, transform.position, Quaternion.identity);
			newDrop.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        }
		Destroy(gameObject);
	}

}
