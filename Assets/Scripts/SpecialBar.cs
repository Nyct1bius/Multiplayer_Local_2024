using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxSpecial(float special)
    {
        slider.maxValue = special;
        slider.value = special;
    }

    public void SetSpecial(float special)
    {
        slider.value = special;
    }
}
