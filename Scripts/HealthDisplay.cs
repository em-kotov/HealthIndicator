using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    protected Health Health;

    public virtual void OnEnable()
    {
        Health.PointsChanged += DisplayHealthPoints;
    }

    public virtual void OnDisable()
    {
        Health.PointsChanged -= DisplayHealthPoints;
    }

    public virtual void DisplayHealthPoints(float value) { }
}
