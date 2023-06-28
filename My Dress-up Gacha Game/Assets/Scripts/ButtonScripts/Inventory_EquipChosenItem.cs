using UnityEngine;
using UnityEngine.UI;

public class Inventory_EquipChosenItem: MonoBehaviour
{
    [SerializeField]
    private GameObject selected_BodyDrawing_Item;

    [SerializeField]
    private Toggle inv_Slot_;

    // Start is called before the first frame update
    void Start()
    {

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
            selected_BodyDrawing_Item.SetActive(true);
        }
        else
        {
            selected_BodyDrawing_Item.SetActive(false);
        }
    }
}
