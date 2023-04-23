using UnityEngine;

[CreateAssetMenu(fileName = "In_GameCurrency", menuName = "ScriptableObject/Currency", order = 1)]
public class CurrencyScriptableObject: ScriptableObject
{
    [SerializeField]
    private bool resetValueAtAwake;
    public bool ResetValueAtAwake
    {
        get
        {
            return resetValueAtAwake;
        }
    }

    [Header("Summon tickets to pull in Gacha Shop")]
    [SerializeField]
    private int summonTicketAmount;
    public int SummonTicketAmount
    {
        get
        {
            return summonTicketAmount;
        }
        set
        {
            summonTicketAmount = value;
        }
    }

    [Header("The displayed prices in In-App stores")]
    [SerializeField]
    private float[] inAppPrices;

    public float[] InAppPrices
    {
        get
        {
            return inAppPrices;
        }
        set
        {
            inAppPrices = value;
        }
    }

    [Header("The amount of tickets player get when buy from In-App")]
    [SerializeField]
    private int[] inAppBuyTicketsAmounts;

    public int[] InAppBuyTicketsAmounts
    {
        get
        {
            return inAppBuyTicketsAmounts;
        }
        set
        {
            inAppBuyTicketsAmounts = value;
        }
    }



    [Header("TOTAL Real life money have spent (in Euro)")]
    [SerializeField]
    private float totalRealMoneyAmount;
    public float TotalRealMoneyAmount
    {
        get
        {
            return totalRealMoneyAmount;
        }
        set
        {
            totalRealMoneyAmount = value;
        }
    }

}
