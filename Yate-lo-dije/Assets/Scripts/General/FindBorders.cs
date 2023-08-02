using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindBorders : MonoBehaviour
{

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 CameraPosition = Camera.main.transform.position;
        transform.GetChild(2).position = new Vector2(0f, Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)),
            Camera.main.ScreenToWorldPoint(new Vector2(0f, Screen.height))) * -0.5f);

        transform.GetChild(3).position = new Vector2(0f, Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)),
            Camera.main.ScreenToWorldPoint(new Vector2(0f, Screen.height))) * 0.5f);

        transform.GetChild(4).position = new Vector2(Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)),
            Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0f))) * -0.5f, 0f);

        transform.GetChild(5).position = new Vector2(Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)),
            Camera.main.ScreenToWorldPoint(new Vector2(0f, Screen.width))) * 0.5f, 0f);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
