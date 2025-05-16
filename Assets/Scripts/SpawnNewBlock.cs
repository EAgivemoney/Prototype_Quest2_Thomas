// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewBlock : MonoBehaviour
{
    [SerializeField] GameObject blockPrefab;
    [SerializeField] Transform spawnPosition;
    [SerializeField] Color[] colors;

    private Color GetRandomColor()
    {
        int randomIndex = Random.Range(0, colors.Length);
        return colors[randomIndex];
    }

    public void SpawnBlock()
    {
        Color randomColor = GetRandomColor();
        GameObject newBlock = Instantiate(blockPrefab, spawnPosition.position, Quaternion.identity);

        ColorChanger colorChanger = newBlock.GetComponent<ColorChanger>();
        if (colorChanger != null)
        {
            colorChanger.ChangeColor(randomColor);
        }
        else
        {
            SpriteRenderer blockSpriteRenderer = newBlock.GetComponent<SpriteRenderer>();
            if (blockSpriteRenderer != null)
            {
                blockSpriteRenderer.color = randomColor;
            }
            else
            {
                Debug.LogWarning("SpriteRenderer component not found on the block GameObject.");
            }
        }
    }
}