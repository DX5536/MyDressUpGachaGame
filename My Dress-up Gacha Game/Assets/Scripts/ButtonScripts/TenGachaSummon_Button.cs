using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TenGachaSummon_Button: MonoBehaviour
{
    [Header("Banner UI")]
    [SerializeField]
    private TextMeshProUGUI[] gainedItem10x_TMP;
    [SerializeField]
    private Image[] gainedItem10x_IMG;
    [SerializeField]
    private TextMeshProUGUI youGain_TMP;
    [SerializeField]
    private GameObject summon1x_Panel, summon10x_Panel;

    [SerializeField]
    private Button summon1x_Button, summon10x_Button;

    [SerializeField]
    private Toggle skipAnimation_Toggle;

    //[SerializeField]
    //private GachaSummon_Button gachaSummon_ButtonScript;

    [Header("Important Scriptable Objects")]
    [SerializeField]
    private ItemChancesScriptableObject[] itemChancesScriptableObject;
    [SerializeField]
    private CurrencyScriptableObject currencyScriptableObject;
    [SerializeField]
    private ItemsGainedScriptableObject itemsGainedScriptableObject;

    [Header("Tween Values")]
    [SerializeField]
    private DOTweenValuesScriptableObject tweenValuesScriptableObject;
    [SerializeField]
    private float tweenScale;
    [SerializeField]
    private float tweenAnimationDelayDuration;

    [Header("Numbers_READ ONLY!")]
    //Local values to copy/past from SO
    [SerializeField]
    private string[] localItemNames;
    [SerializeField]
    private int[] localItemChances;
    [SerializeField]
    private Sprite[] localItemImages;

    private bool skipAnimation;
    //[SerializeField]
    private int gainedItem_Index;
    //[SerializeField]
    private int savedBannerIndex;
    //[SerializeField]
    private int perCent;
    private int pullCount = 10;

    //GachaSummon_Button already have the logic of Banner selection
    //So we will skip that here
    //We will take the BannerIndex (from the chosen banner) through the var GachaSummon_ButtonScript

    private void Start()
    {
        summon10x_Panel.SetActive(false);
        UpdateLocalValuesFromSO();
        CheckEnoughSummonTicket();

        skipAnimationToggling();
    }

    public void skipAnimationToggling()
    {
        if (skipAnimation_Toggle.isOn)
        {
            skipAnimation = true;
        }

        else
        {
            skipAnimation = false;
        }
    }

    //public method to access in Summon! 10x button
    public void SummonLogic_With_WithoutDelay(bool withDelay)
    {
        youGain_TMP.enabled = true;
        //withDelay = skipAnimation;

        //Delay will make each summoned item pop up 1-by-1 (not knowing what is the next item)
        if (!skipAnimation)
        {
            DisablePlaceholderSlotIn10xPanel();
            StartCoroutine(SummonLogicWithDelay());
        }

        //Without Delay will make all 10 items pop up at once
        else
        {
            SummonLogic();
        }

    }

    private IEnumerator SummonLogicWithDelay()
    {
        //Make sure summon1x_Panel is deactivated
        summon1x_Panel.SetActive(false);
        //and summon10x_Panel is activated
        summon10x_Panel.SetActive(true);

        UpdateLocalValuesFromSO();

        //A loop that will go through 10x times
        for (int i = 0;i < pullCount;i++)
        {
            //Temporary disable SummonButton
            summon1x_Button.interactable = false;
            summon10x_Button.interactable = false;

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

            else if (perCent < localItemChances[0]
                             + localItemChances[1]
                             + localItemChances[2]
                             + localItemChances[3]
                             + localItemChances[4])
            {
                gainedItem_Index = 4;
            }

            else
            {
                Debug.LogError("ERROR! It should not be possible to go below 0% or above 100% -> Check ScriptableObject");
            }

            yield return new WaitForSeconds(tweenAnimationDelayDuration);

            //The item will be displayed on the according slot [i]
            BannerDisplayItem(i);


        }

        //Reduce SummonTicketAmount in SO by 10 after summoning
        currencyScriptableObject.SummonTicketAmount -= 10;

        //Then check if there is still enough summonTicket
        CheckEnoughSummonTicket();

        //Enable SummonButton after loop
        summon1x_Button.interactable = true;
        summon10x_Button.interactable = true;

    }

    private void SummonLogic()
    {
        //Make sure summon1x_Panel is deactivated
        summon1x_Panel.SetActive(false);
        //and summon10x_Panel is activated
        summon10x_Panel.SetActive(true);

        //We need to updated the localItems that are temporary save in 1xPull scripts
        //So we will just call upon this script

        //A loop that will go through 10x times
        for (int i = 0;i < pullCount;i++)
        {
            //Temporary disable SummonButton
            summon1x_Button.interactable = false;
            summon10x_Button.interactable = false;

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

            else if (perCent < localItemChances[0]
                             + localItemChances[1]
                             + localItemChances[2]
                             + localItemChances[3]
                             + localItemChances[4])
            {
                gainedItem_Index = 4;
            }

            else if (perCent < localItemChances[0]
                             + localItemChances[1]
                             + localItemChances[2]
                             + localItemChances[3]
                             + localItemChances[4]
                             + localItemChances[5])
            {
                gainedItem_Index = 5;
            }

            else
            {
                Debug.LogError("ERROR! It should not be possible to go below 0% or above 100% -> Check ScriptableObject");
            }

            //The item will be displayed on the according slot [i]
            BannerDisplayItem(i);

        }

        //Reduce SummonTicketAmount in SO by 10 after summoning
        currencyScriptableObject.SummonTicketAmount -= 10;

        //Then check if there is still enough summonTicket
        CheckEnoughSummonTicket();

        //Enable SummonButton after loop
        summon1x_Button.interactable = true;
        summon10x_Button.interactable = true;
    }

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
    //I have to make a parameter as this will feed into SummonLogic
    //By making them dependent -> We know where something fail
    private void BannerDisplayItem(int bannerDisplayItem_Index)
    {
        //We do not need to create another loop
        //As this method will be call 1 time each time a loop in SummonLogic procs
        GainedItem_TweenAnimation(bannerDisplayItem_Index);

        switch (gainedItem_Index)
        {
            case 0:
                gainedItem10x_TMP[bannerDisplayItem_Index].text = localItemNames[0];
                gainedItem10x_IMG[bannerDisplayItem_Index].sprite = localItemImages[0];

                SavedDisplayItem(0);
                break;
            case 1:
                gainedItem10x_TMP[bannerDisplayItem_Index].text = localItemNames[1];
                gainedItem10x_IMG[bannerDisplayItem_Index].sprite = localItemImages[1];

                SavedDisplayItem(1);
                break;
            case 2:
                gainedItem10x_TMP[bannerDisplayItem_Index].text = localItemNames[2];
                gainedItem10x_IMG[bannerDisplayItem_Index].sprite = localItemImages[2];

                SavedDisplayItem(2);
                break;
            case 3:
                gainedItem10x_TMP[bannerDisplayItem_Index].text = localItemNames[3];
                gainedItem10x_IMG[bannerDisplayItem_Index].sprite = localItemImages[3];

                SavedDisplayItem(3);
                break;
            case 4:
                gainedItem10x_TMP[bannerDisplayItem_Index].text = localItemNames[4];
                gainedItem10x_IMG[bannerDisplayItem_Index].sprite = localItemImages[4];

                SavedDisplayItem(4);
                break;
        }

        //Debug.Log("Display gainedItem10x_TMP/IMG at index " + bannerDisplayItem_Index);
    }

    private void UpdateLocalValuesFromSO()
    {
        savedBannerIndex = itemsGainedScriptableObject.CurrentlySelectedBannerID;
        CopyPasteSOValuesToLocalValues(savedBannerIndex);
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
                        + Array.IndexOf(itemsGainedScriptableObject.HasGainedLegItems, saveGainedItemID));
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

    //public to access from GachaShop Button
    //Else there is a bug that disable button, despite go out and buy more from In-App Shop
    public void CheckEnoughSummonTicket()
    {
        //If there is not enough tickets to summon -> 10x
        //disable button
        if (currencyScriptableObject.SummonTicketAmount <= 10)
        {
            summon10x_Button.interactable = false;
        }

        else
        {
            summon10x_Button.interactable = true;
        }
    }

    private void GainedItem_TweenAnimation(int gainedItem_TweenAnimation_Index)
    {
        //Set the slot active each time when its turn
        gainedItem10x_IMG[gainedItem_TweenAnimation_Index].gameObject.SetActive(true);
        gainedItem10x_TMP[gainedItem_TweenAnimation_Index].gameObject.SetActive(true);

        //Tween animation
        gainedItem10x_TMP[gainedItem_TweenAnimation_Index].transform.localScale = Vector3.zero;
        gainedItem10x_IMG[gainedItem_TweenAnimation_Index].color = new Color(255, 255, 255, 0);

        gainedItem10x_TMP[gainedItem_TweenAnimation_Index].DOScale(tweenScale, tweenValuesScriptableObject.TweenDuration);
        gainedItem10x_IMG[gainedItem_TweenAnimation_Index].DOFade(1, tweenValuesScriptableObject.TweenDuration);
    }

    private void DisablePlaceholderSlotIn10xPanel()
    {
        //if button is not interactable cuz the items summon animation is playing
        for (int i = 0;i < pullCount;i++)
        {
            gainedItem10x_IMG[i].gameObject.SetActive(false);
            gainedItem10x_TMP[i].gameObject.SetActive(false);
        }
    }
}
