using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] 
    private Bullet bullet;

    [SerializeField]
    private float cooldownTime = 1;

    [SerializeField]
    private Vector2 bulletDirection = Vector2.down;

    private float timeToShoot;

    private void Start()
    {
        timeToShoot = cooldownTime;
    }

    private void Update()
    {
        timeToShoot += Time.deltaTime;
    }

    public void FireWhenReady()
    {

        if (timeToShoot <= cooldownTime)
            return;
        
        var newBullet = Instantiate(bullet, transform.position, transform.rotation);
        newBullet.SetDirection(bulletDirection);
        timeToShoot = 0;
    }
    
}