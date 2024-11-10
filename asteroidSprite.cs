using UnityEngine;

public class asteroidSprite : MonoBehaviour
{
    public Sprite[] asteroidSprites;    

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = asteroidSprites[Random.Range(0, asteroidSprites.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
