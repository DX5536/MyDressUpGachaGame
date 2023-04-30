using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMainScreenUI_Button: MonoBehaviour
{
    [SerializeField]
    private Button hideUI_Button, showUI_Button;

    [SerializeField]
    private RectTransform mainScreenUI_Panel;

    [Header("Tween values")]
    [SerializeField]
    private DOTweenValuesScriptableObject tweenValuesScriptableObject;
    [SerializeField]
    private RectTransform startingMainScreenPosition;
    [SerializeField]
    private RectTransform mainScreenTweenGoal;

    // Start is called before the first frame update
    void Start()
    {
        //at start make sure MainScreenUI_Panel is ON
        //and showUI_Button = inactive (big giant invisible button)
        mainScreenUI_Panel.gameObject.SetActive(true);
        showUI_Button.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public to access from button
    public void ShowMainScreenUI()
    {
        //Panel will tween to back to original spot
        mainScreenUI_Panel.DOMove(startingMainScreenPosition.transform.position,
                                  tweenValuesScriptableObject.TweenDuration,
                                  tweenValuesScriptableObject.TweenSnapping);
        //Disable showUI_Button
        showUI_Button.gameObject.SetActive(false);
    }

    public void HideMainScreenUI()
    {
        //Panel will tween to the side
        mainScreenUI_Panel.DOMove(mainScreenTweenGoal.transform.position,
                                  tweenValuesScriptableObject.TweenDuration,
                                  tweenValuesScriptableObject.TweenSnapping).OnComplete(OnTweenComplete);

    }

    private void OnTweenComplete()
    {
        //Enable back show UI button
        //This is to make sure the button only active AFTER tween is done
        showUI_Button.gameObject.SetActive(true);
    }
}
