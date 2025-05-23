using UnityEngine;


[RequireComponent(typeof(PlayerController))]

public class PlayerShooter : MonoBehaviour
{

    private PlayerController playerController;
    
    private Weapon[] weapons;
    
    void Start()
    {
        weapons = GetComponentsInChildren<Weapon>();
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        Shot();
    }

    private void Shot()
    {
        if (playerController.InputHandler.GetFire1Button())
        {
            foreach (var weapon in weapons)
            {
                weapon.FireWhenReady();
            }
        }
    }
}
