using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]float playerSpeed;
    public bool canMove;

    public int health = 3;

    [SerializeField] GameObject health1;
    [SerializeField] GameObject health2;
    [SerializeField] GameObject health3;

    public bool pausedGame;
    public GameManagerScript gameManagerScript;

    public ParticleSystem movementDust;

    public AudioSource asteroidSFX;
    public AudioSource loseSFX;
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontal, vertical, 0) * Time.deltaTime * playerSpeed;
            transform.Translate(movement, Space.Self);

            if (!pausedGame)
            {
                Time.timeScale = 1;
            }

            if (movement != Vector3.zero)
            {
                movementDust.Play();
            }
            else
            {
                movementDust.Stop();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            health--;
            GetComponent<Animator>().SetTrigger("Hit");

            if (health <= 0)
            {
                Destroy(gameObject);
                gameManagerScript.GameOver();
                collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            }

            if (health == 2)
            {
                health3.SetActive(false);
                asteroidSFX.Play();

            }
            else if (health == 1)
            {
                health2.SetActive(false);
                asteroidSFX.Play();

            }
            else if (health == 0)
            {
                health1.SetActive(false);
                loseSFX.Play();
            }
        }
    }
}
