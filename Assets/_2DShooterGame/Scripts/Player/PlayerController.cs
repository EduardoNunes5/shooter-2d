using System;
using _2DShooterGame.Scripts;
using UnityEngine;


[RequireComponent(typeof(Explosion))]
public class PlayerController : MonoBehaviour, ItakeDamage
{
    
    public event Action OnKilled;

    public InputHandler InputHandler { get; private set; }

    private Explosion explosion;
    
    private void Start()
    {
        InputHandler = GetComponent<InputHandler>();
        explosion = GetComponent<Explosion>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            KillMe();
        }
    }
    
    public void TakeDamage(int damage)
    {
        KillMe();
    }
    
    private void KillMe()
    {
        OnKilled?.Invoke();
        gameObject.SetActive(false);
        explosion.Activate();
    }
}
