using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Assets/New Item")]
public class SOItems : ScriptableObject
{
    public int id;
    public string displayName;
    public string description;
    public Texture2D itemTexture2DHover;
    public Texture2D itemTexture2DLink;
    public Texture2D itemTexture2DSelect;
    public int percent;
    public TypeVetementEnum typeVetement;
}
