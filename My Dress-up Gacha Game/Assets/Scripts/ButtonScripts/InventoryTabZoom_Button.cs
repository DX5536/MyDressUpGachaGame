using DG.Tweening;
using UnityEngine;

public class InventoryTabZoom_Button: MonoBehaviour
{
    [SerializeField]
    private RectTransform bodyDrawing;
    [SerializeField]
    private RectTransform startingPosGO;

    [SerializeField]
    private float startingScaleValue;

    [Header("Tween values")]
    [SerializeField]
    private DOTweenValuesScriptableObject tweenValuesScriptableObject;

    [Header("TweenScale values")]
    [SerializeField]
    private float hairScaleAmount;
    [SerializeField]
    private float headScaleAmount;
    [SerializeField]
    private float torsoScaleAmount;
    [SerializeField]
    private float legsScaleAmount;


    [SerializeField]
    private RectTransform tweenHairGoal_GO, tweenHeadGoal_GO, tweenTorsoGoal_GO, tweenLegsGoal_GO;


    // Start is called before the first frame update
    void Start()
    {
        //Human are dumb so I added this in case I change my mind where the bodyDrawing should start
        //startingPosGO will auto spawn at that point => Safety net
        startingPosGO.transform.position = bodyDrawing.position;

        startingScaleValue = bodyDrawing.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //method to reset all zooming upon close Inventory
    //and reset View -> Unlike ZoomOut, this is immediately 
    public void ResetZoom()
    {
        bodyDrawing.DOMove(startingPosGO.transform.position,
                        0,
                        tweenValuesScriptableObject.TweenSnapping);
        bodyDrawing.DOScale(startingScaleValue, 0);
    }

    public void Hair_ZoomIn()
    {
        bodyDrawing.DOMove(tweenHairGoal_GO.transform.position,
                        tweenValuesScriptableObject.TweenDuration,
                        tweenValuesScriptableObject.TweenSnapping);
        bodyDrawing.DOScale(startingScaleValue * hairScaleAmount, tweenValuesScriptableObject.TweenSpeed);
    }

    public void Head_ZoomIn()
    {
        bodyDrawing.DOMove(tweenHeadGoal_GO.transform.position,
                        tweenValuesScriptableObject.TweenDuration,
                        tweenValuesScriptableObject.TweenSnapping);
        bodyDrawing.DOScale(startingScaleValue * headScaleAmount, tweenValuesScriptableObject.TweenSpeed);
    }

    public void Torso_ZoomIn()
    {
        bodyDrawing.DOMove(tweenTorsoGoal_GO.transform.position,
                        tweenValuesScriptableObject.TweenDuration,
                        tweenValuesScriptableObject.TweenSnapping);
        bodyDrawing.DOScale(startingScaleValue * torsoScaleAmount, tweenValuesScriptableObject.TweenSpeed);

    }

    public void Legs_ZoomIn()
    {
        bodyDrawing.DOMove(tweenLegsGoal_GO.transform.position,
                        tweenValuesScriptableObject.TweenDuration,
                        tweenValuesScriptableObject.TweenSnapping);
        bodyDrawing.DOScale(startingScaleValue * legsScaleAmount, tweenValuesScriptableObject.TweenSpeed);
    }

    public void FullBody_ZoomOut()
    {
        bodyDrawing.DOMove(startingPosGO.transform.position,
                        tweenValuesScriptableObject.TweenDuration,
                        tweenValuesScriptableObject.TweenSnapping);
        bodyDrawing.DOScale(startingScaleValue, tweenValuesScriptableObject.TweenSpeed);
    }
}
