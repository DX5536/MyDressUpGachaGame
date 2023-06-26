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
        //Make sure BodyDrawing is always active at start
        //if not -> set it active
        RepositionBodyDrawing_MainScreen();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Public to access from any Close button in any screen
    public void RepositionBodyDrawing_MainScreen()
    {
        bodyDrawing.transform.position = mainScreen_StartingBodyDrawingPos.transform.position;

        //if GO is not active make it active
        if (!bodyDrawing.gameObject.activeSelf)
        {
            bodyDrawing.gameObject.SetActive(true);
            //bodyDrawing.transform.position = mainScreen_StartingBodyDrawingPos.transform.position;
        }

        else
        {
            Debug.Log("BodyDrawing is already active");
        }

        Debug.Log("Reposition in Main Menu");
    }

    //Public to access from InventoryButton in MainScreen
    public void RepositionBodyDrawing_Inventory()
    {
        bodyDrawing.transform.position = inventory_StartingBodyDrawingPos.transform.position;
        Debug.Log("BodyDrawing spawn in Inventory");
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
