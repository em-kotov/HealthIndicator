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

    public virtual void LoosePoints(float lostPoints, float minPoints)
    {
        if (lostPoints < 0)
            return;

        Points -= lostPoints;

        if (Points < minPoints)
            Points = minPoints;

        InvokePointsChanged();
    }

    public virtual void AddPoints(float addedPoints, float maxPoints)
    {
        if (addedPoints < 0)
            return;

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
