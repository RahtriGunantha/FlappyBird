using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public GameObject loseScreen;

    private float mentokAtas = 4.6f;

    public float highScore;
    public int score;

    public TextMeshProUGUI scoreToAdd;
    public TextMeshProUGUI highScoreToAdd;
    String HIGHSCORE = "HIGHSCORE";

    private void Awake() 
    {
        playerRb = GetComponent<Rigidbody2D>();
        highScore =  PlayerPrefs.GetInt(HIGHSCORE, score);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // if(Input.GetKeyDown(KeyCode.Space))
       // {
       //    playerRb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
            
       // }
       Jump();
       MentokAtas();


    }

    void Jump()
    {
        if(Input.GetMouseButtonDown(0))
        {
            playerRb.velocity = Vector2.up * 5f;
            AudioManager.singleton.PlaySound(0);
        }
    }
    void AddScore()
    {
        score++;
        scoreToAdd.text = score.ToString();

    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.collider.CompareTag("Obstacle"))
        {
            PlayerLose();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.CompareTag("Score"))
        {
            AddScore();
            AudioManager.singleton.PlaySound(1);
        }
    }

    private void PlayerLose () 
    {
        if(score > highScore)
        {
             highScore = score;
             PlayerPrefs.SetInt(HIGHSCORE, score);
        }
        AudioManager.singleton.PlaySound(2);
        highScoreToAdd.text = "HighScore : " + highScore.ToString();
        loseScreen.SetActive(true);
        Time.timeScale = 0;
        
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void MentokAtas()
    {

        if(transform.position.y > mentokAtas)
        {
            transform.position = new Vector2(transform.position.x, mentokAtas);
            playerRb.gravityScale = 3f;
        }

        if(transform.position.y < mentokAtas)
        {
            playerRb.gravityScale = 0.6f;
        }
    }
}
