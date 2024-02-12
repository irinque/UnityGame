using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance { get; private set; }

    [SerializeField] private float _playerspeed;
    [SerializeField] private float _playerjumpforce;
    [SerializeField] private float _radiusgroundcheck;
    [SerializeField] private SpriteRenderer _playersprite;

    private bool _IsMoving;
    private bool _IsGrounded;

    public LayerMask _layerground;
    private Vector3 _input;
    public Transform _groundcheck;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    public void Walk()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), 0);
        transform.position += _input * _playerspeed * Time.deltaTime;
        _IsMoving = _input.x != 0 ? true : false;
        if (_input.x != 0)
        {
            _playersprite.flipX = _input.x > 0 ? false : true;
        }
        _animator.SetBool("IsMoving", _IsMoving);
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _IsGrounded)
        {
            _rigidbody.AddForce(Vector2.up * _playerjumpforce);
        }
    }
    public void GroundCheck()
    {
        _IsGrounded = Physics2D.OverlapCircle(_groundcheck.position, _radiusgroundcheck, _layerground);
        _animator.SetBool("IsGrounded", _IsGrounded);
    }

}
