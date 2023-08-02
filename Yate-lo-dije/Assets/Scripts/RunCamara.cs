using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runMap : MonoBehaviour
{
    // Variable
    public float movementspeed = 1f;
    public float acceleration = 1f;
    public float startAcceleratingTime = 1f;
    public GameObject player;
    [SerializeField] private float playerScaleDuration = 1f;
    [SerializeField] private float delayTime = 2f;

    private Transform targetTransformPlayer;
    private Vector3 targetScalePlayer;
    private Vector3 initialScalePlayer;
    private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        targetTransformPlayer = player.transform;
        targetScalePlayer = targetTransformPlayer.localScale;
        initialScalePlayer = targetTransformPlayer.localScale * 5;
        targetTransformPlayer.localScale = initialScalePlayer;
        rb = gameObject.GetComponent<Rigidbody2D>();
        Invoke("StartAccelerating", startAcceleratingTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }

    private void StartAccelerating()
    {
        StartCoroutine(Accelerate(rb, new Vector3(0f,0f,0f), new Vector3(movementspeed, 0f, 0f), acceleration));
    }

    private IEnumerator Accelerate(Rigidbody2D rb, Vector3 initialVelocity, Vector3 targetVelocity, float transitionDuration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < transitionDuration)
        {
            // Calculate the current scale based on the lerp value
            float t = elapsedTime / transitionDuration;
            Vector3 currentVelocity = Vector3.Lerp(initialVelocity, targetVelocity, t);

            // Apply the current scale to the object
            rb.velocity = currentVelocity;

            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the final scale is precisely the target scale to avoid rounding errors
        rb.velocity = targetVelocity;
        player.GetComponent<PlayerMovement>().enabled = true;
        Invoke("StartScaling", delayTime);
    }

    private void StartScaling()
    {
        StartCoroutine(ScaleOverTime(targetTransformPlayer, initialScalePlayer, targetScalePlayer));
    }

    private IEnumerator ScaleOverTime(Transform targetTransform, Vector3 initialScale, Vector3 targetScale)
    {
        float elapsedTime = 0f;
        while (elapsedTime < playerScaleDuration)
        {
            // Calculate the current scale based on the lerp value
            float t = elapsedTime / playerScaleDuration;
            Vector3 currentScale = Vector3.Lerp(initialScale, targetScale, t);

            // Apply the current scale to the object
            targetTransform.localScale = currentScale;

            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the final scale is precisely the target scale to avoid rounding errors
        targetTransform.localScale = targetScale;
    }
}
