using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

using UnityEngine.Audio;

public class RepairSpaceshipScript : MonoBehaviour
{
    [SerializeField] GameObject TextBox;
    [SerializeField] GameObject CollectItemButton;
    PlayerMovement playerMovement;
    GameObject repairItem;
    [SerializeField] GameObject questionnaire;

    public bool collectedItem;

    public Questions questions;


    public Text option1Text;
    public Text option2Text;
    public Text option3Text;
    public Text option4Text;
    public Text questionText;

    public TMP_Text informationTitle;
    public TMP_Text information;
    public int currentQuestion = 0;

    public GameObject wrongText;
    public GameObject correctText;
    public GameManagerScript gameManagerScript;
    public GameObject wrench1;
    public GameObject wrench2;
    public int spaceshipHealth = 2;

    public float timeDelay = 1.0f;

    public ParticleSystem explosion;

    public AudioSource collectSFX;
    public AudioSource correctSFX;
    public AudioSource wrongSFX;
    void Start()
    {
        collectedItem = false;
        ResetUI();

        switch (PlayerPrefs.GetInt("level"))
        {
            case 1:
                questions.questions = questions.level1Questions;
                break;
            case 2:
                questions.questions = questions.level2Questions;
                break;
            case 3:
                questions.questions = questions.level3Questions;
                break;
            case 4:
                questions.questions = questions.level4Questions;
                break;
            case 5:
                questions.questions = questions.level5Questions;
                break;
            case 6:
                questions.questions = questions.level6Questions;
                break;
            case 7:
                questions.questions = questions.level7Questions;
                break;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RepairItem")
        {
            if (!collectedItem)
            {
                TeachMaterial();
                repairItem = collision.gameObject;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Spaceship" && collectedItem)
        {
            AskQuestion();
            collectedItem = false;
        }
    }
    public void TeachMaterial()
    {
        TextBox.SetActive(true);
        CollectItemButton.SetActive(true);
        GetComponent<PlayerMovement>().canMove = false;
        Time.timeScale = 0;

        informationTitle.text = questions.questions[currentQuestion].informationTitle;
        information.text = questions.questions[currentQuestion].information;


    }

    public void AskQuestion()
    {
        questionnaire.SetActive(true);
        GetComponent<PlayerMovement>().canMove = false;


        questionText.text = questions.questions[currentQuestion].questionText;
        option1Text.text = questions.questions[currentQuestion].options[0];
        option2Text.text = questions.questions[currentQuestion].options[1];
        option3Text.text = questions.questions[currentQuestion].options[2];
        option4Text.text = questions.questions[currentQuestion].options[3];


    }

    public void ResetUI()
    {
        TextBox.SetActive(false);
        CollectItemButton.SetActive(false);
        questionnaire.SetActive(false);
     
        GetComponent<PlayerMovement>().canMove = true;
        Destroy(repairItem);
    }   

    public void CollectItem()
    {
        collectedItem = true;
        ResetUI();
        collectSFX.Play();
    }

    public void submitAnswer(int option)
    {
        Debug.Log(option);
        Debug.Log(questions.questions[currentQuestion].answer);                     
        if (option == questions.questions[currentQuestion].answer)
        {


            Debug.Log("Correct");
            ResetUI();
            correctSFX.Play();
            correctText.SetActive(true);
            StartCoroutine(HideFeedbackAfterDelay(correctText));
        }
        else
        {
            explosion.Play();
            wrongSFX.Play();
            Debug.Log("Incorrect");
            ResetUI();
            spaceshipHealth -= 1;
            if (spaceshipHealth == 1) {
                wrench2.SetActive(false);
            } else if (spaceshipHealth <= 0) {
                wrench1.SetActive(false);
                gameManagerScript.GameOver();
            }

            wrongText.SetActive(true);
            StartCoroutine(HideFeedbackAfterDelay(wrongText));
        }

        if (questions.questions.Length - 1 > currentQuestion)
        {
            currentQuestion++;
        }
        else { 
            gameManagerScript.winLevel();

            if (PlayerPrefs.GetInt("level") == 1)
            {
                PlayerPrefs.SetInt("level2Unlocked", 1);
            }
            else if(PlayerPrefs.GetInt("level") == 2)
            {
                PlayerPrefs.SetInt("level3Unlocked", 1);
            }
            else if (PlayerPrefs.GetInt("level") == 3)
            {
                PlayerPrefs.SetInt("level4Unlocked", 1);
            }
            else if (PlayerPrefs.GetInt("level") == 4)
            {
                PlayerPrefs.SetInt("level5Unlocked", 1);
            }
            else if (PlayerPrefs.GetInt("level") == 5)
            {
                PlayerPrefs.SetInt("level6Unlocked", 1);
            }
            else if (PlayerPrefs.GetInt("level") == 6)
            {
                PlayerPrefs.SetInt("level7Unlocked", 1);
            }
        }
    }

    private IEnumerator HideFeedbackAfterDelay(GameObject feedbackText)
    {
        yield return new WaitForSeconds(timeDelay);
        feedbackText.SetActive(false);
    }
}