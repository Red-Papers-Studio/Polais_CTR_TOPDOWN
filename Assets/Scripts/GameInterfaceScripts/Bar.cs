using UnityEngine.UI;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public Slider BarSlider;
    public Bar(float value)
    {
        BarSlider.value = value;
    }

    public void SetValue(float value)
    {
        BarSlider.value = value;
    }

    public void SetMaxValue(float maxValue)
    {
        BarSlider.maxValue = maxValue;
    }
}
