using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    [SerializeField]
    private GameObject backgroundPrefab;
    
    [SerializeField]
    private float speed = 10;

    [SerializeField]
    private float screenLimitY = -14;
    
    private GameObject[] backgrounds;

    private float spriteHeight;
    
    private void Start() {
        backgrounds = new GameObject[2];
        
        for(int i = 0; i < backgrounds.Length; i++) 
        {
            backgrounds[i] = Instantiate(backgroundPrefab);
        }
        
        spriteHeight = backgroundPrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        backgrounds[1].transform.position = transform.position + new Vector3(0, spriteHeight, 0);
    }

    private void Update()
    {
        foreach (GameObject background in backgrounds)
        {
            background.transform.Translate(Vector2.down * (speed * Time.deltaTime));
        }

        if (backgrounds[0].transform.position.y < screenLimitY)
        {
            backgrounds[0].transform.position = backgrounds[1].transform.position + new Vector3(0, spriteHeight, 0);
        }
        
        if (backgrounds[1].transform.position.y < screenLimitY)
        {
            backgrounds[1].transform.position = backgrounds[0].transform.position + new Vector3(0, spriteHeight, 0);
        }
    }
}
