using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject scoreUIGameObject;
    public GameObject healthUIGameObject;
    public GameObject playerGameObject;
    public int score = 0;
    public int destroyedFragatas;
    public int destroyedAcorazados;
    public int destroyedHelicopteros;
    public float[] dropProbabilities;
    public float enemySpeed;
    private Text scoreUI;
    private Text healthUI;
    // Start is called before the first frame update
    void Start()
    {
        scoreUI = scoreUIGameObject.GetComponent<Text>();
        healthUI = healthUIGameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = "Score: " + score.ToString();
        if (playerGameObject != null)
            healthUI.text = "Lives left: " + playerGameObject.GetComponent<PlayerController>().health.ToString();
        else
            healthUI.text = "Lives left: 0";
        if (Input.GetButtonDown("Cancel"))
            SceneManager.LoadScene(0);
    }
}
