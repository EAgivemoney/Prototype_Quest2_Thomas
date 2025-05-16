using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private string nextLevelName = "Level_2";
    private int totalCoins;
    private int collectedCoins = 0;
    private bool allCoinsCollected = false;

    void Start()
    {
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    public void CoinCollected()
    {
        collectedCoins++;
        if (collectedCoins >= totalCoins)
        {
            allCoinsCollected = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (allCoinsCollected && collision.CompareTag("Block"))
        {
            LoadScene(nextLevelName);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
