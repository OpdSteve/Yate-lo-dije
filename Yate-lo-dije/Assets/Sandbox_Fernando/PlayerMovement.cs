using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D camRb;
    public Transform maxDistTransform;
    public Transform minDistTransform;
    public Transform TopBorderTransform;
    public Transform BotBorderTransform;
    public float fwdSpeedRate = 2f;
    public float bwdSpeedRate = 2f;
    public float sideSpeedRate = 2f;
    public float speedDamper = 0.5f;
    public float dampChangeRate = 0.01f;
    public float minDamp = 0.5f;
    public float maxDamp = 0.5f;
    public int collisionDamage = 1;


    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private float fwdInput;
    private float sideInput;

    // Update is called once per frame
    void Update()
    {
        fwdInput = Input.GetAxisRaw("Forward");
        sideInput = Input.GetAxisRaw("Vertical");
        //float mouse = Input.mouseScrollDelta.y;
        //if (mouse != 0)
        //    ChangeSpeedDamper(mouse);
            
    }

    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Enemy"))
        {
            gameObject.GetComponent<PlayerController>().TakeDamage(collisionDamage);
            hitInfo.gameObject.GetComponent<Enemy>().TakeDamage(collisionDamage);
        }
        if (hitInfo.gameObject.CompareTag("Finish"))
        {
            Camera.main.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }
    }

    private void FixedUpdate()
    {
        float xSpeed = 0f;
        float ySpeed = 0f;
        if (fwdInput > 0f)
            xSpeed += getFwdSpeed();
        else
            xSpeed -= getBwdSpeed();

        if (sideInput > 0f)
            ySpeed += getLeftSideSpeed();
        else if (sideInput < 0f)
            ySpeed -= getRightSideSpeed();
        rb.velocity = new Vector2(xSpeed + Camera.main.GetComponent<runMap>().movementspeed, ySpeed);
    }

    private float getRightSideSpeed()
    {
        float sideSpeed;
        float distToSide;

        distToSide = Mathf.Abs(transform.position.y - BotBorderTransform.position.y);
        sideSpeed = sideSpeedRate * distToSide;

        return sideSpeed;
    }

    private float getLeftSideSpeed()
    {
        float sideSpeed;
        float distToSide;

        distToSide = Mathf.Abs(transform.position.y - TopBorderTransform.position.y);
        sideSpeed = sideSpeedRate * distToSide;

        return sideSpeed;
    }

    private float getBwdSpeed()
    {
        float bwdSpeed;
        float distToMin;

        distToMin = transform.position.x - minDistTransform.position.x;
        if (distToMin < 0)
            distToMin = 0;
        bwdSpeed = bwdSpeedRate * distToMin;
        return bwdSpeed;
    }

    private float getFwdSpeed()
    {
        float fwdSpeed;
        float distToMax;

        distToMax = maxDistTransform.position.x - transform.position.x;
        if (distToMax < 0)
            distToMax = 0;
        fwdSpeed = fwdSpeedRate * distToMax * speedDamper;

        return fwdSpeed;
    }

    //private void ChangeSpeedDamper(float mouse)
    //{
    //    if ((speedDamper <= minDamp && mouse < 0) || (speedDamper >= maxDamp && mouse > 0))
    //        return;
    //    speedDamper = speedDamper + dampChangeRate * mouse;
    //}
}
