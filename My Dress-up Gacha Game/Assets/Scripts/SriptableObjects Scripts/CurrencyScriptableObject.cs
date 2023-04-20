using UnityEngine;

[CreateAssetMenu(fileName = "In_GameCurrency", menuName = "ScriptableObject/Currency", order = 1)]
public class CurrencyScriptableObject: ScriptableObject
{
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

    [Header("Real life money have spent (in Euro)")]
    [SerializeField]
    private float realMoneyAmount;
    public float RealMoneyAmount
    {
        get
        {
            return realMoneyAmount;
        }
        set
        {
            realMoneyAmount = value;
        }
    }


}
