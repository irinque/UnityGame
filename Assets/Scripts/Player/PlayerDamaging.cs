using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaging : MonoBehaviour
{
    [SerializeField] private float _pushforce;
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            _animator.SetBool("IsDamaging", true);
            _rigidbody.AddForce(Vector2.up * _pushforce);
            _rigidbody.AddForce(Vector2.right * _pushforce);
        }
        else
        {
            _animator.SetBool("IsDamaging", false);
        }
    }
}