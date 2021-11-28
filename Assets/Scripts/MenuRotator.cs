using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRotator : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _speed = 0.2f;
    [SerializeField] private float _edge = 70f;
    private bool _rotating = false;

    private void Update()
    {
        float currentY = transform.eulerAngles.y;
        float targetY = _targetTransform.eulerAngles.y;
        if (_rotating)
        {
            transform.RotateAround(transform.position, transform.up, Mathf.Lerp(currentY,_targetTransform.eulerAngles.y,_speed) - currentY);
            if (Mathf.Abs(currentY - targetY) < _edge)
                _rotating = false;
        }
        else if (Mathf.Abs(currentY - targetY) > _edge)
            _rotating = true;
    }
}
