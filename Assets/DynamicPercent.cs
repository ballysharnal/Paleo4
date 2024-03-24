using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicPercent : MonoBehaviour
{
    public Slider veracityBar;
    public Text textPercent;
    public string[] textStates;
    public Text catchPhrase;

    public float increaseSpeed = 1f;



    // Start is called before the first frame update
    void Start()
    {
        textPercent.GetComponent<Text>().text = "0 %";
        veracityBar.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(IncreaseBar(0));
        }

        if (Input.GetKeyDown(KeyCode.S)) 
        {
            StartCoroutine(IncreaseBar(25));
        }
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(IncreaseBar(50));
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(IncreaseBar(75));
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(IncreaseBar(100));
        }
    }

    void ShowNewPercent(int percentState)
    {
        veracityBar.value = percentState;
        textPercent.GetComponent<Text>().text = veracityBar.value.ToString() + " %";
    }

    IEnumerator IncreaseBar(int percentState)
    {
        // Calculer la valeur cible de la jauge
        float targetValue = percentState * 0.01f * veracityBar.maxValue;

        // Calculer la distance à parcourir
        float distance = targetValue - veracityBar.value;

        while (veracityBar.value < targetValue)
        {
            veracityBar.value += increaseSpeed * Time.deltaTime;
            textPercent.text = Mathf.Round(veracityBar.value / veracityBar.maxValue * 100f) + " %";
            // Attendre la prochaine frame
            yield return null;
        }

        // Assurer que la jauge atteint exactement la valeur cible
        veracityBar.value = targetValue;
        // Mettre à jour le texte de pourcentage
        textPercent.text = percentState + " %";
        catchPhrase.text = textStates[percentState / 25];
    }
}
