using UnityEngine;
using TMPro;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerHealthTextDisplay : HealthDisplay
{
    [SerializeField] private TextMeshProUGUI _healthText;

    private string _fullHealthText = " / 100";

    private void Awake()
    {
        Health = GetComponent<PlayerHealth>();
    }

    override public void DisplayHealthPoints(float value)
    {
        _healthText.text = value.ToString() + _fullHealthText;
    }
}
