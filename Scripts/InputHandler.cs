using System;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Button _hitButton;
    [SerializeField] private Button _healButton;

    public event Action IsHitPressed;
    public event Action IsHealPressed;

    private void OnEnable()
    {
        _hitButton.onClick.AddListener(() => IsHitPressed?.Invoke());
        _healButton.onClick.AddListener(() => IsHealPressed?.Invoke());
    }

    private void OnDisable()
    {
        _hitButton.onClick.RemoveListener(() => IsHitPressed?.Invoke());
        _healButton.onClick.RemoveListener(() => IsHealPressed?.Invoke());
    }
}
