using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class MenuButtions : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject difficultySelectPanel;
    private int count;
    private float timer;
    public GameObject flash;
    public GameObject[] title = new GameObject[3];
    private AudioSource[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        difficultySelectPanel.SetActive(false);
        MenuPanel.SetActive(false);
        title[0].SetActive(false);
        title[1].SetActive(false);
        title[2].SetActive(false);
        sounds = GetComponents<AudioSource>();
        count = 0;
        timer = 0;
    }
    private void Update()
    {
        if (count < 3)
        {
            if (timer == 0)
            {
                flash.gameObject.SetActive(true);
                sounds[1].Play();
            }
            else if (timer > 0.1)
            {
                title[count].gameObject.SetActive(true);
                flash.gameObject.SetActive(false);
            }
            timer += Time.deltaTime;
            if (timer > 3 && count != 2)
            {
                sounds[1].Stop();
                count++;
                timer = 0;
            }
            else if (timer > 5)
            {
                sounds[1].Stop();
                sounds[0].Play();
                count++;
                MenuPanel.SetActive(true);
            }

        }
    }
    public void ShowDifficultyPanel()
    {
        sounds[2].Play();
        MenuPanel.SetActive(false);
        difficultySelectPanel.SetActive(true);
    }

    public void ShowMenuPanel()
    {
        sounds[2].Play();
        MenuPanel.SetActive(true);
        difficultySelectPanel.SetActive(false);
    }
    public void startGame()
    {
        sounds[2].Play();
        SceneManager.LoadScene(sceneName: "Level 1");
    }
    public void quitGame()
    {
        sounds[2].Play();
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
