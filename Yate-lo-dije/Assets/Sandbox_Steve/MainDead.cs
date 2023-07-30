using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restos : MonoBehaviour
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

    public void Reiniciar()
    {
        SceneManager.LoadScene("Nombre escena / numero");
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Nombre escena / numero"); //Suma uno a la escena inicial (Menu es 0)
    }
}
