using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;

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
        _slider.DOValue(value / _player.MaxHealth, 1f);
    }
}
