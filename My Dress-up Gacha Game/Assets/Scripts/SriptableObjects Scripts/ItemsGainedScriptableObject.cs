using UnityEngine;

[CreateAssetMenu(fileName = "ItemGained", menuName = "ScriptableObject/ItemGained", order = 3)]
public class ItemsGainedScriptableObject: ScriptableObject
{
    [SerializeField]
    private bool resetGainedItemsValue;

    public bool ResetGainedItemsValue
    {
        get
        {
            return resetGainedItemsValue;
        }
        set
        {
            resetGainedItemsValue = value;
        }
    }


    [Header("Gained Hair items: True/False")]
    [SerializeField]
    private bool[] hasGainedHairItems;

    public bool[] HasGainedHairItems
    {
        get
        {
            return hasGainedHairItems;
        }
        set
        {
            hasGainedHairItems = value;
        }
    }

    [Header("Gained Head items: True/False")]
    [SerializeField]
    private bool[] hasGainedHeadItems;

    public bool[] HasGainedHeadItems
    {
        get
        {
            return hasGainedHeadItems;
        }
        set
        {
            hasGainedHeadItems = value;
        }
    }

    [Header("Gained Torso items: True/False")]
    [SerializeField]
    private bool[] hasGainedTorsoItems;

    public bool[] HasGainedTorsoItems
    {
        get
        {
            return hasGainedTorsoItems;
        }
        set
        {
            hasGainedTorsoItems = value;
        }
    }

    [Header("Gained Leg items: True/False")]
    [SerializeField]
    private bool[] hasGainedLegItems;

    public bool[] HasGainedLegItems
    {
        get
        {
            return hasGainedLegItems;
        }
        set
        {
            hasGainedLegItems = value;
        }
    }

    [Header("Gained Misc items: True/False")]
    [SerializeField]
    private bool[] hasGainedMiscItems;

    public bool[] HasGainedMiscItems
    {
        get
        {
            return hasGainedMiscItems;
        }
        set
        {
            hasGainedMiscItems = value;
        }
    }

}
