using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPause : MonoBehaviour
{
    public static bool JuegoPausado = false;
    public GameObject MenuPausaUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (JuegoPausado)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        MenuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        JuegoPausado = false;
    }

    public void Pause()
    {
        MenuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        JuegoPausado = true;
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
