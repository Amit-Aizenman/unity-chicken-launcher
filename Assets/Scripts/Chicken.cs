using System.Collections.Generic;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;

public class Chicken: MonoBehaviour, IPoolable
{
    [SerializeField] private LayerMask rayLaser;
    [SerializeField] private float rayDistance = 5;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 _rayOrigin;
    private Vector2 _rayDirection;
    private bool _rayHit;
    private Animator _animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _animator = this.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        _rayHit = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_rayHit)
        {
            _rayOrigin = transform.position;
            _rayDirection = transform.up;
            if (Physics2D.Raycast(_rayOrigin, _rayDirection, rayDistance, rayLaser))
            {
                FindAnyObjectByType<SoundManager>().Play("Ray Bak", true, true);
                transform.DOPunchScale(new Vector3(1, 1, 1), 0.5f);
                _rayHit = true;
            } 
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
        {
            rb.linearVelocity = Vector2.zero;
            rb.totalTorque = 0;
            rb.bodyType = RigidbodyType2D.Kinematic;

            _animator.SetTrigger("OnHit");
            FindAnyObjectByType<SoundManager>().Play("Explosion", false, true);
            Invoke("returnChicken", 0.4f);
        }
    }

    public void Launch(float forceAngle, float force, float torque)
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddTorque(torque);
        Vector3 dir = Quaternion.AngleAxis(forceAngle, Vector3.forward) * Vector3.right;
        rb.AddForce(dir*force);
    }
    public void Reset()
    {
        rb.linearVelocity = Vector2.zero;
        rb.rotation = 0;
        rb.bodyType = RigidbodyType2D.Dynamic;
        _rayHit = false;
        transform.localScale = new Vector3(1, 1, 1);
    }

    private void returnChicken()
    {
        ChickenPool.instance.Return(this);
    }
}
