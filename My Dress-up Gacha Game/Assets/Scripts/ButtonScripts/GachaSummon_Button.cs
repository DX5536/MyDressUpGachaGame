using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GachaSummon_Button: MonoBehaviour
{
    [Header("Banner UI")]
    [SerializeField]
    private TextMeshProUGUI shopTitle_TMP;
    [SerializeField]
    private TextMeshProUGUI gainedItem_TMP;
    [SerializeField]
    private Image gainedItem_IMG;
    [SerializeField]
    private TextMeshProUGUI youGain_TMP;

    [SerializeField]
    private Button summon_Button;

    //For easier chance manipulation down the line
    [Header("ItemChance_SO where values are stored")]
    [SerializeField]
    private ItemChancesScriptableObject[] itemChancesScriptableObject;


    [SerializeField]
    private CurrencyScriptableObject currencyScriptableObject;

    [Header("Tween Values")]
    [SerializeField]
    private DOTweenValuesScriptableObject tweenValuesScriptableObject;
    [SerializeField]
    private float tweenScale;

    //[Header("This is so we can start with something and not placeholder text")]
    //[SerializeField]
    private string startBannerTitleName = "Hair Banner";
    //[SerializeField]
    private int startBannerIndex = 0;

    [Header("Numbers_READ ONLY!")]
    [SerializeField]
    private int gainedItem_Index;
    [SerializeField]
    private int perCent;

    //Local values to copy/past from SO
    [SerializeField]
    private string[] localItemNames;
    [SerializeField]
    private int[] localItemChances;
    [SerializeField]
    private Sprite[] localItemImages;

    //This value is to do an internal selection of which banner to pull from
    private int savedBannerIndex;

    // Start is called before the first frame update
    void Start()
    {
        //At start we disable the component
        //Only visible upon click Summon! button
        EnableGainedItemUI(false);

        //At start we will auto default the bannerName to "Hair" and bannerID to 0
        shopTitle_TMP.text = startBannerTitleName;
        savedBannerIndex = startBannerIndex;

        //At start we copy/pasts 0. itemChance_SO's value to localItem
        CopyPasteSOValuesToLocalValues(0);
        CheckEnoughSummonTicket();

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

        //Deactivated previously gainedItem UI upon changing banner
        EnableGainedItemUI(false);
    }

    //public because Unity is a b- for only allow 1 parameter in a button ;_;
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
                         + localItemChances[1])
        {
            gainedItem_Index = 1;
        }

        else if (perCent < localItemChances[0]
                         + localItemChances[1]
                         + localItemChances[2])
        {
            gainedItem_Index = 2;
        }

        else if (perCent < localItemChances[0]
                         + localItemChances[1]
                         + localItemChances[2]
                         + localItemChances[3])
        {
            gainedItem_Index = 3;
        }

        else
        {
            Debug.LogError("ERROR! It should not be possible to go below 0% or above 100% -> Check ScriptableObject");
        }

        ExecuteSelectedBanner();
        EnableGainedItemUI(true);

        //Reduce SummonTicketAmount in SO by 1 after summoning
        currencyScriptableObject.SummonTicketAmount -= 1;

        //Then check if there is still enough summonTicket
        CheckEnoughSummonTicket();
    }

    private void ExecuteSelectedBanner()
    {
        CopyPasteSOValuesToLocalValues(savedBannerIndex);
        BannerDisplayItem();
    }

    //This method is all about copy & paste values from SO to local Var
    //This allow for less typing error + faster typing
    private void CopyPasteSOValuesToLocalValues(int chosenBannerIndex)
    {
        //Make sure array index is same length as SO (human = dumb) -> Length[] is the same anyway
        localItemNames = new string[itemChancesScriptableObject[chosenBannerIndex].ItemChances.Length];
        localItemChances = new int[itemChancesScriptableObject[chosenBannerIndex].ItemChances.Length];
        localItemImages = new Sprite[itemChancesScriptableObject[chosenBannerIndex].ItemChances.Length];

        //Auto copy/paste
        for (int i = 0;i < itemChancesScriptableObject[chosenBannerIndex].ItemChances.Length;i++)
        {
            localItemNames[i] = itemChancesScriptableObject[chosenBannerIndex].ItemNames[i];
            localItemChances[i] = itemChancesScriptableObject[chosenBannerIndex].ItemChances[i];
            localItemImages[i] = itemChancesScriptableObject[chosenBannerIndex].ItemImages[i];
        }
    }

    //This will display the gained item (text + sprites) on the UI
    private void BannerDisplayItem()
    {
        GainedItem_TweenAnimation();
        switch (gainedItem_Index)
        {
            case 0:
                gainedItem_TMP.text = localItemNames[0];
                gainedItem_IMG.sprite = localItemImages[0];
                break;
            case 1:
                gainedItem_TMP.text = localItemNames[1];
                gainedItem_IMG.sprite = localItemImages[1];
                break;
            case 2:
                gainedItem_TMP.text = localItemNames[2];
                gainedItem_IMG.sprite = localItemImages[2];
                break;
            case 3:
                gainedItem_TMP.text = localItemNames[3];
                gainedItem_IMG.sprite = localItemImages[3];
                break;
            case 4:
                gainedItem_TMP.text = localItemNames[4];
                gainedItem_IMG.sprite = localItemImages[4];
                break;
        }
    }

    //This is about activate/deactivate the gainedItem's UI elements
    //public to access in [Close Shop] Button
    public void EnableGainedItemUI(bool toEnableUI)
    {
        //If toEnableUI = false -> disable all the gainedItem UI
        if (!toEnableUI)
        {
            gainedItem_TMP.enabled = false;
            gainedItem_IMG.enabled = false;
            youGain_TMP.enabled = false;
        }

        //if true -> enable all gainedItem UI
        else
        {
            gainedItem_TMP.enabled = true;
            gainedItem_IMG.enabled = true;
            youGain_TMP.enabled = true;
        }

    }

    //public to access from GachaShop Button
    //Else there is a bug that disable button, despite go out and buy more from In-App Shop
    public void CheckEnoughSummonTicket()
    {
        //If there is not enough tickets to summon
        //disable button
        if (currencyScriptableObject.SummonTicketAmount <= 0)
        {
            summon_Button.interactable = false;
        }

        else
        {
            summon_Button.interactable = true;
        }
    }

    private void GainedItem_TweenAnimation()
    {
        gainedItem_TMP.transform.localScale = Vector3.zero;
        gainedItem_IMG.color = new Color(255, 255, 255, 0);

        gainedItem_TMP.DOScale(tweenScale, tweenValuesScriptableObject.TweenDuration);
        gainedItem_IMG.DOFade(1, tweenValuesScriptableObject.TweenDuration);
    }
}
