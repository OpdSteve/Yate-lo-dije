using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Reference rigidbody to alter its velocity
    private Rigidbody2D rb;
    // Reference camera rigidbody to access its velocity
    public Rigidbody2D camRb;
    // Reference max dist transform to access the max position of the boat
    public Transform maxDistTransform;

    // Reference max dist transform to access the max position of the boat
    public Transform minDistTransform;

    // Reference max dist transform to access the max position of the boat
    public Transform leftSideTransform;

    // Reference max dist transform to access the max position of the boat
    public Transform rightSideTransform;

    // Reference back collider

    public float fwdSpeedRate = 2f;
    public float bwdSpeedRate = 2f;
    public float sideSpeedRate = 2f;
    public float camSpeedOffset;

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
        rb.velocity = new Vector2(xSpeed + camRb.velocity.x * 2, ySpeed);
    }

    private float getRightSideSpeed()
    {
        float sideSpeed;
        float distToSide;

        distToSide = Mathf.Abs(transform.position.y - rightSideTransform.position.y);
        sideSpeed = sideSpeedRate * distToSide;

        return sideSpeed;
    }

    private float getLeftSideSpeed()
    {
        float sideSpeed;
        float distToSide;

        distToSide = Mathf.Abs(transform.position.y - leftSideTransform.position.y);
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
            distToMax = camSpeedOffset * camRb.velocity.x;
        fwdSpeed = fwdSpeedRate * distToMax;

        return fwdSpeed;
    }


}
