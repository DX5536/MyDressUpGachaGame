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
    private float tweenDuration;
    [SerializeField]
    private float tweenSpeed;
    [SerializeField]
    private bool tweenSnapping;

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
        baseBody.DOMove(startingPosGO.transform.position, 0, tweenSnapping);
        baseBody.DOScale(1, 0);
    }

    public void HairHead_ZoomIn()
    {
        baseBody.DOMove(tweenHairHeadGoal_GO.transform.position, tweenDuration, tweenSnapping);
        baseBody.DOScale(hairHeadScaleAmount, tweenSpeed);
    }

    public void Torso_ZoomIn()
    {
        baseBody.DOMove(tweenTorsoGoal_GO.transform.position, tweenDuration, tweenSnapping);
        baseBody.DOScale(torsoScaleAmount, tweenSpeed);

    }

    public void Legs_ZoomIn()
    {
        baseBody.DOMove(tweenLegsGoal_GO.transform.position, tweenDuration, tweenSnapping);
        baseBody.DOScale(legsScaleAmount, tweenSpeed);
    }

    public void FullBody_ZoomOut()
    {
        baseBody.DOMove(startingPosGO.transform.position, tweenDuration, tweenSnapping);
        baseBody.DOScale(1, tweenSpeed);
    }
}
