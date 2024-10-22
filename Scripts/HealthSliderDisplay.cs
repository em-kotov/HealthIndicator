using UnityEngine;
using UnityEngine.UI;

public class HealthSliderDisplay : HealthDisplay
{
    [SerializeField] protected Slider HealthSlider;

    protected void Awake()
    {
        HealthSlider.interactable = false;
    }

    override public void DisplayHealthPoints(float value)
    {
        HealthSlider.value = GetClampedValue(value);
    }

    protected float GetClampedValue(float value)
    {
        float minSliderValue = 0;
        float maxSliderValue = 1;
        float maxPoints = 100;

        return Mathf.Clamp(value / maxPoints, minSliderValue, maxSliderValue);
    }
}
