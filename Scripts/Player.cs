using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _inputHandler.HitPressed += _health.HandleHit;
        _inputHandler.HealPressed += _health.HandleHeal;
    }

    private void OnDisable()
    {
        _inputHandler.HitPressed -= _health.HandleHit;
        _inputHandler.HealPressed -= _health.HandleHeal;
    }
}
