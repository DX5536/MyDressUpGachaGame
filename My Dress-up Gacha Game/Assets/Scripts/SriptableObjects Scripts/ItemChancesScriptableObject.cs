using UnityEngine;

[CreateAssetMenu(fileName = "ItemChances", menuName = "ScriptableObject/ItemValue", order = 0)]
public class ItemChancesScriptableObject: ScriptableObject
{
    [Header("Start at big% -> small%")]
    [SerializeField]
    private int[] itemChances;

    public int[] ItemChances
    {
        get
        {
            return itemChances;
        }

        //no set as we only read the values
    }

}
