using System;
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
    private GameObject summon1x_Panel, summon10x_Panel;

    [SerializeField]
    private Button summon_Button;

    //For easier chance manipulation down the line
    [Header("ItemChance_SO where values are stored")]
    [SerializeField]
    private ItemChancesScriptableObject[] itemChancesScriptableObject;

    [SerializeField]
    private ItemsGainedScriptableObject itemsGainedScriptableObject;

    [SerializeField]
    private CurrencyScriptableObject currencyScriptableObject;

    [Header("Tween Values")]
    [SerializeField]
    private DOTweenValuesScriptableObject tweenValuesScriptableObject;
    [SerializeField]
    private float tweenScale;

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
    //[SerializeField]
    private int savedBannerIndex;

    private void OnEnable()
    {
        if (itemsGainedScriptableObject.ResetGainedItemsValue)
        {
            for (int i = 0;i < itemsGainedScriptableObject.HasGainedHairItems.Length;i++)
            {
                itemsGainedScriptableObject.HasGainedHairItems[i] = false;
                itemsGainedScriptableObject.HasGainedHeadItems[i] = false;
                itemsGainedScriptableObject.HasGainedTorsoItems[i] = false;
                itemsGainedScriptableObject.HasGainedLegItems[i] = false;
                itemsGainedScriptableObject.HasGainedMiscItems[i] = false;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        summon1x_Panel.SetActive(false);

        //At start we copy/pasts 0. itemChance_SO's value to localItem
        UpdateLocalValuesFromSO();
        CheckEnoughSummonTicket();

    }

    //public method to access in Summon! button
    public void SummonLogic()
    {
        //Make sure summon10x_Panel is deactivated
        summon10x_Panel.SetActive(false);
        //and summon1x_Panel is activated
        summon1x_Panel.SetActive(true);

        UpdateLocalValuesFromSO();

        //A random number will be generate
        perCent = UnityEngine.Random.Range(0, 100);

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

        //Reduce SummonTicketAmount in SO by 1 after summoning
        currencyScriptableObject.SummonTicketAmount -= 1;

        //Then check if there is still enough summonTicket
        CheckEnoughSummonTicket();
    }

    private void UpdateLocalValuesFromSO()
    {
        savedBannerIndex = itemsGainedScriptableObject.CurrentlySelectedBannerID;
        CopyPasteSOValuesToLocalValues(savedBannerIndex);
    }

    private void ExecuteSelectedBanner()
    {
        BannerDisplayItem();
        EnableGainedItemUI(true);
    }

    //This method is all about copy & paste values from SO to local Var
    //This allow for less typing error + faster typing
    //public method so we can access from TenPulls -> Else banner is not updated upon clicking 10x Summon
    public void CopyPasteSOValuesToLocalValues(int chosenBannerIndex)
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
    //And save the Item as "have" aka. hasGainedXXXItem = true
    private void BannerDisplayItem()
    {
        GainedItem_TweenAnimation();
        switch (gainedItem_Index)
        {
            case 0:
                gainedItem_TMP.text = localItemNames[0];
                gainedItem_IMG.sprite = localItemImages[0];

                SavedDisplayItem(0);
                break;
            case 1:
                gainedItem_TMP.text = localItemNames[1];
                gainedItem_IMG.sprite = localItemImages[1];

                SavedDisplayItem(1);
                break;
            case 2:
                gainedItem_TMP.text = localItemNames[2];
                gainedItem_IMG.sprite = localItemImages[2];

                SavedDisplayItem(2);
                break;
            case 3:
                gainedItem_TMP.text = localItemNames[3];
                gainedItem_IMG.sprite = localItemImages[3];

                SavedDisplayItem(3);
                break;
            case 4:
                gainedItem_TMP.text = localItemNames[4];
                gainedItem_IMG.sprite = localItemImages[4];

                SavedDisplayItem(4);
                break;
        }
    }

    //This method will mark the gained item on which banner, based on chosenBannerIndex, to "HasGained"
    //For saving purposes and to display in Inventory (button being interactable -> equip item)
    private void SavedDisplayItem(int saveGainedItemID)
    {
        switch (savedBannerIndex)
        {
            case 0:
                if (!itemsGainedScriptableObject.HasGainedHairItems[saveGainedItemID])
                {
                    itemsGainedScriptableObject.HasGainedHairItems[saveGainedItemID] = true;
                }
                else
                {
                    Debug.Log("You have already gained HAIR item at index " +
                        Array.IndexOf(itemsGainedScriptableObject.HasGainedHairItems, saveGainedItemID));
                }
                break;
            case 1:
                if (!itemsGainedScriptableObject.HasGainedHeadItems[saveGainedItemID])
                {
                    itemsGainedScriptableObject.HasGainedHeadItems[saveGainedItemID] = true;
                }
                else
                {
                    Debug.Log("You have already gained HEAD item at index " +
                        Array.IndexOf(itemsGainedScriptableObject.HasGainedHeadItems, saveGainedItemID));
                }
                break;
            case 2:
                if (!itemsGainedScriptableObject.HasGainedTorsoItems[saveGainedItemID])
                {
                    itemsGainedScriptableObject.HasGainedTorsoItems[saveGainedItemID] = true;
                }
                else
                {
                    Debug.Log("You have already gained TORSO item at index "
                        + Array.IndexOf(itemsGainedScriptableObject.HasGainedTorsoItems, saveGainedItemID));
                }
                break;
            case 3:
                if (!itemsGainedScriptableObject.HasGainedLegItems[saveGainedItemID])
                {
                    itemsGainedScriptableObject.HasGainedLegItems[saveGainedItemID] = true;
                }
                else
                {
                    Debug.Log("You have already gained LEG item at index "
                        + Array.IndexOf(itemsGainedScriptableObject.HasGainedMiscItems, saveGainedItemID));
                }
                break;
            case 4:
                if (!itemsGainedScriptableObject.HasGainedMiscItems[saveGainedItemID])
                {
                    itemsGainedScriptableObject.HasGainedMiscItems[saveGainedItemID] = true;
                }
                else
                {
                    Debug.Log("You have already gained MISC item at index "
                        + Array.IndexOf(itemsGainedScriptableObject.HasGainedMiscItems, saveGainedItemID));
                }
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
