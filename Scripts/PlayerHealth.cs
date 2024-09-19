using System;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class PlayerHealth : Health
{
    private InputHandler _inputHandler;
    private float _maxPoints = 100;
    private float _addedPoints = 10;

    public event Action LostPoints;
    public event Action HasDied;

    private void Awake()
    {
        _inputHandler = GetComponent<InputHandler>();
        Points = _maxPoints;
    }

    private void OnEnable()
    {
        _inputHandler.IsHitPressed += HandleHit;
        _inputHandler.IsHealPressed += HandleHeal;
    }

    private void OnDisable()
    {
        _inputHandler.IsHitPressed -= HandleHit;
        _inputHandler.IsHealPressed -= HandleHeal;
    }

    private void HandleHit()
    {
        LoosePoints();
        LostPoints?.Invoke();
        HasPoints();
    }

    private void HandleHeal()
    {
        AddPoints(_addedPoints, _maxPoints);
    }

    private void HasPoints()
    {
        if (Points <= 0)
            HasDied?.Invoke();
    }
}
