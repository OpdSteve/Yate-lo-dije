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
        resetCollider = transform.Find("ResetCollider").GetComponent<Collider2D>();
        GetComponent<Rigidbody2D>().velocity = new Vector2(-scrollSpeed, 0f);
        Debug.Log(transform.Find("Agua2").position.x + " - " + transform.Find("Agua1").position.x);
        resetDistance = Mathf.Abs(transform.Find("Agua2").position.x - transform.Find("Agua1").position.x);
        Debug.Log(resetDistance);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!showEnd && collision.CompareTag("MainCamera"))
        {
            transform.position = new Vector2(-resetDistance, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (resetCollider.IsTouching(Camera.main.transform.Find("ScrollCollider").GetComponent<Collider2D>()) && !showEnd)
        //{
            
        //    Debug.Log(transform.position);
        //}
    }

    public void ShowEnd()
    {
        showEnd = true;
    }
}
