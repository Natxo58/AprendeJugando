using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FotosScript : MonoBehaviour
{
    [Header("Fotos Script")]
    public int orden;

    public void setSprite(Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
