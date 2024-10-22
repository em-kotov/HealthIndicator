using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _points;

    public event Action<float> PointsChanged;

    public void SetCurrentHealth(float points)
    {
        _points = points;
        InvokePointsChanged();
    }

    public void LoosePoints(float lostPoints, float minPoints, float maxPoints)
    {
        if (IsNegative(lostPoints))
            return;

        SetCurrentHealth(GetClampedPoints(_points - lostPoints, minPoints, maxPoints));
    }

    public void AddPoints(float addedPoints, float minPoints, float maxPoints)
    {
        if (IsNegative(addedPoints))
            return;

        SetCurrentHealth(GetClampedPoints(_points + addedPoints, minPoints, maxPoints));
    }

    private float GetClampedPoints(float points, float minPoints, float maxPoints)
    {
        return Mathf.Clamp(points, minPoints, maxPoints);
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
