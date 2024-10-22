using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Health _health;
    [SerializeField, Range(0f, 100f)] private float _maxPoints = 100;
    [SerializeField, Range(0f, 100f)] private float _addedPoints = 10;
    [SerializeField, Range(0f, 100f)] private float _lostPoints = 10;

    private float _minPoints = 0;

    private void Start()
    {
        _health.SetCurrentHealth(_maxPoints);
    }

    private void OnEnable()
    {
        _inputHandler.HitPressed += HandleHit;
        _inputHandler.HealPressed += HandleHeal;
    }

    private void OnDisable()
    {
        _inputHandler.HitPressed -= HandleHit;
        _inputHandler.HealPressed -= HandleHeal;
    }

    private void HandleHit()
    {
        _health.LoosePoints(_lostPoints, _minPoints, _maxPoints);
    }

    private void HandleHeal()
    {
        _health.AddPoints(_addedPoints, _minPoints, _maxPoints);
    }
}
