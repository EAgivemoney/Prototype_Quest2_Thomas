// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    [SerializeField] private Color objectColor = Color.white;

    void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        ChangeColor(objectColor);

    }

    public void ChangeColor(Color newColor)
    {
        objectColor = newColor;
        if (mySpriteRenderer != null)
        {
            mySpriteRenderer.color = objectColor;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer component not found on this GameObject.");
        }
    }
}
