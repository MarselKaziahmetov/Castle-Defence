using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueChanger : MonoBehaviour
{
    public Slider slider;
    public Text valueText;

    public void OnChangeValue()
    {
        valueText.text = slider.value.ToString();
    }
}
