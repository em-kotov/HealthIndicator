using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Health _health;
    [SerializeField, Range(0f, 100f)] private float _addedPoints = 10;
    [SerializeField, Range(0f, 100f)] private float _lostPoints = 10;

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
        _health.LoosePoints(_lostPoints);
    }

    private void HandleHeal()
    {
        _health.AddPoints(_addedPoints);
    }
}
