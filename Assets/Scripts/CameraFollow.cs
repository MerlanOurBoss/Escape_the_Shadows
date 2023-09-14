using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerTarget;
    [SerializeField] private float _smoothing;

    [SerializeField] private Vector2 _maxPos;
    [SerializeField] private Vector2 _minPos;


    private void FixedUpdate()
    {
        if (transform.position != _playerTarget.position)
        {
            Vector2 targetPos = new Vector2(_playerTarget.position.x, _playerTarget.position.y);

            targetPos.x = Mathf.Clamp(targetPos.x, _minPos.x, _maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, _minPos.y, _maxPos.y);

            transform.position = Vector2.Lerp(transform.position, targetPos, _smoothing);
        }
    }
}
