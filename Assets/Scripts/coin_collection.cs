using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coin_collection : MonoBehaviour
{
    private int coin = 0;
    public TextMeshProUGUI cointext;
    public TextMeshProUGUI gametime;
    public TextMeshProUGUI gameOverText;
    public float timeRemaining = 180;

    private bool gameOver = false; // Flag to track game over state

    void Start()
    {
        UpdateTime(timeRemaining);
        gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!gameOver) // Only update time if the game is not over
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTime(timeRemaining);
            }
            else
            {
                UpdateTime(0);
                GameOver();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameOver) // Only allow interaction if the game is not over
        {
            if (other.GetComponent<CoinP>() != null)
            {
                coin++;
                cointext.text = "coins: " + coin.ToString();
                Debug.Log(coin);
                Destroy(other.gameObject);

                // To destroy invisible wall  L1.
                if (coin >= 15)
                {
                    INwall[] walls = FindObjectsOfType<INwall>();
                    foreach (INwall wall in walls)
                    {
                        Destroy(wall.gameObject);
                    }
                }
                // To destroy invisible wall  L2.
                if (coin >= 25)
                {
                    INwall2[] walls = FindObjectsOfType<INwall2>();
                    foreach (INwall2 wall in walls)
                    {
                        Destroy(wall.gameObject);
                    }
                }
                // To destroy invisible wall L3.
                if (coin >= 35)
                {
                    INwall3[] walls = FindObjectsOfType<INwall3>();
                    foreach (INwall3 wall in walls)
                    {
                        Destroy(wall.gameObject);
                    }
                }
            }
            else if (other.GetComponent<CoinN>() != null)
            {
                coin--;
                cointext.text = "coins: " + coin.ToString();
                Debug.Log(coin);
                Destroy(other.gameObject);
            }
        }
    }

    public void UpdateTime(float timeLeft)
    {
        gametime.text = "Remaining Time: " + timeLeft.ToString("F0");
    }

    public void GameOver()
    {
        gameOver = true; // Set game over flag to true
        gameOverText.gameObject.SetActive(true);
        Debug.Log("Game Over");
    }
}
