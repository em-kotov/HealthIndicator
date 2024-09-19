using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthSmoothSliderDisplay : HealthDisplay
{
    [SerializeField] private Slider _healthSlider;

    private Coroutine _smoothValueMoveCoroutine;

    private void Awake()
    {
        Health = GetComponent<PlayerHealth>();
        _healthSlider.interactable = false;
    }

    override public void DisplayHealthPoints(float value)
    {
        float minSliderValue = 0;
        float maxSliderValue = 1;
        float maxPoints = 100;

        float targetValue = Mathf.Clamp(value / maxPoints, minSliderValue, maxSliderValue);

        ActivateSmoothValueMove(targetValue);
    }

    private void ActivateSmoothValueMove(float targetValue)
    {
        if (_smoothValueMoveCoroutine != null)
            StopCoroutine(_smoothValueMoveCoroutine);
        
        _smoothValueMoveCoroutine = StartCoroutine(SmoothValueMove(_healthSlider.value, targetValue));
    }

    private IEnumerator SmoothValueMove(float currentValue, float targetValue)
    {
        float passedTime = 0f;
        float targetTime = 1.4f;

        while (passedTime < targetTime)
        {
            _healthSlider.value = Mathf.MoveTowards(currentValue, targetValue, passedTime / targetTime);
            passedTime += Time.deltaTime;
            yield return null;
        }

        _healthSlider.value = targetValue;
    }
}
