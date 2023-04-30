using DG.Tweening;
using UnityEngine;

public class InventoryTabZoom_Button: MonoBehaviour
{
    [SerializeField]
    private RectTransform baseBody;
    [SerializeField]
    private RectTransform startingPosGO;

    [Header("Tween values")]
    [SerializeField]
    private DOTweenValuesScriptableObject tweenValuesScriptableObject;

    [Header("TweenScale values")]
    [SerializeField]
    private float hairHeadScaleAmount;
    [SerializeField]
    private float torsoScaleAmount;
    [SerializeField]
    private float legsScaleAmount;


    [SerializeField]
    private RectTransform tweenHairHeadGoal_GO, tweenTorsoGoal_GO, tweenLegsGoal_GO;


    // Start is called before the first frame update
    void Start()
    {
        //Human are dumb so I added this in case I change my mind where the baseBody should start
        //startingPosGO will auto spawn at that point => Safety net
        startingPosGO.transform.position = baseBody.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //method to reset all zooming upon close Inventory
    //and reset View -> Unlike ZoomOut, this is immediately 
    public void ResetZoom()
    {
        baseBody.DOMove(startingPosGO.transform.position,
                        0,
                        tweenValuesScriptableObject.TweenSnapping);
        baseBody.DOScale(1, 0);
    }

    public void HairHead_ZoomIn()
    {
        baseBody.DOMove(tweenHairHeadGoal_GO.transform.position,
                        tweenValuesScriptableObject.TweenDuration,
                        tweenValuesScriptableObject.TweenSnapping);
        baseBody.DOScale(hairHeadScaleAmount, tweenValuesScriptableObject.TweenSpeed);
    }

    public void Torso_ZoomIn()
    {
        baseBody.DOMove(tweenTorsoGoal_GO.transform.position,
                        tweenValuesScriptableObject.TweenDuration,
                        tweenValuesScriptableObject.TweenSnapping);
        baseBody.DOScale(torsoScaleAmount, tweenValuesScriptableObject.TweenSpeed);

    }

    public void Legs_ZoomIn()
    {
        baseBody.DOMove(tweenLegsGoal_GO.transform.position,
                        tweenValuesScriptableObject.TweenDuration,
                        tweenValuesScriptableObject.TweenSnapping);
        baseBody.DOScale(legsScaleAmount, tweenValuesScriptableObject.TweenSpeed);
    }

    public void FullBody_ZoomOut()
    {
        baseBody.DOMove(startingPosGO.transform.position,
                        tweenValuesScriptableObject.TweenDuration,
                        tweenValuesScriptableObject.TweenSnapping);
        baseBody.DOScale(1, tweenValuesScriptableObject.TweenSpeed);
    }
}
