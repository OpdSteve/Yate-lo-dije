using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 20f;
	public int damage = 40;
	public bool isPlayerBullet = false;
	public Rigidbody2D rb;
	//public Camera cam;
	//public GameObject impactEffect;
	// Use this for initialization
	void Start () {
		Vector3 camSpeed = Camera.main.GetComponent<Rigidbody2D>().velocity;
		if (isPlayerBullet)
			rb.velocity = transform.right * speed + camSpeed;
		else
			rb.velocity = -transform.right * speed + camSpeed;
	}

    private void Update()
    {
		if (Mathf.Abs(transform.position.y) > 10f)
			Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
	{
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
