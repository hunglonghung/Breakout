using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public bool isPaused = false;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float borderValue = 3.7f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume(); 
            }
            else
            {
                Pause(); 
            }
        }
        if(Input.GetKey(KeyCode.LeftArrow)) transform.Translate(-speed * Time.deltaTime,0,0);
        if(Input.GetKey(KeyCode.RightArrow)) transform.Translate(speed * Time.deltaTime,0,0);
        float xPos = Mathf.Clamp(transform.position.x,-borderValue,borderValue);
        transform.position = new Vector3(xPos,transform.position.y,transform.position.z);
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
