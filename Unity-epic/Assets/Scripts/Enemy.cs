using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 1f;
    [SerializeField]
    private float _movementSpeed = 1f;
    private Transform _player;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        _player = FindFirstObjectByType<PlayerBehavior>().transform;
    }

    private void Update()
    {
        HandleMovementTowards(_transform);
        HandleRotateTowardsPlayer(_transform);
    }

    private void HandleRotateTowardsPlayer(Transform transform)
    {
        transform.LookAt(_player.transform);
    }

    private void HandleMovementTowards(Transform transform)
    {
        transform.Translate(transform.forward * _movementSpeed * Time.deltaTime);
    }
}
