using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{
    private AudioSource click;
    public GameObject gameOverPanel;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        click = GetComponent<AudioSource>();
        gameOverPanel.SetActive(false);
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void backToMenu()
    {
        Time.timeScale = 1;
        click.Play();
        SceneManager.LoadScene(sceneName: "MainMenu");
    }
    public void quitGame()
    {
        click.Play();
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void backToGame()
    {
        click.Play();
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
