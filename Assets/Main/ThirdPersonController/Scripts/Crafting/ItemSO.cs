using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]

public class ItemSO : ScriptableObject
{
    public Sprite sprite;
    public string name;
    public Transform prefab;
}