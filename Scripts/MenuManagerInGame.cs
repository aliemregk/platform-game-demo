using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerInGame : MonoBehaviour
{

    public GameObject inGameScreen, pauseScreen, deathScreen, winScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CheckDead());

        if(Door.activeScene == 4)
        {
            winScreen.SetActive(true);
            inGameScreen.SetActive(false);
            pauseScreen.SetActive(false);
            deathScreen.SetActive(false);
        }
    }

    IEnumerator CheckDead()
    { 
        if (PlayerManager.dead)
        {
            yield return new WaitForSeconds(1);
            Death();
        }
    }
   
    public void PauseButton()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
        deathScreen.SetActive(false);
    }
    public void ResumeButton()
    {
        Time.timeScale = 1;
        inGameScreen.SetActive(true);
        pauseScreen.SetActive(false);
        deathScreen.SetActive(false);
    }
    public void Death()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(false);
        deathScreen.SetActive(true);
        PlayerManager.dead = false;
    }
    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Door.activeScene);
    }
    public void HomeButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
