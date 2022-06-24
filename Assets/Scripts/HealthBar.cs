using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;

    private float MoveSpeed = 2f;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
        _slider.value = 1;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float value)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeValue(value));
    }

    public IEnumerator ChangeValue(float value)
    {
        float health = value / _player.MaxHealth;
        while(_slider.value != health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, MoveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
