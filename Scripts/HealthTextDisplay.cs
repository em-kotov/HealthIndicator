using UnityEngine;
using TMPro;

public class HealthTextDisplay : HealthDisplay
{
    [SerializeField] private TextMeshProUGUI _healthText;

    private string _fullHealthText = " / 100";

    override public void DisplayHealthPoints(float value)
    {
        _healthText.text = value.ToString() + _fullHealthText;
    }
}
