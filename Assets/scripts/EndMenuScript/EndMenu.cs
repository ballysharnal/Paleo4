using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public Slider slider;
    public Text evaluationText;
    // Start is called before the first frame update
    void Start()
    {
        SetCommentByValue();
    }

    private void SetCommentByValue() {
        slider.value = Random.Range(0, 100);
        Debug.Log(slider.value);
        if (slider != null && evaluationText != null) {
            if (slider.value < 20) {
                evaluationText.text = "Ce n'est pas fameux tout ça!";
            }
            else if (slider.value > 20 && slider.value < 70) {
                evaluationText.text = "Je ne ressemble pas vraiment à ça, si?";
            }
            else if (slider.value > 70) {
                evaluationText.text = "Oui! Voilà à quoi je ressemble, bien joué!";
            }

        }
        
    }

}
