using UnityEngine;
using System.Collections;

public class DayNightController : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject sunPrefab;
    public GameObject moonPrefab;

    [Header("Main Travel Time (Visible Screen Crossing)")]
    public float sunTravelTime = 20f;
    public float moonTravelTime = 20f;

    [Header("Entry Delay (Seconds Before Entering Screen)")]
    public float sunEntryDelay = 5f;
    public float moonEntryDelay = 5f;

    [Header("Extra Drift Time")]
    public float sunExtraDrift = 0f;
    public float moonExtraDrift = 0f;

    [Header("Night Settings")]
    public bool nightTime = false;
    public GameObject imageToDisable;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        StartCoroutine(DayNightLoop());
    }

    IEnumerator DayNightLoop()
    {
        while (true)
        {
            GameObject sun = Instantiate(sunPrefab);
            yield return StartCoroutine(MoveObject(sun, sunTravelTime, sunEntryDelay, sunExtraDrift, true));
            Destroy(sun);

            GameObject moon = Instantiate(moonPrefab);
            yield return StartCoroutine(MoveObject(moon, moonTravelTime, moonEntryDelay, moonExtraDrift, false));
            Destroy(moon);
        }
    }

    IEnumerator MoveObject(GameObject obj, float travelTime, float entryDelay, float extraDrift, bool isSun)
    {
        float screenHalfWidth = cam.orthographicSize * cam.aspect;
        float leftEdge = cam.transform.position.x - screenHalfWidth;
        float rightEdge = cam.transform.position.x + screenHalfWidth;

        float y = obj.transform.position.y;

        Vector3 visibleStart = new Vector3(leftEdge, y, obj.transform.position.z);
        Vector3 visibleEnd = new Vector3(rightEdge, y, obj.transform.position.z);

        float visibleDistance = Vector3.Distance(visibleStart, visibleEnd);
        float speed = visibleDistance / travelTime;

        Vector3 direction = (visibleEnd - visibleStart).normalized;

        // 🔥 THIS IS THE IMPORTANT PART
        // Spawn X seconds worth of movement away from visible start
        Vector3 spawnPosition = visibleStart - direction * speed * entryDelay;
        obj.transform.position = spawnPosition;

        float totalTime = travelTime + entryDelay;
        float timer = 0f;

        while (timer < totalTime)
        {
            timer += Time.deltaTime;
            obj.transform.position += direction * speed * Time.deltaTime;
            yield return null;
        }

        // Toggle state AFTER visible crossing
        if (isSun)
        {
            nightTime = true;
            if (imageToDisable != null)
                imageToDisable.SetActive(false);
        }
        else
        {
            nightTime = false;
            if (imageToDisable != null)
                imageToDisable.SetActive(true);
        }

        // Extra Drift
        float driftTimer = 0f;
        while (driftTimer < extraDrift)
        {
            driftTimer += Time.deltaTime;
            obj.transform.position += direction * speed * Time.deltaTime;
            yield return null;
        }
    }
}