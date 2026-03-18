using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    //Comment
    public string Name;
    public int WoodRequirement;
    public Sprite icon;
}
