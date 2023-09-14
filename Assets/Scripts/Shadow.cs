using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _srenderer;
    [SerializeField] private Player _player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _player.speedPlayer = 1;
            _srenderer.color = new Color(0.3207547f, 0.3207547f, 0.3207547f, 1f);
            _player.inShadow = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _player.speedPlayer = 3;
            _srenderer.color = new Color(1f, 1f, 1f, 1f);
            _player.inShadow = false;
        }
    }
}
