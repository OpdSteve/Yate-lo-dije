using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInitializer : MonoBehaviour
{
    public float[] stageTimes;
    // Start is called before the first frame update
    void Start()
    {
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
        transform.GetChild(stageIndex).position = new Vector3(stagePosition, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
