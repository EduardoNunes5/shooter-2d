using UnityEngine;

namespace _2DShooterGame.Scripts
{
    public class Explosion : MonoBehaviour
    {

        [SerializeField]
        private GameObject prefab;

        [SerializeField]
        private float timeToLive;

        public void Activate()
        {
            GameObject explosionEffects = Instantiate(prefab);
            explosionEffects.transform.position = transform.position;
            explosionEffects.transform.rotation = Quaternion.identity;
            
            Destroy(explosionEffects, timeToLive);
        }
    }
}