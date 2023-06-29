using System.Collections;
using UnityEngine;

public class OpenSpecificWindow: MonoBehaviour
{
    [Header("GO to de/activate")]
    [SerializeField]
    private GameObject windowPanel;

    [SerializeField]
    private DOTweenValuesScriptableObject DOTweenValuesScriptableObject;

    [Header("Window status_READ ONLY")]
    [SerializeField]
    private bool isWindowActive;

    // Start is called before the first frame update
    void Start()
    {
        //Start with Window deactivated
        //Unless it's Inventory: activated -> Deactivated
        windowPanel.SetActive(false);
        isWindowActive = windowPanel.activeSelf;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //There is a bug that require Inventory to be on at start THEN unactive
    //To find all the necessary Child_GO
    private void InventoryOnAtStart(bool isInventory)
    {

    }

    //public method so button Event can access
    //We are doing double check to avoid future conflicts
    public void ChangeWindowStatus()
    {
        //if Window is not active -> change to active
        if (!isWindowActive)
        {
            isWindowActive = true;
            De_ActivateWindowGO();
        }
        else
        {
            //isWindowActive = false;
            StartCoroutine(SmallDelayForMainPanelsTween(DOTweenValuesScriptableObject.TweenDuration, false));
        }

    }

    private void De_ActivateWindowGO()
    {
        //Check the status of Window
        if (isWindowActive)
        {
            windowPanel.SetActive(true);
        }
        else
        {
            windowPanel.SetActive(false);
        }
    }

    private void MouseDebug()
    {
        //Check for mouse click 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    Debug.Log("Object being hit: " + raycastHit.ToString());
                }
            }
        }
    }

    IEnumerator SmallDelayForMainPanelsTween(float waitDuration, bool localIsWindowActive)
    {
        Debug.Log("Small Delay before closing Panel");
        yield return new WaitForSeconds(waitDuration);
        isWindowActive = localIsWindowActive;
        De_ActivateWindowGO();
    }
}
