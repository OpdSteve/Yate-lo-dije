using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainDead : MonoBehaviour
{

    private int puntos;

    private TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Se reinicia el juego");
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0); //Suma uno a la escena inicial (Menu es 0)
        Debug.Log("Se va al menu");
    }
}
