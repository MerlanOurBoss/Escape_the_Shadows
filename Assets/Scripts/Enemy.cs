using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _patrolPoints;
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _chaseDistance;
    [SerializeField] private Player _player;
    [SerializeField] private Animator _animator;

    private Vector2 dir;
    private Transform target;
    private int currentPatrolPointIndex = 0; 
    private bool isChasing = false;

    private void Start()
    {
        target = _patrolPoints[0];
    }

    private void Update()
    {
        _animator.SetFloat("Horizontal", dir.x);
        _animator.SetFloat("Vertical", dir.y);

        if (!isChasing)
        {
            dir = target.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            dir.Normalize();


            Patrol();
        }
        else if (_player.inShadow == false)
        {
            dir = _player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            dir.Normalize();

            Chase();
        }
    }

    private void FixedUpdate()
    {
        if (_player.inShadow == true)
        {
            isChasing = false;
        }


    }
    private void Patrol()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (distanceToTarget < 0.1f)
        {
            currentPatrolPointIndex = (currentPatrolPointIndex + 1) % _patrolPoints.Length;
            target = _patrolPoints[currentPatrolPointIndex];
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, _enemySpeed * Time.deltaTime);
    }

    private void Chase()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.transform.position);

        if (distanceToPlayer < _chaseDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _enemySpeed * Time.deltaTime);
        }
        else
        {
            isChasing = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasing = false;
        }
    }
}
