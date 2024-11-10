using UnityEngine;

public class asteroidMovement : MonoBehaviour
{
    [SerializeField] float yMin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < yMin)
        {
            Destroy(gameObject);
        }
    }
}
