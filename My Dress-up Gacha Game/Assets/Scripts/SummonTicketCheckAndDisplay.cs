using TMPro;
using UnityEngine;

public class SummonTicketCheckAndDisplay: MonoBehaviour
{
    [SerializeField]
    private CurrencyScriptableObject currencyScriptableObject;

    [SerializeField]
    private TextMeshProUGUI ticketAmount_TMP, ticketRemains_TMP;

    [Header("READ_ONLY")]
    private int localTicketAmount;

    // Start is called before the first frame update
    void Start()
    {
        DisplaySummonTicket();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public to access Summon! button
    public void DisplaySummonTicket()
    {
        //Save values from SO to a local Variable 
        localTicketAmount = currencyScriptableObject.SummonTicketAmount;
        //Start with pasting whatever amount of summonTicket in SO in UI
        ticketAmount_TMP.text = localTicketAmount.ToString();
        TicketOrTickets();
    }

    //This method is to check the grammar, based on the amount of summonTicket
    private void TicketOrTickets()
    {
        //if 1 or less -> "ticket";
        if (localTicketAmount <= 1)
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
