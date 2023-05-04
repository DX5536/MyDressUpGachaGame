using TMPro;
using UnityEngine;

public class BannerSelection_Button: MonoBehaviour
{
    [SerializeField]
    private ItemsGainedScriptableObject itemsGainedScriptableObject;

    [Header("Banner UI")]
    [SerializeField]
    private TextMeshProUGUI shopTitle_TMP;
    [SerializeField]
    private TextMeshProUGUI youGain_TMP;
    [SerializeField]
    private GameObject summon1x_Panel, summon10x_Panel;

    //[Header("This is so we can start with something and not placeholder text")]
    //[SerializeField]
    private string startBannerTitleName = "Hair Banner";
    //[SerializeField]
    private int startBannerIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //At start we will auto default the bannerName to "Hair" and bannerID to 0
        shopTitle_TMP.text = startBannerTitleName;
        itemsGainedScriptableObject.CurrentlySelectedBannerID = startBannerIndex;

        youGain_TMP.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public to access from Banner selection button
    public void Selection_BannerName(string bannerName)
    {
        //Change the PanelTitle to the name
        shopTitle_TMP.text = bannerName;

        //Deactivated previously gainedItem UI -> both 1x and 10x_Panel upon changing banner
        summon1x_Panel.SetActive(false);
        summon10x_Panel.SetActive(false);
        youGain_TMP.enabled = false;
    }

    //public because Unity is a b- for only allow 1 parameter in a button ;_;
    public void Selection_BannerID(int bannerID)
    {
        //Save the ID of the banner locally so we know which item to be summoned
        itemsGainedScriptableObject.CurrentlySelectedBannerID = bannerID;
    }

}
