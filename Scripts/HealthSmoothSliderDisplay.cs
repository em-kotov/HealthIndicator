using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthSmoothSliderDisplay : HealthDisplay
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Health _health;

    private Coroutine _smoothValueMoveCoroutine;

    private void Awake()
    {
        Health = _health;
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

    private IEnumerator SmoothValueMove(float startValue, float targetValue)
    {
        float passedTime = 0f;
        float targetTime = 0.6f;
        float clampedTime;

        while (passedTime < targetTime)
        {
            passedTime += Time.deltaTime;
            clampedTime = Mathf.Clamp01(passedTime / targetTime);
            _healthSlider.value = Mathf.Lerp(startValue, targetValue, clampedTime);
            yield return null;
        }

        _healthSlider.value = targetValue;
    }
}
