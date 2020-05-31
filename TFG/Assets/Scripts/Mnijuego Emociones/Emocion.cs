using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emocion
{
    private string name;
    private Sprite sprite;

    #region getters & setters

    public Sprite GetSprite()
    {
        return sprite;
    }
    public string GetName()
    {
        return name;
    }

    #endregion

    #region functions

    public Emocion(string name){
        this.name = name;
        sprite = null;
    }

    public Emocion(string name, Sprite sprite) {
        this.name = name;
        this.sprite = sprite;
    }

    public void cambiarSprite(Sprite sprite)
    {
        this.sprite = sprite;
    }

    #endregion
}
