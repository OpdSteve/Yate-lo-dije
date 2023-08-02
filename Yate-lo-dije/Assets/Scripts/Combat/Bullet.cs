using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 20f;
	public int damage = 40;
	public bool isPlayerBullet = false;
	public Rigidbody2D rb;

	void Start () {
		if (isPlayerBullet)
			rb.velocity = transform.right * speed;
		else
			rb.velocity = -transform.right * speed;
	}

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
	{
		if (hitInfo.CompareTag("Despawner"))
			Destroy(gameObject);
		if (isPlayerBullet)
		{
			Enemy enemy = hitInfo.gameObject.GetComponent<Enemy>();
			if (enemy != null)
			{
				enemy.TakeDamage(damage);
				//Instantiate(impactEffect, transform.position, transform.rotation);
				Destroy(gameObject);
			}
			Bullet bullet = hitInfo.gameObject.GetComponent<Bullet>();
			if (bullet != null)
            {
				if (!bullet.isPlayerBullet)
                {
					Destroy(bullet.gameObject);
					Destroy(gameObject);
                }
					
            }
		}
		else // Enemy bullet
		{
			PlayerController player = hitInfo.gameObject.GetComponent<PlayerController>();
			if (player != null)
			{
				player.TakeDamage(damage);
				//Instantiate(impactEffect, transform.position, transform.rotation);
				Destroy(gameObject);
			}
		}
	}
}
