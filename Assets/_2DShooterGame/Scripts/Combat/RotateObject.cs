using UnityEngine;

public class RotateObject : MonoBehaviour
{

    [SerializeField]
    private Vector3 direction;

    [SerializeField]
    private float speed = 45;
    private void Update()
    {
        transform.Rotate(direction * (speed * Time.deltaTime));
    }
}
