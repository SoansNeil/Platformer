using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float jumpForce = 18f;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private int score = 0;
    private int health = 100;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 10;
            UpdateUI();
            GameOver();
            Debug.Log("Health: " + health);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    void OnTriggerEnter2D(Collider2D trigger)
    {
              if (trigger.gameObject.CompareTag("Coin"))
        {
            score += 10;
            Destroy(trigger.gameObject);
            UpdateUI();
            Debug.Log("Score: "  + score);
        }
    }
    void UpdateUI()
    {
        healthText.text = "Health: " + health;
        scoreText.text = "Score: " + score;
    }
    void GameOver()
    {
        if(health == 0)
        {
            PlayerPrefs.SetInt("FinalScore", score);
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameOver");
        }
    }
}
