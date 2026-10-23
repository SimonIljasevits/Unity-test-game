using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public event Action<int> OnCoinCollected;
    public event Action OnDamage;

    [SerializeField]
    private float _movementSpeed;

    private Rigidbody _rigidbody;
    private MovementInput _movementInput = new MovementInput();
    private int _coinAmount;

    public void CollectCoin() 
    {
        _coinAmount++;
        OnCoinCollected?.Invoke(_coinAmount);
    }

    public void CollectDamage() 
    {
        OnDamage?.Invoke();
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        OnCoinCollected += i => Debug.Log($"Coin collected! Now your count amount is {i}");
    }

    private void Update()
    {
        if (!_movementInput.HasInput())
            return;

        _rigidbody.AddForce(_movementInput.Axis * _movementSpeed);
    }
}

public class MovementInput
{
    public Vector3 Axis => new Vector3(GetHorizontal(), 0, GetVertical());

    public float GetHorizontal() => Input.GetAxisRaw("Horizontal");
    public float GetVertical() => Input.GetAxisRaw("Vertical");

    public bool HasInput() => GetHorizontal() != 0 || GetVertical() != 0;
} 
