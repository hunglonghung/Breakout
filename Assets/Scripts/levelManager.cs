using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    public void generateLevel()
    {
        SceneManager.LoadScene("GamePlay");
        Time.timeScale = 1f;
    }
    public void backToMainMenu()
    {
        SceneManager.LoadScene("Start");
        Time.timeScale = 1f;
    }
    public void continueGame()
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        if(playerMovement != null)
        {
            playerMovement.Resume();
        }
        
    }
}
