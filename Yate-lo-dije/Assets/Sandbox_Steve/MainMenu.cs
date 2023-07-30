using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Suma uno a la escena inicial (Menu es 0)
    }

    public void Salir()
    {
        Debug.Log("Cerrado");
        Application.Quit();
    }
}
