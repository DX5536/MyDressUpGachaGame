using System;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        foundChild = GameObject.FindGameObjectsWithTag(itemIMG_Tag);

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
                Debug.Log(slotGridPanel.name + " is not working: " + foundChild[i]);
            }
        }


        Find_Inv_SlotOfType();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //This method will find all the Inv_Slot of that category
    //We need to access to the toggle of that Inv_Slot
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

}

class GameObjectComparerByName: IComparer<GameObject>
{
    int IComparer<GameObject>.Compare(GameObject a, GameObject b)
    {
        return string.Compare(a.name, b.name);
    }
}