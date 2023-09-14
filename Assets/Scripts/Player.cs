using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] private Animator _animator;
    
    private Vector2 direction;
    private Rigidbody2D rb;
    private AudioSource audi;

    public bool inShadow = false;
    public float speedPlayer = 3;

    void Start()
    {
        audi = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");


        _animator.SetFloat("Horizontal", direction.x);
        _animator.SetFloat("Vertical", direction.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            _animator.SetFloat("HorizontalIdle", Input.GetAxisRaw("Horizontal"));
            _animator.SetFloat("VerticalIdle", Input.GetAxisRaw("Vertical"));
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speedPlayer * Time.fixedDeltaTime);
    }
}
