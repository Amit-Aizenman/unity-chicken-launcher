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
    private bool _destroyFlag;
    
    void Awake()
    {
        _animator = this.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        _rayHit = false;

    }

    void Update()
    {
        if (!_rayHit)
        {
            _rayOrigin = transform.position;
            _rayDirection = rb.linearVelocity;
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
            DestoryChicken(0);
        }
    }

    public void Launch(float forceAngle, float force, float torque)
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddTorque(torque);
        Vector3 dir = Quaternion.AngleAxis(forceAngle, Vector3.forward) * Vector3.right;
        rb.AddForce(dir*force);
        CurrentChicken.CurrenChickenCounter++;

        
    }
    public void Reset()
    {
        rb.linearVelocity = Vector2.zero;
        rb.rotation = 0;
        rb.bodyType = RigidbodyType2D.Dynamic;
        _rayHit = false;
        transform.localScale = new Vector3(1, 1, 1);
        _destroyFlag = false;
    }

    private void ReturnChicken()
    {
        ChickenPool.Instance.Return(this);
    }

    private void DestoryChicken(int reset)
    {
        if (_destroyFlag == false)
        {
            _destroyFlag = true;
            rb.linearVelocity = Vector2.zero;
            rb.totalTorque = 0;
            rb.bodyType = RigidbodyType2D.Kinematic;
            _animator.SetTrigger("OnHit");
            FindAnyObjectByType<SoundManager>().Play("Explosion", false, true);
            Invoke("ReturnChicken", 0.4f);
            CurrentChicken.CurrenChickenCounter--;
        }
    }

    private void OnEnable()
    {
        GameEvents.DestroyAllChickens += DestoryChicken;
    }

    private void OnDisable()
    {
        GameEvents.DestroyAllChickens -= DestoryChicken;
    }
    
}
