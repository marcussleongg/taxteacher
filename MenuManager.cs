using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject levelSelectPanel;
    public GameObject playerAstronaut;

    public TMP_Text levelNameText;

    public string[] levelDescriptions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        mainMenuPanel.SetActive(true);
        levelSelectPanel.SetActive(false);
        playerAstronaut.SetActive(true);
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void levelSelectMenu()
    {
        mainMenuPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
        playerAstronaut.SetActive(false);
        levelNameText.gameObject.SetActive(false);
    }

    public void backToMainMenu()
    {
        mainMenuPanel.SetActive(true);
        levelSelectPanel.SetActive(false);
        playerAstronaut.SetActive(true);
    }

    public void selectLevel(int level)
    {
        switch (level)
        {
            case 1:
                levelNameText.text = levelDescriptions[0];
                PlayerPrefs.SetInt("level", 1);
                break;
            case 2:
                levelNameText.text = levelDescriptions[1];
                PlayerPrefs.SetInt("level", 2);
                break;
            case 3:
                levelNameText.text = levelDescriptions[2];
                PlayerPrefs.SetInt("level", 3);
                break;
            case 4:
                levelNameText.text = levelDescriptions[3];
                PlayerPrefs.SetInt("level", 4);
                break;
            case 5:
                levelNameText.text = levelDescriptions[4];
                PlayerPrefs.SetInt("level", 5);
                break;
            case 6:
                levelNameText.text = levelDescriptions[5];
                PlayerPrefs.SetInt("level", 6);
                break;
            case 7:
                levelNameText.text = levelDescriptions[6];
                PlayerPrefs.SetInt("level", 7);
                break;
            case 8:
                levelNameText.text = levelDescriptions[7];
                PlayerPrefs.SetInt("level", 8);
                break;
            default:
                levelNameText.text = "Level not found";
                break;
        }
        levelNameText.gameObject.SetActive(true);

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene - berhane");
    }

}
