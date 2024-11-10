using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour {
    /*
    public List<questionsandanswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    //public GameObject RoundOverPanel;

    public Text questionText;
    public GameObject quizPanel;
    public GameObject wrongText;
    public GameObject correctText;

    int totalQuestions = 0;
    public int score;
    public float timeDelay = 3.0f;

    private void Start() {
        totalQuestions = QnA.Count;
        //RoundOverPanel.SetActive(false);
        generateQuestion();
        correctText.SetActive(false);
        wrongText.SetActive(false);
    }

    //public void RoundOver() {
        //RoundOverPanel.SetActive(true);
    //}

    public void correct() {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        quizPanel.SetActive(false);
        correctText.SetActive(true);
        StartCoroutine(HideFeedbackAfterDelay(correctText));
        //correctText.SetActive(false);
        //generateQuestion();
    }

    public void wrong() {
        QnA.RemoveAt(currentQuestion);
        quizPanel.SetActive(false);
        wrongText.SetActive(true);
        StartCoroutine(HideFeedbackAfterDelay(wrongText));
        //wrongText.SetActive(false);
        //generateQuestion();
    }

    private IEnumerator HideFeedbackAfterDelay(GameObject feedbackText) {
        yield return new WaitForSeconds(timeDelay);
        feedbackText.SetActive(false);
    }

    void SetAnswers() {
        for (int i=0; i<options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i+1) {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion() {
        if (QnA.Count > 0) {
            currentQuestion = Random.Range(0, QnA.Count);
            questionText.text = QnA[currentQuestion].Question;
            SetAnswers();
        } else {
            Debug.Log("Out of Questions!");
            //RoundOver();
        }
    }
    */
}
