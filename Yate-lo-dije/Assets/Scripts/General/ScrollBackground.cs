using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float scrollSpeed = 10f;
    private bool showEnd = false;
    private Collider2D resetCollider;

    private float resetDistance;
    void Start()
    {
        resetCollider = transform.GetChild(4).GetComponent<Collider2D>();
        GetComponent<Rigidbody2D>().velocity = new Vector2(-scrollSpeed, 0f);
        resetDistance = (transform.GetChild(2).TransformDirection(Vector2.zero).x - transform.GetChild(1).TransformDirection(Vector2.zero).x) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (resetCollider.IsTouching(Camera.main.transform.GetChild(6).GetComponent<Collider2D>()) && !showEnd)
        {
            transform.position = new Vector2(resetDistance, 0f);
        }
    }

    public void ShowEnd()
    {
        showEnd = true;
    }
}
