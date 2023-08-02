using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPause : MonoBehaviour
{
    public static bool JuegoPausado;
    public GameObject MenuPausaUI;

    private void Start()
    {
        MenuPausaUI.SetActive(false);
        JuegoPausado = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (JuegoPausado == true)
            {
                Resume();
            }
            else if (JuegoPausado == false)
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
        Debug.Log("Se renauda el juego");
    }

    public void Pause()
    {
        MenuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        JuegoPausado = true;
        Debug.Log("Se pausa el juego");
    }

    public void Reiniciar()
    {
        Debug.Log("Se reinicia el juego");
        SceneManager.LoadScene(1);
    }

    public void SalirAlEscritorio()
    {
        Debug.Log("Cerrado");
        Application.Quit();
    }

    public void VolverAlMenu()
    {
        Debug.Log(0);
        SceneManager.LoadScene(0); //Suma uno a la escena inicial (Menu es 0)
    }
}
