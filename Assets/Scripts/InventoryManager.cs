
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class InventoryManager : MonoBehaviour
{
    //Note that most of the menu assets are made using simple blocks and basic fonts, this is to be changed later in development.
    public int Wood;
    public KeyCode inventory_open_key;
    private GameObject InventoryUI;
    private TextMeshProUGUI WoodText;
    public ItemData[] Inventory = new ItemData[4];
    private GameObject[] InventoryIcons;
    public GameObject IsTouchingGm;
    public static InventoryManager instance;
    public float MenuTime;
    void Awake()
    {
        //set instance
        if (InventoryManager.instance == null)
        {
            DontDestroyOnLoad(this);
            InventoryManager.instance = this;
        }
        else
        {
            Destroy(gameObject);
        }



        //set To length of inventory to avoid any errors. 
        InventoryIcons = new GameObject[Inventory.Length];
    }


    private void Start()
    {
        //any gameobjects needing a reference are done here --
      
        WoodText = GameObject.Find("WoodText").GetComponent<TextMeshProUGUI>();
        InventoryUI = GameObject.Find("Background");
        GameObject InvButtons = GameObject.Find("Icons");

        if (!InvButtons)
        {
            Debug.Log("NO INVENTORY ICONS FOUND!!!!");
        }
        else
        {
            int i = 0;
            foreach (Transform child in InvButtons.transform)
            {
                InventoryIcons[i] = child.gameObject;
                i++;
            }
        }
        InventoryUI.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        //this is for debug purposes
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddWood(1);
            
        }



        ///open and closing inventoryUI and slowing down time
        if (Input.GetKeyDown(inventory_open_key))
        {

            InventoryUI.SetActive(!InventoryUI.activeSelf);
            if(Time.timeScale == MenuTime)
            {
                Time.timeScale = 1;
                Time.fixedDeltaTime *= Time.timeScale;
            }
            else
            {
                Time.timeScale = MenuTime;
                Time.fixedDeltaTime *= Time.timeScale;
            }
        }
        
        UpdateInventoryIcons();
    }

    
    public void AddWood(int amount)
    {
        Wood += amount;

        //update text whenever wood is changed, instead of every frame , might move this to Update anyway not like its a crazy strain
        WoodText.text = ("Wood:" + Wood);
    }



    public void InventoryUIClicked(GameObject buttonGameObject)
    {

        if(buttonGameObject.transform.parent.name == "Icons")
        {
            for(int i = 1; i <= Inventory.Length; i++)
            { 
                if (buttonGameObject.name.Contains(i.ToString()))
                {
                    //the reason its Inventory[i-1] is because the for loop starts at 1 to read the InventoryIcon's names.
                    UseItem(Inventory[i - 1]);
                    Inventory[i-1] = null;
                }
            }


            return;
        }


        //CRAFTING BUTTONS
        //finds out what item was connected to the button
        var dataScript = buttonGameObject.GetComponentInChildren<ItemDataScript>();

        ItemData item = dataScript.item;

        if (item == null)
        {
            Debug.LogWarning("NO ITEM ATTACHED TO BUTTON !!!");
            return;
        }

       
        var listcheck = FindFirstNullIndex();

        //if player has more wood than the items req
        if (Wood >= item.WoodRequirement)
        {
          
           if(listcheck == null)
            {
                Debug.Log("Inventory is full");
            }

            else
            {
                AddWood(-item.WoodRequirement);
                Inventory[(int)listcheck] = item;
            }

        }
    }

    //returns the first index in Inventory that is empty
    public int? FindFirstNullIndex()
    {
        int i = 0;
        foreach(var item in Inventory)
        {
            //if slot is null / empty
            if(item == null)
            {
                return i;
            }

            i++;
        }
        //will return null if there is no free slots
        return null;
    }

    //this updates Inventory icons
    public void UpdateInventoryIcons()
    {
        int i = 0;

        foreach(ItemData item in Inventory)
        {
            if (!item)
            {
                InventoryIcons[i].SetActive(false);
                InventoryIcons[i].GetComponent<UnityEngine.UI.Image>().sprite = null;
            }

            else
            {
                InventoryIcons[i].SetActive(true);
                InventoryIcons[i].GetComponent<UnityEngine.UI.Image>().sprite = item.icon;
            }

            i++;
        }
    }


    public void UseItem(ItemData item)
    {
        switch (item.Name)
        {
            case ("NewAxe"):
                //every interaction an item can have is put here
                //IsTouchingGM is set from the InteractableBehaviour script attached to every Interactable GameObject.
                if (IsTouchingGm.name.Contains("tree"))
                {
                    AddWood(20);
                    
                    Destroy(IsTouchingGm.gameObject);
                }
                Debug.Log("Player swings axe as hard as they can... it breaks from the force.");
                return;

            default:
                Debug.Log("item not recognized");
                return;
        }
    }
}
