using System;
using UnityEngine;

public class AttackInput : MonoBehaviour
{
    [SerializeField] private KeyCode _attackKey = KeyCode.Mouse0;

    public event Action AttackButtonIsPressed;

    private void Update()
    {
        if (Input.GetKeyDown(_attackKey))
        {
            AttackButtonIsPressed?.Invoke();
        }
    }
}