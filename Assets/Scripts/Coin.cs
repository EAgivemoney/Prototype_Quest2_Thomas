using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int scoreValue = 1;
    [SerializeField] private WinCondition winCondition;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block"))
        {
            SpriteRenderer blockRenderer = collision.GetComponent<SpriteRenderer>();
            if (blockRenderer != null && spriteRenderer != null)
            {
                if (blockRenderer.color == spriteRenderer.color)
                {
                    ScoreManager.Instance.AddScore(scoreValue);
                    Destroy(gameObject);
                    winCondition.CoinCollected();
                }
                else
                {
                    animator.SetTrigger("WrongColor");
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Block"))
        {
            SpriteRenderer blockRenderer = collision.GetComponent<SpriteRenderer>();
            if (blockRenderer != null && spriteRenderer != null)
            {
                if (blockRenderer.color != spriteRenderer.color)
                {
                    animator.SetTrigger("Away");
                }
            }
        }
    }
}
