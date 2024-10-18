using UnityEngine;
using UnityEngine.UI;

public class HealthSliderDisplay : HealthDisplay
{
    [SerializeField] protected Slider _healthSlider;

    protected void Awake()
    {
        _healthSlider.interactable = false;
    }

    override public void DisplayHealthPoints(float value)
    {
        _healthSlider.value = GetClampedValue(value);
    }

    protected float GetClampedValue(float value)
    {
        float minSliderValue = 0;
        float maxSliderValue = 1;
        float maxPoints = 100;

        return Mathf.Clamp(value / maxPoints, minSliderValue, maxSliderValue);
    }
}
