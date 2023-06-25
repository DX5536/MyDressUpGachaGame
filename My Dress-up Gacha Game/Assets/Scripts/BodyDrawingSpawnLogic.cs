using UnityEngine;

public class BodyDrawingSpawnLogic: MonoBehaviour
{
    [SerializeField]
    private GameObject mainScreen_Panel, inventory_Panel, gachaShop_Panel, inApp_Panel;

    [Header("Body Drawing GO")]
    [SerializeField]
    private RectTransform bodyDrawing;

    [Header("Starting position")]
    [SerializeField]
    private RectTransform mainScreen_StartingBodyDrawingPos;

    [SerializeField]
    private RectTransform inventory_StartingBodyDrawingPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Public to access from any Close button in any screen
    public void RepositionBodyDrawing_MainScreen()
    {
        //if GO is not active make it active
        if (!bodyDrawing.gameObject.activeSelf)
        {
            bodyDrawing.gameObject.SetActive(true);
        }

        else
        {
            Debug.Log("BodyDrawing is already active");
        }

        bodyDrawing.transform.position = mainScreen_StartingBodyDrawingPos.position;
    }

    //Public to access from InventoryButton in MainScreen
    public void RepositionBodyDrawing_Inventory()
    {
        if (inventory_Panel.activeSelf)
        {
            bodyDrawing.transform.position = inventory_StartingBodyDrawingPos.position;
        }
    }

    public void RepositionBodyDrawing_Shop()
    {
        if (inApp_Panel.activeSelf || gachaShop_Panel.activeSelf)
        {
            //We hide the bodyDrawing when open the 2 shops
            bodyDrawing.gameObject.SetActive(false);
        }

    }
}
