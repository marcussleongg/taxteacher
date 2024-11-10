using UnityEngine;

public class FloatingObject : MonoBehaviour

{

    public float minFloatStrength = 0.25f; // Controls how high the object floats
    public float maxFloatStrength = 1.75f; // Controls how high the object floats

    public float minFloatSpeed = 0.5f;   // Controls the speed of the floating motion
    public float maxFloatSpeed = 1.5f;   // Controls the speed of the floating motion

    public float minFloatDistance = 0.25f;  // Distance of the float
    public float maxFloatDistance = 0.75f;  // Distance of the float

    float floatDistance;
    float floatSpeed;


    private Vector3 startPosition;



    void Start()

    {
        startPosition = transform.position;

        floatDistance = Random.Range(minFloatDistance, maxFloatDistance);
        floatSpeed = Random.Range(minFloatSpeed, maxFloatSpeed);

    }



    void Update()
    {
        // Floating motion

        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatDistance;

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}