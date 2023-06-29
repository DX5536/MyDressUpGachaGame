using DG.Tweening;
using UnityEngine;

public class BodyDrawingSpawnLogic: MonoBehaviour
{
    [SerializeField]
    private GameObject mainScreen_Panel, inventory_Panel, gachaShop_Panel, inApp_Panel;

    [Header("Body Drawing GO")]
    [SerializeField]
    private RectTransform bodyDrawing;

    //[SerializeField]
    private float scaleValue;

    [SerializeField]
    private SpriteRenderer[] bodyDrawingSpriteRenderers;

    [SerializeField]
    private DOTweenValuesScriptableObject DOTweenValuesScriptableObject;
    [SerializeField]
    private float fadeInOutMultiplier = 1;

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

        //I'm lazy and I want to automatically find all the sprites within BodyDrawing (as they are the only one with SpriteRenderer).
        //Find All Sprite Renderer
        bodyDrawingSpriteRenderers = FindObjectsOfType<SpriteRenderer>(true);

        //Make sure BodyDrawing is always active at start
        //if not -> set it active
        RepositionBodyDrawing_MainScreen();
    }

    private void Fade_BodyDrawing(bool isFadeIn)
    {
        //If we are fade in the bodyDrawing aka. make it appears
        if (isFadeIn)
        {
            //turn on all the alpha of bodyDrawingSpriteRenderers to 1
            foreach (SpriteRenderer bodyItem in bodyDrawingSpriteRenderers)
            {
                bodyItem.DOFade(0, 0);
                bodyItem.DOFade(1, DOTweenValuesScriptableObject.TweenDuration * fadeInOutMultiplier);
            }
        }

        //If we are fade out aka. make it disappear
        else
        {
            //turn on all the alpha of bodyDrawingSpriteRenderers to 0
            foreach (SpriteRenderer bodyItem in bodyDrawingSpriteRenderers)
            {
                bodyItem.DOFade(1, 0);
                bodyItem.DOFade(0, DOTweenValuesScriptableObject.TweenDuration);
            }
        }

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
        Fade_BodyDrawing(true);

    }

    //Public to access from InventoryButton in MainScreen
    //Unlike other Panel, bodyDrawing moves to another position instead of being deactivated
    public void RepositionBodyDrawing_Inventory()
    {
        Fade_BodyDrawing(true);
        bodyDrawing.transform.position = inventory_StartingBodyDrawingPos.transform.position;
        //Debug.Log("BodyDrawing spawn in Inventory");
    }

    public void RepositionBodyDrawing_Shop()
    {
        if (inApp_Panel.activeSelf || gachaShop_Panel.activeSelf)
        {
            bodyDrawing.gameObject.SetActive(false);
        }
    }

}
