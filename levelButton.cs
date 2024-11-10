using UnityEngine;
using UnityEngine.UI;

public class levelButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] int level;
    [SerializeField] Button button;
    [SerializeField] Image lockImage;

    void Start()
    {
        button = GetComponent<Button>();
        button.interactable = false;
        lockImage.enabled = true;

        if (level == 2)
        {
            if (PlayerPrefs.GetInt("level2Unlocked") == 1)
            {
                button.interactable = true;
                lockImage.enabled = false;
            }
        }
        else if (level == 3)
        {
            if (PlayerPrefs.GetInt("level3Unlocked") == 1)
            {
                button.interactable = true;
                lockImage.enabled = false;
            }
        }
        else if (level == 4)
        {
            if (PlayerPrefs.GetInt("level4Unlocked") == 1)
            {
                button.interactable = true;
                lockImage.enabled = false;
            }
        }
        else if (level == 5)
        {
            if (PlayerPrefs.GetInt("level5Unlocked") == 1)
            {
                button.interactable = true;
                lockImage.enabled = false;
            }
        }
        else if (level == 6)
        {
            if (PlayerPrefs.GetInt("level6Unlocked") == 1)
            {
                button.interactable = true;
                lockImage.enabled = false;
            }
        }
        else if (level == 7)
        {
            if (PlayerPrefs.GetInt("level7Unlocked") == 1)
            {
                button.interactable = true;
                lockImage.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
