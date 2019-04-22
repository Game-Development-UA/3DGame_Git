using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "My New Damage Ability", menuName = "Dog Abilities/Damage Ability")]
public class Damage_abilities : Dog_Abilities
{
    public int damage;
    public override void Cast(GameObject target)
    {

    }
}
