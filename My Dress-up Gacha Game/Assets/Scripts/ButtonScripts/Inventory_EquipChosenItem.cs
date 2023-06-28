using UnityEngine;
using UnityEngine.UI;

public class Inventory_EquipChosenItem: MonoBehaviour
{
    [Header("Array in case there are 2 sprites of an object (eg. Hair)")]
    [SerializeField]
    private SpriteRenderer[] selected_BodyDrawing_Items;

    [SerializeField]
    private Toggle inv_Slot_;

    // Start is called before the first frame update
    void Start()
    {
        inv_Slot_ = this.GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public to access from OnValueChanged(bool) of the toggle
    public void Un_Equip_Item(bool isItemEquipped)
    {
        if (isItemEquipped)
        {
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
}
