using UnityEngine;

[CreateAssetMenu(fileName = "ItemChances", menuName = "ScriptableObject/ItemValue", order = 0)]
public class ItemChancesScriptableObject: ScriptableObject
{
    [SerializeField]
    private int bannerItemIndex;

    public int BannerItemIndex
    {
        get
        {
            return bannerItemIndex;
        }
        set
        {
            bannerItemIndex = value;
        }
    }


    [Header("Name of the items")]
    [SerializeField]
    private string[] itemNames;

    public string[] ItemNames
    {
        get
        {
            return itemNames;
        }
    }

    [Header("% of the items: Start at big% -> small%")]
    [SerializeField]
    private int[] itemChances;

    public int[] ItemChances
    {
        get
        {
            return itemChances;
        }

        //no set as we only read the values
    }

    [Header("Images of the items")]
    [SerializeField]
    private Sprite[] itemImages;

    public Sprite[] ItemImages
    {
        get
        {
            return itemImages;
        }

        //no set as we only read the values
    }


}
