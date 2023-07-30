using UnityEngine;

[CreateAssetMenu(fileName = "DOTweenValues", menuName = "ScriptableObject/DOTween", order = 2)]
public class DOTweenValuesScriptableObject: ScriptableObject
{
    [Header("Tween values")]
    [SerializeField]
    private float tweenDuration;
    [SerializeField]
    private float tweenSpeed;
    [SerializeField]
    private bool tweenSnapping;

    public float TweenDuration
    {
        get => tweenDuration;
    }
    public float TweenSpeed
    {
        get => tweenSpeed;
    }
    public bool TweenSnapping
    {
        get => tweenSnapping;
    }
}
