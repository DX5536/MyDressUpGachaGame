using System.Collections;
using UnityEngine;

public class Inventory_EquipChosenItem: MonoBehaviour
{
    [Header("Array in case there are 2 sprites of an object (eg. Hair)")]
    [SerializeField]
    private SpriteRenderer[] selected_BodyDrawing_Items;

    [SerializeField]
    private GameObject[] bodyDrawing_ITEMS;

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


    }

    //public to access from OnValueChanged(bool) of the toggle
    public void Un_Equip_Item(bool isItemEquipped)
    {

        if (isItemEquipped)
        {
            StartCoroutine(SmallDelay());
            foreach (var item in selected_BodyDrawing_Items)
            {

                item.gameObject.SetActive(true);

            }
        }

        else
        {
            foreach (var item in selected_BodyDrawing_Items)
            {
                item.gameObject.SetActive(false);
            }
        }
    }


    //First deactivate all GO of that group before turning a specific on
    IEnumerator SmallDelay()
    {
        DeactivateALLItems();
        yield return new WaitForSeconds(0.1f);
    }
}
