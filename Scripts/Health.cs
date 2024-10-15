using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField, Range(0f, 100f)] private float _maxPoints = 100;
    [SerializeField, Range(0f, 100f)] private float _addedPoints = 10;
    [SerializeField, Range(0f, 100f)] private float _lostPoints = 10;

    private float _minPoints = 0;
    private float _points;

    public event Action<float> PointsChanged;

    private void Awake()
    {
        _points = _maxPoints;
    }

    private void Start()
    {
        InvokePointsChanged();
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
        LoosePoints(_lostPoints);
    }

    private void HandleHeal()
    {
        AddPoints(_addedPoints);
    }

    private void LoosePoints(float lostPoints)
    {
        if (IsNegative(lostPoints))
            return;

        _points = GetPointsInRange(_points - lostPoints);
        InvokePointsChanged();
    }

    private void AddPoints(float addedPoints)
    {
        if (IsNegative(addedPoints))
            return;

        _points = GetPointsInRange(_points + addedPoints);
        InvokePointsChanged();
    }

    private float GetPointsInRange(float points)
    {
        return Mathf.Clamp(points, _minPoints, _maxPoints);
    }

    private bool IsNegative(float value)
    {
        return value < 0;
    }

    private void InvokePointsChanged()
    {
        PointsChanged?.Invoke(_points);
    }
}
