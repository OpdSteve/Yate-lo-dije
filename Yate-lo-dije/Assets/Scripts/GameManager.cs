using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject scoreUI;
    public int score = 15;
    public int destroyedFragatas;
    public int destroyedAcorazados;
    public int destroyedHelicopteros;
    public float[] dropProbabilities;
    public float enemySpeed;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(scoreUI.GetComponent<TextMeshProUGUI>().text);
        scoreUI.GetComponent<TextMeshProUGUI>().SetText(score.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            SceneManager.LoadScene(0);
        //if ()
    }
}
