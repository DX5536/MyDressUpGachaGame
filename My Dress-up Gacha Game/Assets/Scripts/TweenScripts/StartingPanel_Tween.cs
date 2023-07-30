using DG.Tweening;
using UnityEngine;

public class StartingPanel_Tween: MonoBehaviour
{
    [SerializeField]
    private DOTweenValuesScriptableObject _tweenValuesScriptableObject;
    [SerializeField]
    private RectTransform starting_Panel;
    [SerializeField]
    private RectTransform startingPanel_TweenGoal;

    [SerializeField]
    private GameObject bodyDrawing_Panel, bodyDrawing_PlaceHolder;


    //At start we need to hide bodyDrawing Panel
    private void Start()
    {
        bodyDrawing_Panel.SetActive(false);
        //This placeholder will act as if bodyDrawing is display underneath UI Panels despite using SpriteRenderer
        bodyDrawing_PlaceHolder.SetActive(true);
    }

    public void StartGame_button()
    {
        starting_Panel.DOMove(startingPanel_TweenGoal.transform.position,
            _tweenValuesScriptableObject.TweenDuration,
            _tweenValuesScriptableObject.TweenSnapping).OnComplete(OnTweenComplete);
    }

    private void OnTweenComplete()
    {
        starting_Panel.gameObject.SetActive(false);
        bodyDrawing_Panel.SetActive(true);
        bodyDrawing_PlaceHolder.SetActive(false);
    }
}
