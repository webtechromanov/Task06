using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health = 100;

    private float _currentHealth;
    private float _minHealthAmount = 0;

    public event UnityAction<float> HealthChanged;

    public float Health => _health;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void ApplyHealOrDamage(float value)
    {
        if (_currentHealth + value >= _minHealthAmount && _currentHealth + value <= _health)
        {
            _currentHealth += value;
            HealthChanged?.Invoke(_currentHealth);
        }
    }
}
