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

    [SerializeField]
    private GameObject[] foundChild;

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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
