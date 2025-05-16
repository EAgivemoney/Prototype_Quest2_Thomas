using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicGem : MonoBehaviour
{
    [SerializeField] private Color gemColor = Color.white;

    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = gemColor;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer component not found on this GameObject.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block"))
        {
            ColorChanger colorChanger = collision.GetComponent<ColorChanger>();
            if (colorChanger != null)
            {
                colorChanger.ChangeColor(gemColor);
            }
            else
            {
                SpriteRenderer blockSpriteRenderer = collision.GetComponent<SpriteRenderer>();
                if (blockSpriteRenderer != null)
                {
                    blockSpriteRenderer.color = gemColor;
                }
                else
                {
                    Debug.LogWarning("SpriteRenderer component not found on the block GameObject.");
                }
            }
        }
    }
}
