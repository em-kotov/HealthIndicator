using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] private float _maxPoints = 100;

    private float _points;
    private float _minPoints = 0;

    public event Action<float> PointsChanged;

    private void Start()
    {
        SetCurrentHealth(_maxPoints);
    }

    public void SetCurrentHealth(float points)
    {
        _points = points;
        InvokePointsChanged();
    }

    public void LoosePoints(float lostPoints)
    {
        if (IsNegative(lostPoints))
            return;

        SetCurrentHealth(GetClampedPoints(_points - lostPoints));
    }

    public void AddPoints(float addedPoints)
    {
        if (IsNegative(addedPoints))
            return;

        SetCurrentHealth(GetClampedPoints(_points + addedPoints));
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
