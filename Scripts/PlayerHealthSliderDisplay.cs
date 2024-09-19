using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSliderDisplay : HealthDisplay
{
   [SerializeField] private Slider _healthSlider;

    private void Awake()
    {
        Health = GetComponent<PlayerHealth>();
        _healthSlider.interactable = false;
    }

    override public void DisplayHealthPoints(float value)
    {
        float minSliderValue = 0;
        float maxSliderValue = 1;
        float maxPoints = 100;

        _healthSlider.value = Mathf.Clamp(value/maxPoints, minSliderValue, maxSliderValue);
    }
}
