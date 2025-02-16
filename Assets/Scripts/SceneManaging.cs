using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuUI;
    [SerializeField] private GameObject HowToPlayUI;
    [SerializeField] private GameObject LoseUI;
    [SerializeField] private AudioSource audioBlackboard;
    [SerializeField] private AudioSource musicGame;
    [SerializeField] private AudioSource audioLose;

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
        audioBlackboard.Play();
    }

    public void ToMainMenu()
    {
        MainMenuUI.SetActive(true);
        HowToPlayUI.SetActive(false);
        audioBlackboard.Play();
    }

    public void PlayButton() 
    {
        SceneManager.LoadScene(1);   
    }

    public void ExitButton() 
    {
        audioBlackboard.Play();
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void Lose() 
    {
        musicGame.Pause();
        Time.timeScale = 0f;
        LoseUI.SetActive(true);
        audioLose.Play();
    }

    public void MenuButton() 
    {
        SceneManager.LoadScene(0);
    }
}
