using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int health;

    public bool hasShield;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Drop"))
    //        Debug.Log("Drop cogido");
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Camera.main.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
        }
    }

    public void TakeDamage(int damage)
    {
        if (hasShield)
        {
            // deactivate shield prop
            hasShield = false;
            return;
        }
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
