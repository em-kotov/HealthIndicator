using UnityEngine;
using TMPro;

public class PlayerHealthTextDisplay : HealthDisplay
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private PlayerHealth _playerHealth;

    private string _fullHealthText = " / 100";

    private void Awake()
    {
        Health = _playerHealth;
    }

    override public void DisplayHealthPoints(float value)
    {
        _healthText.text = value.ToString() + _fullHealthText;
    }
}
