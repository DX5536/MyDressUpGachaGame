using System.Collections;
using System.Linq;
using UnityEngine;

public class Intentory_UnequipAll_ALT: MonoBehaviour
{
    [Header("Array in case there are 2 sprites of an object (eg. Hair)")]
    [SerializeField]
    private SpriteRenderer[] selected_BodyDrawing_Items;

    [SerializeField]
    private GameObject[] bodyDrawing_ITEMS;

    //Access the list of toggles there
    [SerializeField]
    private DisplayGainedItemInInventory displayGainedItemInInventory;
    [SerializeField]
    private int toggleIndex;

    //[SerializeField]
    //private string itemSpriteTag;

    // Start is called before the first frame update
    void Start()
    {
        //bodyDrawing_ITEMS = GameObject.FindGameObjectsWithTag(itemSpriteTag);


        DeactivateALLItems();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //This is a workaround as FindGameObectsWithTag cannot find inactive Items
    //So first all the items are active (Frankenstein) -> Found and save -> Deactivate them
    public void DeactivateALLItems()
    {
        foreach (var item in bodyDrawing_ITEMS)
        {
            item.SetActive(false);
        }

        foreach (var toggle in displayGainedItemInInventory.Inv_Slot_NAME_Toggles)
        {
            toggle.isOn = false;
        }

    }

    //public to access from OnValueChanged(bool) of the toggle
    public void Un_Equip_Item(bool isItemEquipped)
    {
        StartCoroutine(SmallDelay());

        if (isItemEquipped)
        {
            for (int i = 0;i < displayGainedItemInInventory.Inv_Slot_NAME_Toggles.Length;i++)
            {
                if (i != toggleIndex)
                {
                    displayGainedItemInInventory.Inv_Slot_NAME_Toggles[i].isOn = false;
                }
            }

            foreach (var item in selected_BodyDrawing_Items)
            {
                item.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (var item in selected_BodyDrawing_Items)
            {
                displayGainedItemInInventory.Inv_Slot_NAME_Toggles[toggleIndex].isOn = false;
                item.gameObject.SetActive(false);
            }
        }
    }

    private void ToggleIsOn(int caseIndex)
    {
        //This is the safe proof in case in dex is larger than count 
        if (caseIndex >= displayGainedItemInInventory.Inv_Slot_NAME_Toggles.Count())
        {
            return;
        }
        displayGainedItemInInventory.Inv_Slot_NAME_Toggles[caseIndex].isOn = true;
    }


    //First deactivate all GO of that group before turning a specific on
    IEnumerator SmallDelay()
    {
        DeactivateALLItems();
        yield return new WaitForSeconds(0.1f);
    }
}
