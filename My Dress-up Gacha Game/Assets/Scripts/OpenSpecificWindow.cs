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
        windowPanel.SetActive(false);
        isWindowActive = windowPanel.activeSelf;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public method so button Event can access
    //We are doing double check to avoid future conflicts
    public void ChangeWindowStatus()
    {
        StartCoroutine(SmallDelayForMainPanelsTween(DOTweenValuesScriptableObject.TweenDuration));

        //if Window is not active -> change to active
        if (!isWindowActive)
        {
            isWindowActive = true;
        }
        else
        {
            //isWindowActive = false;
            StartCoroutine(SmallDelayForMainPanelsTween(DOTweenValuesScriptableObject.TweenDuration));
        }

        De_ActivateWindowGO();
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

    IEnumerator SmallDelayForMainPanelsTween(float waitDuration)
    {
        Debug.Log("Small Delay before closing Panel");
        yield return new WaitForSeconds(waitDuration);
        isWindowActive = false;
    }

}
