using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMainScreenUI_Button: MonoBehaviour
{
    [SerializeField]
    private Button hideUI_Button, showUI_Button;

    [SerializeField]
    private RectTransform mainScreenUI_Panel;
    [SerializeField]
    private RectTransform bodyDrawing;

    [Header("Tween values UI")]
    [SerializeField]
    private DOTweenValuesScriptableObject tweenValuesScriptableObject;
    [SerializeField]
    private RectTransform startingMainScreenPosition;
    [SerializeField]
    private RectTransform mainScreenTweenGoal;

    [Header("Tween Values BodyDrawing")]
    [SerializeField]
    private RectTransform startingBodyDrawingPosition;
    [SerializeField]
    private RectTransform bodyDrawingTweenGoal;

    // Start is called before the first frame update
    void Start()
    {
        //at start make sure MainScreenUI_Panel is ON
        //and showUI_Button = inactive (big giant invisible button)
        mainScreenUI_Panel.gameObject.SetActive(true);
        showUI_Button.gameObject.SetActive(false);

        startingMainScreenPosition.position = mainScreenUI_Panel.position;
        //startingBodyDrawingPosition.position = bodyDrawing.position;
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

        BodyDrawingWhenShowMainScreen();

        //Disable showUI_Button
        showUI_Button.gameObject.SetActive(false);
    }

    public void HideMainScreenUI()
    {
        //Panel will tween to the side
        //*2 so it's hidden completely
        mainScreenUI_Panel.DOMove(mainScreenTweenGoal.transform.position * 1.1f,
                                  tweenValuesScriptableObject.TweenDuration,
                                  tweenValuesScriptableObject.TweenSnapping).OnComplete(OnTweenComplete);
        BodyDrawingWhenHideMainScreen();

    }

    private void BodyDrawingWhenShowMainScreen()
    {
        //When UI is present
        //The body will be in the middle of the 2/3 on the left
        bodyDrawing.DOMove(startingBodyDrawingPosition.transform.position,
                           tweenValuesScriptableObject.TweenDuration,
                           tweenValuesScriptableObject.TweenSnapping);
    }

    private void BodyDrawingWhenHideMainScreen()
    {
        //When hide the main screen
        //The body will move into the middle of the screen
        bodyDrawing.DOMove(bodyDrawingTweenGoal.transform.position,
                           tweenValuesScriptableObject.TweenDuration,
                           tweenValuesScriptableObject.TweenSnapping);

    }


    private void OnTweenComplete()
    {
        //Enable back show UI button
        //This is to make sure the button only active AFTER tween is done
        showUI_Button.gameObject.SetActive(true);
    }
}
