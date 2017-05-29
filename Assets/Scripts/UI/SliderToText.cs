using UnityEngine;
using UnityEngine.UI;

public class SliderToText : MonoBehaviour
{
    Text textUI;

    private void Awake()
    {
        textUI = GetComponent<Text>();
    }


    public void SetText(float value)
    {
        textUI.text = value.ToString();
    }
}
