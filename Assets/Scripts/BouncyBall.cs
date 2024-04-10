using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class BouncyBall : MonoBehaviour
{
    [SerializeField] float minY = -8.5f;    
    [SerializeField] float maxVelocity = 15f;
    Rigidbody2D rb;
    [SerializeField] int score = 0;
    [SerializeField] int lives = 5;
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public GameObject[] livesImage;
    int bricksCount;
    void Start()
    {
        bricksCount = FindObjectOfType<levelGen>().size.x * FindObjectOfType<levelGen>().size.y;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down*10;
    }


    void Update()
    {
        if(bricksCount <= 0)
        {
            WinUIDisPlay();
        }
        if(transform.position.y <= minY)
        {
            if(lives <= 0)
            {
                GameOver();
            }
            
            else
            {
                transform.position = Vector3.zero;
                rb.velocity = Vector2.down*10;
                lives--;
                livesImage[lives].SetActive(false);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Brick"))
        {
            Destroy(other.gameObject);
            bricksCount --;
            score += 10;
            scoreText.text = score.ToString("00000");
        }
    }
    public void GameOver()
    {
        SceneManager.LoadScene("LostUI");
    }
    public void WinUIDisPlay()
    {
        SceneManager.LoadScene("WinUI");
    }
}
