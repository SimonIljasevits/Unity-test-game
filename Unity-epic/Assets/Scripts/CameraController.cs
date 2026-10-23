using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform _followSubject;
    [SerializeField]
    private float _followSpeed;
    [SerializeField]
    private Vector3 _offset;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _transform.position = _followSubject.position + _offset;
    }

    private void Update()
    { 
        _transform.position = Vector3.Lerp(_transform.position, _followSubject.position + _offset, _followSpeed * Time.deltaTime);
    }

    private void OnValidate()
    {
        if (_followSubject == null)
            return;
        transform.position = _followSubject.position + _offset;
    }
}
