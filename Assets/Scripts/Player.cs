using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;

    private float _currentHealth;
    private float _minHealthAmount = 0;

    public event UnityAction<float> HealthChanged;

    public float MaxHealth => _maxHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void ApplyHealOrDamage(float value)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + value, _minHealthAmount, _maxHealth);
        HealthChanged?.Invoke(_currentHealth);
    }
}
