using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPosition : MonoBehaviour
{
    public bool isRightBorder;
    // Start is called before the first frame update
    void Start()
    {
        float multiplier = -0.5f;

        if (isRightBorder)
            multiplier *= -1;
        Vector3 CameraPosition = Camera.main.transform.position;
        transform.position = new Vector2(Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)),
            Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0f))) * multiplier, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Bullet bullet = hitInfo.GetComponent<Bullet>();
        if (bullet != null)
            Destroy(bullet.gameObject);

        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            if (isRightBorder)
            {
                Debug.Log("enemy activated");
                enemy.GetComponent<Enemy>().enabled = true;
                enemy.GetComponent<PrefabWeapon>().enabled = true;
            }
            else
            {
                Destroy(enemy.gameObject);
            }
        }

        //Instantiate(impactEffect, transform.position, transform.rotation);
    }
}
