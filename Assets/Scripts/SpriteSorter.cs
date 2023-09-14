using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    [SerializeField] private float _offset = 0;
    private int _sortingOrderBase = 0;
    private Renderer _newRenderer;

    private void Awake()
    {
        _newRenderer = GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        _newRenderer.sortingOrder = (int)(_sortingOrderBase - transform.position.y + _offset);
    }
}
