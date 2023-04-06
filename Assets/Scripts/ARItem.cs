using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class ARItem : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public string itemDescription;
    public GameObject itemModel;
}
