using System.Collections;
using TMPro;
using UnityEngine;

public class InAppShop: MonoBehaviour
{
    [SerializeField]
    private CurrencyScriptableObject currencyScriptableObject;

    [SerializeField]
    private TextMeshProUGUI ticketAmount_TMP, totalMoneyAmount_TMP;

    [SerializeField]
    private float countDuration;

    //[SerializeField]
    private int localTicketAmount;
    //[SerializeField]
    private float localMoneyAmount;

    //currentTicketValue = is what it's currently displaying each seconds
    //targetTicketAmount = end goal of the Tween
    //[SerializeField]
    private float currentTicketValue, targetTicketAmount;
    //[SerializeField]
    private float currentMoneyValue, targetMoneyAmount;

    private Coroutine countTicketCoroutine;
    private Coroutine countMoneyCoroutine;

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

        targetTicketAmount = currentTicketValue = localTicketAmount;
        targetMoneyAmount = currentMoneyValue = localMoneyAmount;
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

        //We are lazy and to avoid edit each script
        //We just let the chosenPackage and its value auto paste in the amount of Ticket/Money
        AddTickets(currencyScriptableObject.InAppBuyTicketsAmounts[chosenPackageIndex]);
        AddRealMoney(currencyScriptableObject.InAppPrices[chosenPackageIndex]);
    }

    //Only At Start
    public void DisplaySummonTicketAndMoney()
    {
        //Save values from SO to a local Variable 
        localTicketAmount = currencyScriptableObject.SummonTicketAmount;
        localMoneyAmount = currencyScriptableObject.TotalRealMoneyAmount;

        //Start with pasting whatever amount of summonTicket in SO in UI
        ticketAmount_TMP.text = localTicketAmount.ToString();
        totalMoneyAmount_TMP.text = localMoneyAmount.ToString() + "€";
    }


    //Start the Coroutine/Tween of Ticket
    private void AddTickets(int addTicketAmount)
    {
        targetTicketAmount += addTicketAmount;

        //To avoid 2 coroutine playing simultaneously 
        if (countTicketCoroutine != null)
        {
            StopCoroutine(countTicketCoroutine);
        }

        countTicketCoroutine = StartCoroutine(CountTicketNumberTo(targetTicketAmount));
    }

    //Start the Coroutine/Tween of Real Money
    private void AddRealMoney(float addMoneyAmount)
    {
        targetMoneyAmount += addMoneyAmount;

        //To avoid 2 coroutine playing simultaneously 
        if (countMoneyCoroutine != null)
        {
            StopCoroutine(countMoneyCoroutine);
        }

        countMoneyCoroutine = StartCoroutine(CountMoneyTo(targetMoneyAmount));
    }

    IEnumerator CountTicketNumberTo(float targetTicketValue)
    {
        var rate = Mathf.Abs(targetTicketValue - currentTicketValue) / countDuration;
        while (currentTicketValue != targetTicketValue)
        {
            currentTicketValue = Mathf.MoveTowards(currentTicketValue, targetTicketValue, rate * Time.deltaTime);
            ticketAmount_TMP.text = ((int) currentTicketValue).ToString();

            //Debug.Log("CountTicketNumberTo is playing");
            yield return null;
        }
    }

    IEnumerator CountMoneyTo(float targetMoneyValue)
    {
        var rate = Mathf.Abs(targetMoneyValue - currentMoneyValue) / countDuration;
        while (currentMoneyValue != targetMoneyValue)
        {
            currentMoneyValue = Mathf.MoveTowards(currentMoneyValue, targetMoneyValue, rate * Time.deltaTime);
            totalMoneyAmount_TMP.text = currentMoneyValue.ToString() + "€";

            //Debug.Log("CountRealMoneyNumberTo is playing");
            yield return null;
        }
    }



}
