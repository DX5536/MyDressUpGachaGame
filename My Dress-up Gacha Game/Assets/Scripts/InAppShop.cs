using TMPro;
using UnityEngine;

public class InAppShop: MonoBehaviour
{
    [SerializeField]
    private CurrencyScriptableObject currencyScriptableObject;

    [SerializeField]
    private TextMeshProUGUI ticketAmount_TMP, totalMoneyAmount_TMP;

    private void OnEnable()
    {
        //Have to reset all UI before Start()
        if (currencyScriptableObject.ResetValueAtAwake)
        {
            currencyScriptableObject.SummonTicketAmount = 3;
            currencyScriptableObject.TotalRealMoneyAmount = 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DisplaySummonTicketAndMoney();
    }


    // Update is called once per frame
    void Update()
    {

    }

    //public to access button
    public void BuyInAppShop(int chosenPackageIndex)
    {
        //We add the ticket amount of the Price to summonTicketAmount in SO
        currencyScriptableObject.SummonTicketAmount += currencyScriptableObject.InAppBuyTicketsAmounts[chosenPackageIndex];
        //And add money in totalRealMoneyAmount
        currencyScriptableObject.TotalRealMoneyAmount += currencyScriptableObject.InAppPrices[chosenPackageIndex];
    }

    //public to access from the Buying buttons too
    public void DisplaySummonTicketAndMoney()
    {
        //Save values from SO to a local Variable 
        var localTicketAmount = currencyScriptableObject.SummonTicketAmount;
        var localMoneyAmount = currencyScriptableObject.TotalRealMoneyAmount;

        //Start with pasting whatever amount of summonTicket in SO in UI
        ticketAmount_TMP.text = localTicketAmount.ToString();
        totalMoneyAmount_TMP.text = localMoneyAmount.ToString();
    }
}
