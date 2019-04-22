using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dog_Abilities : ScriptableObject
{
    public int speed;
    public int range;
    public int width;

    public virtual void Cast(GameObject target)
    {

    }
}
