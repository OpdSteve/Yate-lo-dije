using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runMap : MonoBehaviour
{
    // Variable
    public float movementspeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(movementspeed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }
}
