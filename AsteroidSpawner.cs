using UnityEngine;
using System.Collections;
public class AsteroidSpawner : MonoBehaviour
{

    public GameObject asteroid;
    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;

    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float Y;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnAsteroid());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnAsteroid()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnRate, maxSpawnRate));
            Instantiate(asteroid, new Vector3(Random.Range(minX, maxX), Y, 0), Quaternion.identity);
        }
    }

}
