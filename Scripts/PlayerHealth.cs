using System;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private InputHandler _inputHandler;

    private float _maxPoints = 100;

    public event Action LostPoints;
    public event Action HasDied;

    private void Awake()
    {
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
        float lostPoints = 10;
        float minPoints = 0;

        LoosePoints(lostPoints, minPoints);
        LostPoints?.Invoke();
        BecomeDead();
    }

    private void HandleHeal()
    {
        float addedPoints = 10;

        AddPoints(addedPoints, _maxPoints);
    }

    private bool IsDead()
    {
        return Points <= 0;
    }

    private void BecomeDead()
    {
        if (IsDead())
            HasDied?.Invoke();
    }
}
