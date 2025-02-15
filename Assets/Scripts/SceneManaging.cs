using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuUI;
    [SerializeField] private GameObject HowToPlayUI;
    [SerializeField] private GameObject LoseUI;

    public static SceneManaging sceneManaging;

    private void Awake()
    {
        if (sceneManaging == null)
        {
            sceneManaging = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void ToHowToPlayMenu() 
    { 
        MainMenuUI.SetActive(false);
        HowToPlayUI.SetActive(true);
    }

    public void ToMainMenu()
    {
        MainMenuUI.SetActive(true);
        HowToPlayUI.SetActive(false);
    }

    public void PlayButton() 
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton() 
    { 
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void Lose() 
    {
        Time.timeScale = 0f;
        LoseUI.SetActive(true);
    }

    public void MenuButton() 
    {
        SceneManager.LoadScene(0);
    }
}
