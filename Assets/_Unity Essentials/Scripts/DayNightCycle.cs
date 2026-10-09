using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Tooltip("Real-time seconds for one full day (360° rotation).")]
    [Min(0.1f)]
    public float secondsPerDay = 120f;

    [Tooltip("Starting time of day: 0 = sunrise, 0.25 = noon, 0.5 = sunset, 0.75 = midnight.")]
    [Range(0f, 1f)]
    public float startTimeOfDay = 0.1f;

    void Start()
    {
        // Set the starting angle
        transform.rotation = Quaternion.Euler(startTimeOfDay * 360f, -30f, 0f);
    }

    void Update()
    {
        float degreesPerSecond = 360f / secondsPerDay;
        transform.Rotate(Vector3.right, degreesPerSecond * Time.deltaTime, Space.World);
    }
}