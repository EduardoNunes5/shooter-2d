using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float speed = 5;

    private PlayerController controller;
    
    [Header("Boundaries")]
    [SerializeField]
    private float maxHorizontalBoundary = 3;
    
    [SerializeField]
    private float minHorizontalBoundary = -3;
    
    [SerializeField]
    private float maxVerticalBoundary = 3;
    
    [SerializeField]
    private float minVerticalBoundary = -3;

    private void Start()
    {
        controller = GetComponent<PlayerController>();
    }
    void Update()
    {
        Move();
        LimitMovement();
    }
    
    private void Move()
    {
        float horitonzalInput = controller.InputHandler.GetHorizontalAxis();
        float verticalInput = controller.InputHandler.GetVerficalAxis();
        
        Vector3 direction = new Vector2(horitonzalInput, verticalInput);
        
        transform.position += direction * (speed * Time.deltaTime);
    }
    
    private void LimitMovement()
    {
        if (transform.position.x >= maxHorizontalBoundary)
        {
            transform.position = new Vector2(maxHorizontalBoundary, transform.position.y);
        }

        if (transform.position.x <= minHorizontalBoundary)
        {
            transform.position = new Vector2(minHorizontalBoundary, transform.position.y);
        }

        if (transform.position.y >= maxVerticalBoundary)
        {
            transform.position = new Vector2(transform.position.x, maxVerticalBoundary);
        }

        if (transform.position.y <= minVerticalBoundary)
        {
            transform.position = new Vector2(transform.position.x, minVerticalBoundary);
        }
        
    }
}
