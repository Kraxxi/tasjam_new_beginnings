using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    public Sprite itemSprite;

    public abstract void OnCollect(Player player);
}
