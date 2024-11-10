using UnityEngine;
using System.Collections.Generic;

public class toolsSpawner : MonoBehaviour
{
    public int numOfTools;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minDistance; // Minimum distance between tools
    public GameObject[] tools;

    private List<Vector2> spawnedPositions = new List<Vector2>();

    void Start()
    {
        for (int i = 0; i < numOfTools; i++)
        {
            Vector2 spawnPosition;
            int attempts = 0;
            bool positionIsValid;

            do
            {
                positionIsValid = true;
                spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

                // Check the distance between this position and all previously spawned positions
                foreach (Vector2 pos in spawnedPositions)
                {
                    if (Vector2.Distance(spawnPosition, pos) < minDistance)
                    {
                        positionIsValid = false;
                        break;
                    }
                }

                attempts++;
                if (attempts > 100) // Prevent infinite loop
                {
                    Debug.LogWarning("Could not find a valid position for the tool after 100 attempts.");
                    break;
                }
            } while (!positionIsValid);

            if (positionIsValid)
            {
                int toolIndex = Random.Range(0, tools.Length);
                Instantiate(tools[toolIndex], spawnPosition, Quaternion.identity);
                spawnedPositions.Add(spawnPosition);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}