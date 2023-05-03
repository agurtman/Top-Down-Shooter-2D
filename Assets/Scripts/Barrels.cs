using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Barrel", menuName = "Items/Barrel")]
public class Barrels : ScriptableObject
{
    public Sprite sprite;
    public float radius;
    public int damage;
    public string tag;
}
