using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private int damage = 1;

    [Header("Boundaries")]
    [SerializeField]
    private float maxXBoundary = 3;
    [SerializeField]
    private float minXBoundary = -3;
    
    [SerializeField]
    private float maxYBoundary = 3;
    [SerializeField]
    private float minYBoundary = -3;

    private Vector2 direction = Vector2.up;

    private void Update()
    {
        transform.Translate(direction * (speed * Time.deltaTime), Space.World);

        if (transform.position.x >= maxXBoundary || transform.position.x <= minXBoundary ||
            transform.position.y >= maxYBoundary || transform.position.y <= minYBoundary)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out ItakeDamage element)) return;
        
        Destroy(gameObject);
        element.TakeDamage(damage);
    }
}