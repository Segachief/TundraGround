using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDataScript : MonoBehaviour
{
    //CREATING A CRAFTING BUTTON --
    //1. Add the prefab under the "Buttons" gameobject
    //2. Set the Onclick() function gameobject to InventoryManager and set function to InventoryUIClicked()
    //3. Set the gameobject in InventoryUIClicked to the CraftingButton
    
    public ItemData item;
    
    private void Start()
    {
        //sort out components for the button
        UnityEngine.UI.Image[] images = GetComponentsInChildren<UnityEngine.UI.Image>();
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
    
        images[1].sprite = item.icon;
        texts[0].text = item.Name;
        texts[1].text = item.WoodRequirement.ToString();

    }
}