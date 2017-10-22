using UnityEngine;
using System.Collections;

public class DayNightController : MonoBehaviour {
    public Light sun;
    public ParticleSystem snow;
    public ParticleSystem rain;

    const float DAY = 2 * Mathf.PI;

    bool night = false;
    bool snowing = false;

    public float secondsInFullDay = 50f;

    [Range(0, 2 * Mathf.PI)]
    public float currentTimeOfDay = 0;

    float timeMultiplier = 10f;

    public Color color;

    float sunInitialIntensity;

	// Use this for initialization
	void Start () {
        sunInitialIntensity = sun.intensity;
	}
	
	// Update is called once per frame
	void Update () {
        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
        sun.transform.localRotation = Quaternion.Euler(currentTimeOfDay / DAY * 180f, 150f, 0);
        sun.intensity = 2f + Mathf.Sin(currentTimeOfDay - Mathf.PI / 2);

        if (currentTimeOfDay >= DAY)
        {
            currentTimeOfDay = 0;
            night = !night;
        }

        if (!night)
        {
            color = new Color(1f, Mathf.Clamp01(1f + Mathf.Sin(currentTimeOfDay - Mathf.PI / 2) / 2), Mathf.Clamp01(1f + Mathf.Sin(currentTimeOfDay - Mathf.PI / 2)));
            if(snowing == false)
            {
                snowing = true;
                snow.Play();
                rain.Stop();
            }

        }
        else
        {
            color = new Color(0f, 0.2f, 1f);
            if(snowing == true)
            {
                snowing = false;
                rain.Play();
                snow.Stop();
            }
        }
        sun.color = Color.Lerp(sun.color, color, Time.deltaTime * timeMultiplier);

    }
}
