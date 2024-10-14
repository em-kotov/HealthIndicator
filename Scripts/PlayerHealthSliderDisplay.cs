using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSliderDisplay : HealthDisplay
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private PlayerHealth _playerHealth;

    private void Awake()
    {
        Health = _playerHealth;
        _healthSlider.interactable = false;
    }

    override public void DisplayHealthPoints(float value)
    {
        float minSliderValue = 0;
        float maxSliderValue = 1;
        float maxPoints = 100;

        _healthSlider.value = Mathf.Clamp(value / maxPoints, minSliderValue, maxSliderValue);
    }
}
