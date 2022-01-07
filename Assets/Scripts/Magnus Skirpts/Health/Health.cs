using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    public event Action<int,int> OnHealthChanged;

    private int currentHealth;

    private void Start() => SetHealth(maxHealth);

    private void Update()
    {
        if  (!Keyboard.current.spaceKey.wasPressedThisFrame){ return; }
        DealDamage(10);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("You Died");
            Destroy(gameObject);
        }
    }

    private void DealDamage(int damageAmount)
    {
        SetHealth(Mathf.Max(currentHealth - damageAmount, 0));
    }

    private void SetHealth(int value)
    {
        currentHealth = value;
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }
}
