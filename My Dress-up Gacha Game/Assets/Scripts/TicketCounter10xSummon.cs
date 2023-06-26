using System.Collections;
using TMPro;
using UnityEngine;

public class TicketCounter10xSummon: MonoBehaviour
{
    //We do not need the Scriptable object here
    //As this script is not the one handling remembering how many tickets we have
    //This scripts only handle the animation when we do 10x Summon
    [SerializeField]
    private TextMeshProUGUI ticketAmount_TMP;

    [SerializeField]
    private float countDuration;

    [SerializeField]
    private CurrencyScriptableObject currencyScriptableObject;

    //currentTicketValue = is what it's currently displaying each seconds
    //targetTicketAmount = end goal of the Tween
    [SerializeField]
    private float currentTicketValue, targetTicketAmount;

    private Coroutine reduceTicketCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        targetTicketAmount = currentTicketValue = currencyScriptableObject.SummonTicketAmount;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetTicketAmount = currencyScriptableObject.SummonTicketAmount;
        ticketAmount_TMP.text = targetTicketAmount.ToString();
    }

    //This special method is for 10x summon
    //Mean the amount of tix to be reduce is ALWAYS 10
    //public to access from Summon10x_Button
    public void Reduce10Tickets()
    {

        //targetTicketAmount += addTicketAmount;
        //targetTicketAmount = currencyScriptableObject.SummonTicketAmount;
        if (targetTicketAmount < 10)
        {
            Debug.Log("Cannot summon 10x");
        }

        else
        {
            //To avoid 2 coroutine playing simultaneously 
            if (reduceTicketCoroutine != null)
            {
                StopCoroutine(reduceTicketCoroutine);
            }

            reduceTicketCoroutine = StartCoroutine(CountTicketNumberTo(targetTicketAmount));
        }


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
}
