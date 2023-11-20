using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] bool tiltLeft;
    [SerializeField] bool tiltRight;
    [SerializeField] GameObject title;

    public string levelSelectorName;
    public string settingsLevelName;
    public string creditsScreenName;
    public string mainMenuName;

    public TextMeshPro timer;
    float erer = 5;
    string kj;

    #region TitleTilt
    public void Start()
    {
        tiltLeft = true;
    }

    public void Update()
    {
        if (tiltLeft)
        {
            title.transform.Rotate(0f, 0f, 15f, Space.World);
            StartCoroutine(TiltRight());
        }
        else if (tiltRight)
        {
            title.transform.Rotate(0f, 0f, -15f, Space.World);
            StartCoroutine(TiltLeft());
        }
       
        
        timer.SetText(erer.ToString());


    }

    IEnumerator TiltLeft()
    {   
        yield return new WaitForSeconds(1.7f);
        tiltLeft = true;
        tiltRight = false;
    }

    IEnumerator TiltRight()
    {
        yield return new WaitForSeconds(1.7f);
        tiltRight = true;
        tiltLeft = false;
    }

    #endregion

    #region MenuButtons
    public void StartButton()
    {
        SceneManager.LoadScene(levelSelectorName);
    }

    public void SettingsButton()
    {
        SceneManager.LoadScene(settingsLevelName);
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("The Game Has Quit");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene(creditsScreenName);
    }

    public void BackButton()
    {
        SceneManager.LoadScene(mainMenuName);
    }
    #endregion
}
