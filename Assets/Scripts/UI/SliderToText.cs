using UnityEngine;
using UnityEngine.UI;

public class SliderToText : MonoBehaviour
{
    public string Prefix;
    Text textUI;

    private void Awake()
    {
        textUI = GetComponent<Text>();
    }


    public void SetText(float value)
    {
        textUI.text = Prefix + value.ToString();
    }
}
