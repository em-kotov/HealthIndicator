using UnityEngine;
using TMPro;

public class HealthTextDisplay : HealthDisplay
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Health _health;

    private string _fullHealthText = " / 100";

    private void Awake()
    {
        Health = _health;
    }

    override public void DisplayHealthPoints(float value)
    {
        _healthText.text = value.ToString() + _fullHealthText;
    }
}
