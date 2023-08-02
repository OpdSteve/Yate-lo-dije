using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("Nombre escena / numero");
    }

    public void SalirAlEscritorio()
    {
        Debug.Log("Cerrado");
        Application.Quit();
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Nombre escena / numero"); //Suma uno a la escena inicial (Menu es 0)
    }
}
