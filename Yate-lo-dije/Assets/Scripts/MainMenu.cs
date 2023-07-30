using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuCreditosUI;

    private void Start()
    {
        MenuCreditosUI.SetActive(false);

    }
    public void StartGame ()
    {
        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        Debug.Log("Cerrado");
        Application.Quit();
    }
}

