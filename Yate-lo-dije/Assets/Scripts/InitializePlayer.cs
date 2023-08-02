using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float transitionDuration = 1f;
    [SerializeField] private float delayTime = 2f;

    private Vector3 initialScale;
    private Vector3 targetScale;

    void Start()
    {
        initialScale = transform.localScale;
        targetScale = targetTransform.localScale;
        Invoke("StartScaling", delayTime);
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    private void StartScaling()
    {
        StartCoroutine(ScaleOverTime());
    }

    private IEnumerator ScaleOverTime()
    {
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            // Calculate the current scale based on the lerp value
            float t = elapsedTime / transitionDuration;
            Vector3 currentScale = Vector3.Lerp(initialScale, targetScale, t);

            // Apply the current scale to the object
            transform.localScale = currentScale;

            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the final scale is precisely the target scale to avoid rounding errors
        transform.localScale = targetScale;
    }
}
