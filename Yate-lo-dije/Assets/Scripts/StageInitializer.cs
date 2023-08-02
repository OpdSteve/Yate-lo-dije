using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInitializer : MonoBehaviour
{
    public float[] stageTimes;
    public float subStageSeparation;
    [SerializeField] public GameObject gm;
    // Start is called before the first frame update
    private float enemySpeed;
    void Start()
    {
        enemySpeed = gm.GetComponent<GameManager>().enemySpeed;
        for (int i = 0; i < stageTimes.Length; i++)
        {
            initializeStagePosition(i);
        }
    }

    void    initializeStagePosition(int stageIndex)
    {
        float stagePosition = transform.position.x;
        float timeToStage = 0f;
        for (int i = 0; i < stageIndex; i++)
            timeToStage += stageTimes[i];
        stagePosition += Camera.main.GetComponent<runMap>().movementspeed * timeToStage;
        Transform currStage = transform.GetChild(stageIndex);
        currStage.position = new Vector3(stagePosition, 0f, 0f);
        if (currStage.childCount >= 1)
            currStage.GetChild(0).position = currStage.position;
        for (int j = 1; j < currStage.childCount; j++)
        {
            initializeSubStagePositions(j, currStage.GetChild(j), transform.GetChild(j - 1));
        }

    }

    void initializeSubStagePositions(int stageIndex, Transform subStage, Transform prevSubStage)
    {
        float newSeparation = 0f;
        float camSpeed = Camera.main.GetComponent<runMap>().movementspeed;
        float enemySpeed = gm.GetComponent<GameManager>().enemySpeed;
        float speedRatio = camSpeed / enemySpeed;
        newSeparation = subStageSeparation * speedRatio;
        subStage.position = new Vector2(prevSubStage.position.x + newSeparation, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
