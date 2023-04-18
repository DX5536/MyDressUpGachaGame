using TMPro;
using UnityEngine;

public class GachaSummon_Button: MonoBehaviour
{
    [Header("Banner logic")]
    [SerializeField]
    private TextMeshProUGUI shopTitle_TMP;
    [SerializeField]
    private TextMeshProUGUI gainedItem_TMP;
    [SerializeField]
    private TextMeshProUGUI youGain_TMP;

    //For easier chance manipulation down the line
    [Header("ItemChance_SO where % are stored")]
    [SerializeField]
    private ItemChancesScriptableObject itemChancesScriptableObject;

    [Header("This is so we can start with something and not placeholder text")]
    [SerializeField]
    private string startBannerTitleName;
    [SerializeField]
    private int startBannerIndex = 0;

    [Header("Numbers_READ ONLY")]
    [SerializeField]
    private int gainedItem_Index;
    [SerializeField]
    private int perCent;
    [SerializeField]
    private int[] localItemChances;

    //This value is to do an internal selection of which banner to pull from
    private int savedBannerIndex;

    // Start is called before the first frame update
    void Start()
    {
        //At start we disable the component
        //Only visible upon click Summon! button
        gainedItem_TMP.enabled = false;
        youGain_TMP.enabled = false;

        //At start we will auto default the bannerName to "Hair" and bannerID to 0
        shopTitle_TMP.text = startBannerTitleName;
        savedBannerIndex = startBannerIndex;

        //At start we copy and past itemChance_SO's value to localItemChances
        localItemChances = new int[itemChancesScriptableObject.ItemChances.Length];
        for (int i = 0;i < itemChancesScriptableObject.ItemChances.Length;i++)
        {
            localItemChances[i] = itemChancesScriptableObject.ItemChances[i];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public to access from Banner selection button
    public void Selection_BannerName(string bannerName)
    {
        //Change the PanelTitle to the name
        shopTitle_TMP.text = bannerName;
    }
    //public cuz Unity is a b for only allow 1 parameter in a button ;_;
    public void Selection_BannerID(int bannerID)
    {
        //Save the ID of the banner locally so we know which item to be summoned
        savedBannerIndex = bannerID;
    }

    //public method to access in Summon! button
    public void SummonLogic()
    {
        //A random number will be generate
        perCent = Random.Range(0, 100);

        if (perCent < localItemChances[0])
        {
            gainedItem_Index = 0;
        }

        else if (perCent < localItemChances[0]
                         + localItemChances[0 + 1])
        {
            gainedItem_Index = 0 + 1;
        }

        else if (perCent < localItemChances[0]
                         + localItemChances[0 + 1]
                         + localItemChances[0 + 2])
        {
            gainedItem_Index = 0 + 2;
        }

        else if (perCent < localItemChances[0]
                         + localItemChances[0 + 1]
                         + localItemChances[0 + 2]
                         + localItemChances[0 + 3])
        {
            gainedItem_Index = 0 + 2;
        }

        else
        {
            Debug.Log("ERROR! It should not be possible to go below 0% or above 100%");
        }


        //Short hair has 70%
        /*if (perCent < itemChancesScriptableObject.ItemChances[0])
        {
            gainedItem_Index = 0;
        }
        //long hair has 20%
        else if (perCent < itemChancesScriptableObject.ItemChances[0]
                         + itemChancesScriptableObject.ItemChances[1])
        {
            gainedItem_Index = 1;
        }
        //ponytail has 7%
        else if (perCent < itemChancesScriptableObject.ItemChances[0]
                         + itemChancesScriptableObject.ItemChances[1]
                         + itemChancesScriptableObject.ItemChances[2])
        {
            gainedItem_Index = 2;
        }
        //braid has 3%
        else if (perCent < itemChancesScriptableObject.ItemChances[0]
                         + itemChancesScriptableObject.ItemChances[1]
                         + itemChancesScriptableObject.ItemChances[2]
                         + itemChancesScriptableObject.ItemChances[3])
        {
            gainedItem_Index = 3;
        }
        else
        {
            Debug.Log("ERROR! It should not be possible to go below 0% or above 100%");
        }*/

        ExecuteSelectedBanner();
        gainedItem_TMP.enabled = true;
        youGain_TMP.enabled = true;
    }

    private void ExecuteSelectedBanner()
    {
        switch (savedBannerIndex)
        {
            case 0:
                HairBanner();
                break;
            case 1:
                TopBanner();
                break;

        }
    }

    private void HairBanner()
    {
        switch (gainedItem_Index)
        {
            case 0:
                gainedItem_TMP.text = "short hair";
                break;
            case 1:
                gainedItem_TMP.text = "long hair";
                break;
            case 2:
                gainedItem_TMP.text = "ponytail";
                break;
            case 3:
                gainedItem_TMP.text = "braids";
                break;
        }
    }

    private void TopBanner()
    {
        switch (gainedItem_Index)
        {
            case 0:
                gainedItem_TMP.text = "T-shirt";
                break;
            case 1:
                gainedItem_TMP.text = "Vest";
                break;
            case 2:
                gainedItem_TMP.text = "Bomber Jacket";
                break;
            case 3:
                gainedItem_TMP.text = "Frilled Shirt";
                break;
        }
    }
}
