using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    //might add a durabiltiy for stuff like the axe - could also act as charges for certain items
    public string Name;
    public int WoodRequirement;
    public Sprite icon;
}
