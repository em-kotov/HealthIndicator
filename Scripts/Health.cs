using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] private float _maxPoints = 100;
    [SerializeField, Range(0f, 100f)] private float _addedPoints = 10;
    [SerializeField, Range(0f, 100f)] private float _lostPoints = 10;

    private float _minPoints = 0;
    private float _points;

    public Action<float> PointsChanged;

    private void Start()
    {
        _points = _maxPoints;
        InvokePointsChanged();
    }

    public void HandleHit()
    {
        LoosePoints(_lostPoints);
    }

    public void HandleHeal()
    {
        AddPoints(_addedPoints);
    }

    private void LoosePoints(float lostPoints)
    {
        if (IsNegative(lostPoints))
            return;

        _points = GetClampedPoints(_points - lostPoints);
        InvokePointsChanged();
    }

    private void AddPoints(float addedPoints)
    {
        if (IsNegative(addedPoints))
            return;

        _points = GetClampedPoints(_points + addedPoints);
        InvokePointsChanged();
    }

    private float GetClampedPoints(float points)
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
