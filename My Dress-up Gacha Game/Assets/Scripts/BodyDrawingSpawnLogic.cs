using UnityEngine;

public class BodyDrawingSpawnLogic: MonoBehaviour
{
    [SerializeField]
    private GameObject mainScreen_Panel, inventory_Panel, gachaShop_Panel, inApp_Panel;

    [Header("Body Drawing GO")]
    [SerializeField]
    private RectTransform bodyDrawing;

    [SerializeField]
    private float scaleValue;

    [Header("Starting position")]
    [SerializeField]
    private RectTransform mainScreen_StartingBodyDrawingPos;

    [SerializeField]
    private RectTransform inventory_StartingBodyDrawingPos;

    // Start is called before the first frame update
    void Start()
    {
        scaleValue = bodyDrawing.transform.localScale.x;
        mainScreen_StartingBodyDrawingPos.transform.position = bodyDrawing.transform.position;

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
        bodyDrawing.gameObject.SetActive(true);
        bodyDrawing.transform.position = mainScreen_StartingBodyDrawingPos.transform.position;
        bodyDrawing.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);

        //if GO is not active make it active
        /*if (!bodyDrawing.gameObject.activeSelf)
        {
            //bodyDrawing.gameObject.SetActive(true);
            //bodyDrawing.transform.position = mainScreen_StartingBodyDrawingPos.transform.position;
            Debug.Log("BodyDrawing is inactive.");
        }

        else
        {
            //bodyDrawing.gameObject.SetActive(true);
            //bodyDrawing.transform.position = mainScreen_StartingBodyDrawingPos.transform.position;
            Debug.Log("BodyDrawing is already active.");
        }*/


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
