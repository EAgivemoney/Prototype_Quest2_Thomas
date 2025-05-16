// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private GameHandler gameHandler;

    void Start()
    {
        gameHandler = FindObjectOfType<GameHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            SpriteRenderer hazardRenderer = GetComponent<SpriteRenderer>();
            SpriteRenderer blockRenderer = collision.gameObject.GetComponent<SpriteRenderer>();

            if (hazardRenderer != null & blockRenderer != null && blockRenderer.color != hazardRenderer.color)
            {
                if (collision.gameObject.GetComponent<BlockMovement>().isActiveBool)
                {
                    Destroy(collision.gameObject);
                    gameHandler.AllPlayerBlocksArrayUpdate();
                    gameHandler.DestroyedBlockUpdate();
                }
                else
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
