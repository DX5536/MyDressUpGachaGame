using UnityEngine;
using UnityEngine.UI;

public class DisplayGainedItemInInventory: MonoBehaviour
{
    [SerializeField]
    private ItemsGainedScriptableObject itemsGainedScriptableObject;

    [SerializeField]
    private Transform slotGridPanel;

    [SerializeField]
    private string inv_Slot_;

    [SerializeField]
    private Image[] gainedItem_IMG;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0;i < gainedItem_IMG.Length;i++)
        {
            //This will automatically assign the gainedItem_Image to the script
            //We can extend(reduce the slots in the future -> Auto change
            gainedItem_IMG[i] = slotGridPanel.Find(inv_Slot_ + i.ToString()).GetComponentInChildren<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
