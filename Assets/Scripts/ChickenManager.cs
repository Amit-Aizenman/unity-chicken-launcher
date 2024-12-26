using System;
using DG.Tweening;
using UnityEngine;

public class ChickenManager : MonoBehaviour
{
    [SerializeField] private LayerMask rayLaser;
    [SerializeField] float rayDistance = 5;
    private Vector2 _rayOrigin;
    private Vector2 _rayDirection;
    private bool _rayHit;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
                //sound BAK
                transform.DOPunchScale(new Vector3(1, 1, 1), 0.5f);
                Debug.Log("got hit");
                _rayHit = true;
            } 
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        throw new NotImplementedException();
    }
}
