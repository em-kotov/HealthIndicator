using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    protected float Points;

    public event Action<float> PointsChanged;

    private void Start()
    {
        InvokePointsChanged();
    }

    public virtual void LoosePoints()
    {
        float lostPoints = 10;
        float minPoints = 0;

        Points -= lostPoints;

        if (Points < minPoints)
            Points = minPoints;

        InvokePointsChanged();
    }

    public virtual void AddPoints(float addedPoints, float maxPoints)
    {
        Points += addedPoints;

        if (Points > maxPoints)
            Points = maxPoints;

        InvokePointsChanged();
    }

    private void InvokePointsChanged()
    {
        PointsChanged?.Invoke(Points);
    }
}
