using System;
using _2DShooterGame.Scripts;
using UnityEngine;

[RequireComponent(typeof(Explosion))]
public class Enemy : MonoBehaviour, ItakeDamage
{
    
    public event Action<int> OnKilled;
    public event Action OnGone;
    
    [SerializeField] 
    private int points = 100;
    
    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private int life = 3;
    
    [SerializeField]
    private float maxYPosition = -3f;

    private Weapon[] weapons;

    private Explosion explosion;
    
    void Start()
    {
        weapons = GetComponentsInChildren<Weapon>();
        explosion = GetComponent<Explosion>();

    }
    void Update()
    {
        Move();
        Shoot();
        
        if (transform.position.y <= maxYPosition)
        {
            OnGone?.Invoke();
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        life -= damage;

        if (life <= 0)
        {
            OnGone?.Invoke();
            OnKilled?.Invoke(points);
            Destroy(gameObject);
            explosion.Activate();
        }
    }

    private void Shoot()
    {
        if (weapons == null || weapons.Length == 0)
            return;

        foreach (var weapon in weapons)
        {
            weapon.FireWhenReady();
        }
    }

    private void Move()
    {
        transform.Translate(Vector2.up * (speed * Time.deltaTime));
    }
}
