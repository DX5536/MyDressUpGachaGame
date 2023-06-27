using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MainPanelsTween: MonoBehaviour
{
    [SerializeField]
    private RectTransform inventory_Panel, inApp_Panel, gachaShop_Panel;

    //[SerializeField]
    private Image inventory_Panel_Image, inApp_Panel_Image, gachaShop_Panel_Image;

    [SerializeField]
    private DOTweenValuesScriptableObject DOTweenValuesScriptableObject;

    void Start()
    {
        inventory_Panel_Image = inventory_Panel.GetComponent<Image>();
        inApp_Panel_Image = inApp_Panel.GetComponent<Image>();
        gachaShop_Panel_Image = gachaShop_Panel.GetComponent<Image>();

        inventory_Panel_Image.DOFade(0, 0);
        inApp_Panel_Image.DOFade(0, 0);
        gachaShop_Panel_Image.DOFade(0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public method to accessible from Button
    //The tween should be moving the panel while turn on the Alpha -> appear effects.
    public void ShowTween_InventoryPanel()
    {
        //Instant scale it to 1
        //As when we close it scale down to 0

        //This creates 2 different effect for show and close
        //Show = Fade it
        //Hide = TV effects
        inventory_Panel.DOScaleX(1, 0);
        inventory_Panel_Image.DOFade(1, DOTweenValuesScriptableObject.TweenDuration);
    }

    public void ShowTween_InAppPanel()
    {
        inApp_Panel.DOScaleX(1, 0);
        inApp_Panel_Image.DOFade(1, DOTweenValuesScriptableObject.TweenDuration);
    }

    public void ShowTween_GachaShop()
    {
        gachaShop_Panel.DOScaleX(1, 0);
        gachaShop_Panel_Image.DOFade(1, DOTweenValuesScriptableObject.TweenDuration);
    }

    public void HideTween_ScaleX_AllPanels(string panelName)
    {
        if (panelName == inventory_Panel.gameObject.name)
        {
            inventory_Panel.DOScaleX(0, DOTweenValuesScriptableObject.TweenDuration);
            inventory_Panel_Image.DOFade(0, DOTweenValuesScriptableObject.TweenDuration);
        }

        else if (panelName == inApp_Panel.gameObject.name)
        {
            inApp_Panel.DOScaleX(0, DOTweenValuesScriptableObject.TweenDuration);
            inApp_Panel_Image.DOFade(0, DOTweenValuesScriptableObject.TweenDuration);
        }

        else if (panelName == gachaShop_Panel.gameObject.name)
        {
            gachaShop_Panel.DOScaleX(0, DOTweenValuesScriptableObject.TweenDuration);
            gachaShop_Panel_Image.DOFade(0, DOTweenValuesScriptableObject.TweenDuration);
        }

        else
        {
            Debug.Log("panelName does not match with any Panels -> Check Spelling 1-to-1");
        }

    }

}
