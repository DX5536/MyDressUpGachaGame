using System.Collections;
using TMPro;
using UnityEngine;

public class NumberCounter: MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ticketAmount_TMP;
    [SerializeField]
    private TextMeshProUGUI realMoneyAmount_TMP;
    [SerializeField]
    private float countDuration;

    //[SerializeField]
    private int targetTicketAmount;

    [SerializeField]
    private float currentTicketValue;
    [SerializeField]
    private float currentRealMoneyValue;

    private Coroutine countCoroutine;

    private void Start()
    {
        StartCoroutine(SmallDelay());
        float.TryParse(ticketAmount_TMP.text, out currentTicketValue);
        float.TryParse(realMoneyAmount_TMP.text, out currentRealMoneyValue);
    }

    IEnumerator CountTicketNumber(int targetTicketValue)
    {
        var rate = Mathf.Abs(targetTicketValue - currentTicketValue) / countDuration;
        while (currentTicketValue != targetTicketValue)
        {
            currentTicketValue = Mathf.MoveTowards(currentTicketValue, targetTicketValue, rate * Time.deltaTime);
            ticketAmount_TMP.text = ((int) currentTicketValue).ToString();
            yield return null;
        }
    }

    public void AddTickets(int addTicketAmount)
    {
        //targetTicketAmount += addTicketAmount;

        if (countCoroutine != null)
        {
            StopCoroutine(countCoroutine);
        }
        countCoroutine = StartCoroutine(CountTicketNumber(addTicketAmount));
    }

    IEnumerator SmallDelay()
    {
        yield return new WaitForSeconds(1f);
    }

}
