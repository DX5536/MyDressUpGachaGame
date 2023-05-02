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
    private Button summon_Button;

    [SerializeField]
    private GachaSummon_Button gachaSummon_ButtonScript;

    [SerializeField]
    private CurrencyScriptableObject currencyScriptableObject;

    [Header("Tween Values")]
    [SerializeField]
    private DOTweenValuesScriptableObject tweenValuesScriptableObject;
    [SerializeField]
    private float tweenScale;

    [Header("Numbers_READ ONLY!")]
    //[SerializeField]
    private int gainedItem_Index;
    //[SerializeField]
    private int perCent;
    private int pullCount = 10;

    //GachaSummon_Button already have the logic of Banner selection
    //So we will skip that here
    //We will take the BannerIndex (from the chosen banner) through the var GachaSummon_ButtonScript

    private void Start()
    {
        summon10x_Panel.SetActive(false);
    }

    //public method to access in Summon! 10x button
    public void SummonLogic()
    {
        //Make sure summon1x_Panel is deactivated
        summon1x_Panel.SetActive(false);
        //and summon10x_Panel is activated
        summon10x_Panel.SetActive(true);

        //A loop that will go through 10x times
        for (int i = 0;i < pullCount;i++)
        {
            //A random number will be generate
            perCent = Random.Range(0, 100);

            if (perCent < gachaSummon_ButtonScript.LocalItemChances[0])
            {
                gainedItem_Index = 0;
            }

            else if (perCent < gachaSummon_ButtonScript.LocalItemChances[0]
                             + gachaSummon_ButtonScript.LocalItemChances[1])
            {
                gainedItem_Index = 1;
            }

            else if (perCent < gachaSummon_ButtonScript.LocalItemChances[0]
                             + gachaSummon_ButtonScript.LocalItemChances[1]
                             + gachaSummon_ButtonScript.LocalItemChances[2])
            {
                gainedItem_Index = 2;
            }

            else if (perCent < gachaSummon_ButtonScript.LocalItemChances[0]
                             + gachaSummon_ButtonScript.LocalItemChances[1]
                             + gachaSummon_ButtonScript.LocalItemChances[2]
                             + gachaSummon_ButtonScript.LocalItemChances[3])
            {
                gainedItem_Index = 3;
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
                gainedItem10x_TMP[bannerDisplayItem_Index].text = gachaSummon_ButtonScript.LocalItemNames[0];
                gainedItem10x_IMG[bannerDisplayItem_Index].sprite = gachaSummon_ButtonScript.LocalItemImages[0];
                break;
            case 1:
                gainedItem10x_TMP[bannerDisplayItem_Index].text = gachaSummon_ButtonScript.LocalItemNames[1];
                gainedItem10x_IMG[bannerDisplayItem_Index].sprite = gachaSummon_ButtonScript.LocalItemImages[1];
                break;
            case 2:
                gainedItem10x_TMP[bannerDisplayItem_Index].text = gachaSummon_ButtonScript.LocalItemNames[2];
                gainedItem10x_IMG[bannerDisplayItem_Index].sprite = gachaSummon_ButtonScript.LocalItemImages[2];
                break;
            case 3:
                gainedItem10x_TMP[bannerDisplayItem_Index].text = gachaSummon_ButtonScript.LocalItemNames[3];
                gainedItem10x_IMG[bannerDisplayItem_Index].sprite = gachaSummon_ButtonScript.LocalItemImages[3];
                break;
            case 4:
                gainedItem10x_TMP[bannerDisplayItem_Index].text = gachaSummon_ButtonScript.LocalItemNames[4];
                gainedItem10x_IMG[bannerDisplayItem_Index].sprite = gachaSummon_ButtonScript.LocalItemImages[4];
                break;
        }
        Debug.Log("Display gainedItem10x_TMP/IMG at index " + bannerDisplayItem_Index);
    }


    //public to access from GachaShop Button
    //Else there is a bug that disable button, despite go out and buy more from In-App Shop
    public void CheckEnoughSummonTicket()
    {
        //If there is not enough tickets to summon -> 10x
        //disable button
        if (currencyScriptableObject.SummonTicketAmount <= 10)
        {
            summon_Button.interactable = false;
        }

        else
        {
            summon_Button.interactable = true;
        }
    }

    private void GainedItem_TweenAnimation(int GainedItem_TweenAnimation_Index)
    {
        gainedItem10x_TMP[GainedItem_TweenAnimation_Index].transform.localScale = Vector3.zero;
        gainedItem10x_IMG[GainedItem_TweenAnimation_Index].color = new Color(255, 255, 255, 0);

        gainedItem10x_TMP[GainedItem_TweenAnimation_Index].DOScale(tweenScale, tweenValuesScriptableObject.TweenDuration);
        gainedItem10x_IMG[GainedItem_TweenAnimation_Index].DOFade(1, tweenValuesScriptableObject.TweenDuration);
    }
}
