using UnityEngine;

public class DayToNightMover : MonoBehaviour
{
    [Header("Timing")]
    public float travelTime = 10f; // Time in seconds to cross the screen

    [Header("Night Settings")]
    public bool nightTime = false;
    public GameObject imageToDisable;

    private float timer = 0f;
    private Vector3 startPos;
    private Vector3 endPos;

    void Start()
    {
        Camera cam = Camera.main;

        float screenHalfWidth = cam.orthographicSize * cam.aspect;

        // Get left and right edges of the screen
        float leftEdge = cam.transform.position.x - screenHalfWidth;
        float rightEdge = cam.transform.position.x + screenHalfWidth;

        float yPos = transform.position.y;

        startPos = new Vector3(leftEdge, yPos, transform.position.z);
        endPos = new Vector3(rightEdge, yPos, transform.position.z);

        transform.position = startPos;
    }

    void Update()
    {
        if (nightTime) return;

        timer += Time.deltaTime;

        float t = timer / travelTime;
        transform.position = Vector3.Lerp(startPos, endPos, t);

        if (t >= 1f)
        {
            nightTime = true;

            if (imageToDisable != null)
                imageToDisable.SetActive(false);
        }
    }
}