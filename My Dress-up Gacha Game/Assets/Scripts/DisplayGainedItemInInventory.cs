using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DisplayGainedItemInInventory: MonoBehaviour
{
    [SerializeField]
    private ItemsGainedScriptableObject itemsGainedScriptableObject;

    [SerializeField]
    private Transform slotGridPanel;

    //[SerializeField]
    //private string inv_Slot_ = "Inv_Slot_";

    [SerializeField]
    private string itemIMG_Tag;
    [SerializeField]
    private Image[] gainedItem_IMG;

    [Header("Access Inv_Slot of CATEGORY")]
    [SerializeField]
    private string tagScripts_Inv_Slot_NAME;
    [SerializeField]
    private Toggle[] inv_Slot_NAME_Toggles;


    [Header("READ ONLY")]
    [SerializeField]
    private GameObject[] foundChild;
    [SerializeField]
    //private string[] foundType_Names;
    private GameObject[] foundType_GO;

    //Start didn't work but OnEnable() did -_-
    void OnEnable()
    {
        foundChild = GameObject.FindGameObjectsWithTag(itemIMG_Tag);
        if (foundChild == null)
        {
            Debug.Log("Can't find any children :(");
        }

        else
        {
            //This will automatically assign the gainedItem_Image to the script
            //We can extend(reduce the slots in the future -> Auto change
            for (int i = 0;i < foundChild.Length;i++)
            {
                if (foundChild[i].transform.IsChildOf(slotGridPanel))
                {
                    //Debug.Log(foundChild[i] + " is child of " + slotGridPanel.name);
                    gainedItem_IMG[i] = foundChild[i].GetComponent<Image>();

                }

                else
                {
                    Debug.Log(slotGridPanel.name + " is not working at index:  " + i);
                }
            }

            Find_Inv_SlotOfType_SwitchCase();

            //At the start of the game we turn off all gained Item in slots
            for (int i = 0;i < foundChild.Length;i++)
            {
                DisplayGainedItem(false, i);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Find_Inv_SlotOfType_SwitchCase()
    {
        switch (tagScripts_Inv_Slot_NAME)
        {
            case null:
                Debug.Log("No valid name. Can't display Item -> Check Spelling ALLCAP");
                break;

            case "HAIR":
                var foundType_Hair = FindObjectsOfType<TagScripts_Inv_Slot_HAIR>(true);
                for (int i = 0;i < foundType_Hair.Length;i++)
                {

                    //Find and assign the foundType to the local Array
                    foundType_GO[i] = foundType_Hair[i].gameObject;
                }
                //Sort all the found_GO by name/Number using the IComparer!
                Array.Sort(foundType_GO, new GameObjectComparerByName());

                //Get Toggle component of these foundType_GO and save it to inv_Slot_NAME_Toggles
                for (int i = 0;i < foundType_GO.Length;i++)
                {
                    inv_Slot_NAME_Toggles[i] = foundType_GO[i].GetComponent<Toggle>();
                }
                break;

            case "HEAD":
                var foundType_Head = FindObjectsOfType<TagScripts_Inv_Slot_HEAD>(true);
                for (int i = 0;i < foundType_Head.Length;i++)
                {
                    //Find and assign the foundType to the local Array
                    foundType_GO[i] = foundType_Head[i].gameObject;
                }
                //Sort all the found_GO by name/Number using the IComparer!
                Array.Sort(foundType_GO, new GameObjectComparerByName());

                //Get Toggle component of these foundType_GO and save it to inv_Slot_NAME_Toggles
                for (int i = 0;i < foundType_GO.Length;i++)
                {
                    inv_Slot_NAME_Toggles[i] = foundType_GO[i].GetComponent<Toggle>();
                }
                break;

            case "TORSO":
                var foundType_Torso = FindObjectsOfType<TagScripts_Inv_Slot_TORSO>(true);
                for (int i = 0;i < foundType_Torso.Length;i++)
                {
                    //Find and assign the foundType to the local Array
                    foundType_GO[i] = foundType_Torso[i].gameObject;
                }
                //Sort all the found_GO by name/Number using the IComparer!
                Array.Sort(foundType_GO, new GameObjectComparerByName());

                //Get Toggle component of these foundType_GO and save it to inv_Slot_NAME_Toggles
                for (int i = 0;i < foundType_GO.Length;i++)
                {
                    inv_Slot_NAME_Toggles[i] = foundType_GO[i].GetComponent<Toggle>();
                }
                break;

            case "LEG":
                var foundType_Leg = FindObjectsOfType<TagScripts_Inv_Slot_LEG>(true);
                for (int i = 0;i < foundType_Leg.Length;i++)
                {
                    //Find and assign the foundType to the local Array
                    foundType_GO[i] = foundType_Leg[i].gameObject;
                }
                //Sort all the found_GO by name/Number using the IComparer!
                Array.Sort(foundType_GO, new GameObjectComparerByName());

                //Get Toggle component of these foundType_GO and save it to inv_Slot_NAME_Toggles
                for (int i = 0;i < foundType_GO.Length;i++)
                {
                    inv_Slot_NAME_Toggles[i] = foundType_GO[i].GetComponent<Toggle>();
                }
                break;

            case "MISC":
                var foundType_Misc = FindObjectsOfType<TagScripts_Inv_Slot_MISC>(true);
                for (int i = 0;i < foundType_Misc.Length;i++)
                {
                    //Find and assign the foundType to the local Array
                    foundType_GO[i] = foundType_Misc[i].gameObject;
                }
                //Sort all the found_GO by name/Number using the IComparer!
                Array.Sort(foundType_GO, new GameObjectComparerByName());

                //Get Toggle component of these foundType_GO and save it to inv_Slot_NAME_Toggles
                for (int i = 0;i < foundType_GO.Length;i++)
                {
                    inv_Slot_NAME_Toggles[i] = foundType_GO[i].GetComponent<Toggle>();
                }
                break;

        }
    }

    //This method will find all the Inv_Slot of that category
    //We need to access to the toggle of that Inv_Slot
    //This only procs at the start for AutoSearch/Find
    private void Find_Inv_SlotOfType()
    {
        if (tagScripts_Inv_Slot_NAME == "HAIR")
        {
            //Find all the gameObject if TagScripts type and sort by name (string)
            /*var foundType_Hair = FindObjectsOfType<TagScripts_Inv_Slot_HAIR>();
            for (int i = 0;i < foundType_Hair.Length;i++)
            {
                foundType_Names[i] = foundType_Hair[i].gameObject.name;
            }
            System.Array.Sort(foundType_Names);*/

            var foundType_Hair = FindObjectsOfType<TagScripts_Inv_Slot_HAIR>(true);
            for (int i = 0;i < foundType_Hair.Length;i++)
            {
                //Find and assign the foundType to the local Array
                foundType_GO[i] = foundType_Hair[i].gameObject;
            }
            //Sort all the found_GO by name/Number using the IComparer!
            Array.Sort(foundType_GO, new GameObjectComparerByName());

            //Get Toggle component of these foundType_GO and save it to inv_Slot_NAME_Toggles
            for (int i = 0;i < foundType_GO.Length;i++)
            {
                inv_Slot_NAME_Toggles[i] = foundType_GO[i].GetComponent<Toggle>();
            }
        }

        else if (tagScripts_Inv_Slot_NAME == "HEAD")
        {
            var foundType_Head = FindObjectsOfType<TagScripts_Inv_Slot_HEAD>(true);
            for (int i = 0;i < foundType_Head.Length;i++)
            {
                //Find and assign the foundType to the local Array
                foundType_GO[i] = foundType_Head[i].gameObject;
            }
            //Sort all the found_GO by name/Number using the IComparer!
            Array.Sort(foundType_GO, new GameObjectComparerByName());

            //Get Toggle component of these foundType_GO and save it to inv_Slot_NAME_Toggles
            for (int i = 0;i < foundType_GO.Length;i++)
            {
                inv_Slot_NAME_Toggles[i] = foundType_GO[i].GetComponent<Toggle>();
            }
        }

        else if (tagScripts_Inv_Slot_NAME == "TORSO")
        {
            var foundType_Torso = FindObjectsOfType<TagScripts_Inv_Slot_TORSO>(true);
            for (int i = 0;i < foundType_Torso.Length;i++)
            {
                //Find and assign the foundType to the local Array
                foundType_GO[i] = foundType_Torso[i].gameObject;
            }
            //Sort all the found_GO by name/Number using the IComparer!
            Array.Sort(foundType_GO, new GameObjectComparerByName());

            //Get Toggle component of these foundType_GO and save it to inv_Slot_NAME_Toggles
            for (int i = 0;i < foundType_GO.Length;i++)
            {
                inv_Slot_NAME_Toggles[i] = foundType_GO[i].GetComponent<Toggle>();
            }
        }

        else if (tagScripts_Inv_Slot_NAME == "LEG")
        {
            var foundType_Leg = FindObjectsOfType<TagScripts_Inv_Slot_LEG>(true);
            for (int i = 0;i < foundType_Leg.Length;i++)
            {
                //Find and assign the foundType to the local Array
                foundType_GO[i] = foundType_Leg[i].gameObject;
            }
            //Sort all the found_GO by name/Number using the IComparer!
            Array.Sort(foundType_GO, new GameObjectComparerByName());

            //Get Toggle component of these foundType_GO and save it to inv_Slot_NAME_Toggles
            for (int i = 0;i < foundType_GO.Length;i++)
            {
                inv_Slot_NAME_Toggles[i] = foundType_GO[i].GetComponent<Toggle>();
            }
        }

        else if (tagScripts_Inv_Slot_NAME == "MISC")
        {
            var foundType_Misc = FindObjectsOfType<TagScripts_Inv_Slot_MISC>(true);
            for (int i = 0;i < foundType_Misc.Length;i++)
            {
                //Find and assign the foundType to the local Array
                foundType_GO[i] = foundType_Misc[i].gameObject;
            }
            //Sort all the found_GO by name/Number using the IComparer!
            Array.Sort(foundType_GO, new GameObjectComparerByName());

            //Get Toggle component of these foundType_GO and save it to inv_Slot_NAME_Toggles
            for (int i = 0;i < foundType_GO.Length;i++)
            {
                inv_Slot_NAME_Toggles[i] = foundType_GO[i].GetComponent<Toggle>();
            }
        }

        else
        {
            Debug.Log("Cannot find Inv_Slot -> Check spelling: tagScripts_Inv_Slot_NAME = ALLCAP");
        }
    }


    //This method will update the inventory to show what the player has gain
    //Update SELECTED based on Inv_Slot_NAME categories -> No need to execute the same code for different categories
    //Public to be accessible from the INVENTORY button in MainScreen
    public void UpdateInventory()
    {
        //We use switch-case here to see which code block should be executed
        //The item will be updated anytime the player click the PartTab

        //When click Inventory Button -> case "HAIR" will invoke due to being 1st
        switch (tagScripts_Inv_Slot_NAME)
        {
            case null:
                Debug.Log("No valid name. Can't display Item -> Check Spelling ALLCAP");
                break;

            case "HAIR":
                for (int i = 0;i < gainedItem_IMG.Length;i++)
                {
                    DisplayGainedItem(itemsGainedScriptableObject.HasGainedHairItems[i], i);
                }
                break;

            case "HEAD":
                for (int i = 0;i < gainedItem_IMG.Length / 2;i++)
                {
                    DisplayGainedItem(itemsGainedScriptableObject.HasGainedHeadItems[i], i);
                }
                break;

            case "TORSO":
                for (int i = 0;i < gainedItem_IMG.Length;i++)
                {
                    DisplayGainedItem(itemsGainedScriptableObject.HasGainedTorsoItems[i], i);
                }
                break;

            case "LEG":
                for (int i = 0;i < gainedItem_IMG.Length;i++)
                {
                    DisplayGainedItem(itemsGainedScriptableObject.HasGainedLegItems[i], i);
                }
                break;

            case "MISC":
                for (int i = 0;i < gainedItem_IMG.Length / 2;i++)
                {
                    DisplayGainedItem(itemsGainedScriptableObject.HasGainedMiscItems[i], i);
                }
                break;

        }

    }


    private void DisplayGainedItem(bool hasGainedItem, int gainedItemIndex)
    {
        //If player has NOT gained that item
        if (!hasGainedItem)
        {
            //Make the toggle NOT interactable
            inv_Slot_NAME_Toggles[gainedItemIndex].interactable = false;

            //Turn off the image by make alpha = 0
            gainedItem_IMG[gainedItemIndex].DOFade(0, 0);
        }

        //If player has gained that item
        else
        {
            //Make the toggle interactable
            inv_Slot_NAME_Toggles[gainedItemIndex].interactable = true;

            //Turn that image on by make alpha = 1
            gainedItem_IMG[gainedItemIndex].DOFade(1, 0);
        }
    }

}

class GameObjectComparerByName: IComparer<GameObject>
{
    int IComparer<GameObject>.Compare(GameObject a, GameObject b)
    {
        return string.Compare(a.name, b.name);
    }
}