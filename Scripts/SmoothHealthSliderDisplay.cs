using UnityEngine;
using System.Collections;

public class SmoothHealthSliderDisplay : HealthSliderDisplay
{
    private Coroutine _smoothValueMoveCoroutine;

    override public void DisplayHealthPoints(float value)
    {
        ActivateSmoothValueMove(GetClampedValue(value));
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
