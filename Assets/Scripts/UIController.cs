using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    private int score = 0;

    [SerializeField] private TextMeshProUGUI scoreValue;

    [SerializeField] private Image healthBar;

    [SerializeField] private Image crossHair;

    [SerializeField] private OptionsPopup optionsPopup;

    [SerializeField] private SettingPopup settingPopup;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(score);

        healthBar.fillAmount = 1;
        healthBar.color = Color.green;

    }

    // Update is called once per frame
    //|| !settingPopup.IsActive()
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape) && !optionsPopup.IsActive())
        //{
        //    SetGameActive(false);
        //    optionsPopup.Open();
        //}
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!optionsPopup.IsActive() && !settingPopup.IsActive())
            {
                SetGameActive(false);
                optionsPopup.Open();
            }
            else if (optionsPopup.IsActive())
            {
                optionsPopup.Close();

                if (settingPopup.IsActive())
                {
                    settingPopup.Close();
                }

                SetGameActive(true);
            }
            else if (settingPopup.IsActive())
            {
                settingPopup.Close();
                optionsPopup.Open();
            }
        }
    }

    public void UpdateScore(int newScore)
    {
        scoreValue.text = newScore.ToString();

    }


    public void SetGameActive(bool active)
    {
        if (active)
        {
            Time.timeScale = 1; // unpause the game
            Cursor.lockState = CursorLockMode.Locked; // lock cursor at center
            Cursor.visible = false; // hide cursor
            crossHair.gameObject.SetActive(true); // show the crosshair
        }
        else
        {
            Time.timeScale = 0; // pause the game
            Cursor.lockState = CursorLockMode.None; // let cursor move freely
            Cursor.visible = true; // show the cursor
            crossHair.gameObject.SetActive(false); // turn off the crosshair
        }
    }

}
