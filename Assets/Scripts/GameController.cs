using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;

public class GameController : MonoBehaviour
{
    public float dayDuration = 60.0f; // Délka dne v sekundách
    public float nightDuration = 60.0f; // Délka noci v sekundách
    public float transitionDuration = 5.0f; // Délka přechodu mezi dnem a nocí
    public Light2D globalLight; // Reference na Global Light 2D
    public float dayLightIntensity = 0.5f; // Intenzita světla během dne
    public float nightLightIntensity = 0.0f; // Intenzita světla během noci
    public TextMeshProUGUI dayText; // Reference na TextMeshProUGUI pro den a noc
    public TextMeshProUGUI timerText; // Reference na TextMeshProUGUI pro zobrazení zbývajícího času
    public TextMeshProUGUI waveText; // Reference na TextMeshProUGUI pro zobrazení čísla vlny
    public GameObject[] zombieSpawners; // Pole zombie spawnerů

    private int currentWave = 1;
    private const float minSpawnTime = 1.0f; // Minimální hodnota pro minTime
    private const float minMaxSpawnTime = 2.0f; // Minimální hodnota pro maxTime

    private void Start()
    {
        UpdateWaveText(); // Aktualizuj text pro aktuální vlnu hned na začátku
        StartCoroutine(DayNightCycle());
    }

    private IEnumerator DayNightCycle()
    {
        while (true)
        {
            // Den
            yield return StartCoroutine(SetDay());

            // Přechod na noc
            yield return StartCoroutine(TransitionToNight());

            // Noc
            yield return StartCoroutine(SetNight());

            // Přechod na den
            yield return StartCoroutine(TransitionToDay());

            // Inkrementace vlny
            currentWave++;
            UpdateWaveText();
            UpdateSpawnerIntervals();
        }
    }

    private IEnumerator SetDay()
    {
        if (dayText != null)
        {
            dayText.gameObject.SetActive(true);
            dayText.text = "Daytime";
        }

        foreach (GameObject spawner in zombieSpawners)
        {
            spawner.SetActive(false);
        }

        float remainingTime = dayDuration;
        while (remainingTime > 0)
        {
            if (timerText != null)
            {
                timerText.text = "Time left: " + Mathf.CeilToInt(remainingTime).ToString() + "s";
            }
            yield return new WaitForSeconds(1.0f);
            remainingTime -= 1.0f;
        }
    }

    private IEnumerator SetNight()
    {
        if (dayText != null)
        {
            dayText.gameObject.SetActive(true);
            dayText.text = "Nighttime";
        }

        foreach (GameObject spawner in zombieSpawners)
        {
            spawner.SetActive(true);
        }

        float remainingTime = nightDuration;
        while (remainingTime > 0)
        {
            if (timerText != null)
            {
                timerText.text = "Time left: " + Mathf.CeilToInt(remainingTime).ToString() + "s";
            }
            yield return new WaitForSeconds(1.0f);
            remainingTime -= 1.0f;
        }
    }

    private IEnumerator TransitionToNight()
    {
        float elapsedTime = 0.0f;
        float initialIntensity = globalLight.intensity;

        if (timerText != null)
        {
            timerText.text = "Getting dark...";
        }

        while (elapsedTime < transitionDuration)
        {
            globalLight.intensity = Mathf.Lerp(initialIntensity, nightLightIntensity, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        globalLight.intensity = nightLightIntensity;
    }

    private IEnumerator TransitionToDay()
    {
        float elapsedTime = 0.0f;
        float initialIntensity = globalLight.intensity;

        if (timerText != null)
        {
            timerText.text = "Sun is rising...";
        }

        while (elapsedTime < transitionDuration)
        {
            globalLight.intensity = Mathf.Lerp(initialIntensity, dayLightIntensity, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        globalLight.intensity = dayLightIntensity;
    }

    private void UpdateWaveText()
    {
        if (waveText != null)
        {
            waveText.text = "Wave: " + currentWave.ToString();
        }
    }

    private void UpdateSpawnerIntervals()
    {
        foreach (GameObject spawner in zombieSpawners)
        {
            ZombieSpawner zombieSpawner = spawner.GetComponent<ZombieSpawner>();
            if (zombieSpawner != null)
            {
                zombieSpawner.minTime = Mathf.Max(minSpawnTime, zombieSpawner.minTime - 0.5f);
                zombieSpawner.maxTime = Mathf.Max(minMaxSpawnTime, zombieSpawner.maxTime - 0.5f);
            }
        }
    }
}