using TMPro;
using UnityEngine;

public class SummonTicketCheckAndDisplay: MonoBehaviour
{
    [SerializeField]
    private CurrencyScriptableObject currencyScriptableObject;

    [SerializeField]
    private TextMeshProUGUI ticketAmount_TMP, ticketRemains_TMP;

    void Start()
    {
        DisplaySummonTicket(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public to access Summon! button
    public void DisplaySummonTicket(bool is10xSummon)
    {
        if (is10xSummon)
        {
            Debug.Log("SummonTicketCheckAndDisplay in 10x");
        }

        else
        {
            //Start with pasting whatever amount of summonTicket in SO in UI
            ticketAmount_TMP.text = currencyScriptableObject.SummonTicketAmount.ToString();
        }

        TicketOrTickets();
    }

    //This method is to check the grammar, based on the amount of summonTicket
    private void TicketOrTickets()
    {
        //if 1 or less -> "ticket";
        if (currencyScriptableObject.SummonTicketAmount <= 1)
        {
            ticketRemains_TMP.text = "ticket remains";
        }
        //anything more than 1 -> "tickets"
        else
        {
            ticketRemains_TMP.text = "tickets remain";
        }
    }
}
