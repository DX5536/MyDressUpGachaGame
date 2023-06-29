using UnityEngine;
using UnityEngine.Events;

public class Inventory_EquipChosenItem: MonoBehaviour
{
    [Header("Array in case there are 2 sprites of an object (eg. Hair)")]
    [SerializeField]
    private SpriteRenderer[] selected_BodyDrawing_Items;

    [SerializeField]
    private UnityEvent unequipAllItems_TurnOffToggle_Event;

    [Header("We need this to access the list of SpriteRenderer of bodyDrawing")]
    [SerializeField]
    private BodyDrawingSpawnLogic bodyDrawingSpawnLogic;

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
        unequipAllItems_TurnOffToggle_Event?.Invoke();

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
