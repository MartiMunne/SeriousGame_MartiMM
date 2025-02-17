using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    //UI
    [SerializeField] private GameObject MainMenuUI;
    [SerializeField] private GameObject HowToPlayUI;
    [SerializeField] private GameObject LoseUI;
    [SerializeField] private GameObject LoseOverlay;


    //Sonidos y musica
    [SerializeField] private AudioSource audioBlackboard;
    [SerializeField] private AudioSource musicGame;
    [SerializeField] private AudioSource audioLose;

    //Instance
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
        //Iniciar el tiempo (Por si se abre despues de parar-lo al perder el juego)
        Time.timeScale = 1f;
    }

    //Boton para activar el menu de Como Jugar
    public void ToHowToPlayMenu() 
    { 
        MainMenuUI.SetActive(false);
        HowToPlayUI.SetActive(true);
        audioBlackboard.Play();
    }

    //Boton para activar el menu de Main Menu
    public void ToMainMenu()
    {
        MainMenuUI.SetActive(true);
        HowToPlayUI.SetActive(false);
        audioBlackboard.Play();
    }

    //Boton para activar la escena Game
    public void PlayButton() 
    {
        SceneManager.LoadScene(1);   
    }

    //Boton para salir del juego (O parar el modo Play en el editor)
    public void ExitButton() 
    {
        audioBlackboard.Play();
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    //Activar la UI de derrota y parar el juego
    public void Lose() 
    {
        musicGame.Pause();
        Time.timeScale = 0f;
        LoseOverlay.SetActive(true);
        LoseUI.SetActive(true);
        audioLose.Play();
    }

    //Boton para activar la escena Main Menu
    public void MenuButton() 
    {
        SceneManager.LoadScene(0);
    }
}
