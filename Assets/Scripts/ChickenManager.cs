using DG.Tweening;
using UnityEngine;

public class ChickenManager: MonoBehaviour 
{
    [SerializeField] private LayerMask rayLaser;
    [SerializeField] private float rayDistance = 5;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 _rayOrigin;
    private Vector2 _rayDirection;
    private bool _rayHit;
    private Animator _animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
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
                FindAnyObjectByType<SoundManager>().Play("Ray Bak");
                transform.DOPunchScale(new Vector3(1, 1, 1), 0.5f);
                _rayHit = true;
            } 
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            _animator.SetTrigger("OnHit");
        }
    }
}
