using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DynamicPercent : MonoBehaviour
{
    public Slider veracityBar;
    public Text textPercent;
    public string[] textStates;
    public Text catchPhrase;
    public float increaseSpeed = 1f;

    void Start()
    {
        veracityBar.value = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(IncreaseBar(0));
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(IncreaseBar(50));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(IncreaseBar(100));
        }
    }

    IEnumerator IncreaseBar(int percentState)
    {
        float targetValue = percentState * 0.01f * veracityBar.maxValue;
        float distance = targetValue - veracityBar.value;

        while (veracityBar.value < targetValue)
        {
            veracityBar.value += increaseSpeed * Time.deltaTime;
            textPercent.text = Mathf.Round(veracityBar.value / veracityBar.maxValue * 100f) + " %";
            yield return null;
        }

        veracityBar.value = targetValue;
        textPercent.text = percentState + " %";

        // Mise à jour de catchPhrase une fois que la jauge s'est remplie
        catchPhrase.text = textStates[percentState / 50]; // textStates est indexé de 0 à 4 pour 0 à 100 %
    }
}
