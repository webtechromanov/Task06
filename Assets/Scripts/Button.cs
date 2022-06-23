using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _amount;

    public void OnButtonClick()
    {
        _player.ApplyHealOrDamage(_amount);
    }
}
