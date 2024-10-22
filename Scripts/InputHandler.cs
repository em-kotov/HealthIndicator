using System;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Button _hitButton;
    [SerializeField] private Button _healButton;

    public event Action HitPressed;
    public event Action HealPressed;

    private void OnEnable()
    {
        _hitButton.onClick.AddListener(InvokeHitPressed);
        _healButton.onClick.AddListener(InvokeHealPressed);
    }

    private void OnDisable()
    {
        _hitButton.onClick.RemoveListener(InvokeHitPressed);
        _healButton.onClick.RemoveListener(InvokeHealPressed);
    }

    private void InvokeHitPressed()
    {
        HitPressed?.Invoke();
    }

    private void InvokeHealPressed()
    {
        HealPressed?.Invoke();
    }
}
