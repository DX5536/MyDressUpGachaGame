using System.Collections;
using DG.Tweening;
using UnityEngine;

public class InventoryTabTween: MonoBehaviour
{
    [SerializeField]
    private DOTweenValuesScriptableObject DOTweenValuesScriptableObject;

    [SerializeField]
    private RectTransform hair_SlotGridPanel, head_SlotGridPanel, torso_SlotGridPanel, leg_SlotGridPanel, misc_SlotGridPanel;

    [SerializeField]
    private RectTransform displayGoal, hideGoal;

    // Start is called before the first frame update
    void Start()
    {
        Hide_AllSGP();

        //We show hair as "default"
        Show_HairSGP();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Hide_AllSGP()
    {
        hair_SlotGridPanel.DOMove(hideGoal.transform.position,
            0,
            DOTweenValuesScriptableObject.TweenSnapping);
        hair_SlotGridPanel.gameObject.SetActive(false);

        head_SlotGridPanel.DOMove(hideGoal.transform.position,
            0,
            DOTweenValuesScriptableObject.TweenSnapping);
        head_SlotGridPanel.gameObject.SetActive(false);

        torso_SlotGridPanel.DOMove(hideGoal.transform.position,
            0,
            DOTweenValuesScriptableObject.TweenSnapping);
        torso_SlotGridPanel.gameObject.SetActive(false);

        leg_SlotGridPanel.DOMove(hideGoal.transform.position,
            0,
            DOTweenValuesScriptableObject.TweenSnapping);
        leg_SlotGridPanel.gameObject.SetActive(false);

        misc_SlotGridPanel.DOMove(hideGoal.transform.position,
            0,
            DOTweenValuesScriptableObject.TweenSnapping);
        misc_SlotGridPanel.gameObject.SetActive(false);

        StartCoroutine(SmallDelay());
    }

    //All public method to access from PartTab
    public void Show_HairSGP()
    {
        //If panel is already active -> No need for tween again
        if (hair_SlotGridPanel.gameObject.activeSelf)
        {
            return;
        }

        else
        {
            Hide_AllSGP();

            hair_SlotGridPanel.gameObject.SetActive(true);
            hair_SlotGridPanel.DOMove(displayGoal.transform.position,
                DOTweenValuesScriptableObject.TweenDuration,
                DOTweenValuesScriptableObject.TweenSnapping);
        }


    }

    public void Show_HeadSGP()
    {
        //If panel is already active -> No need for tween again
        if (head_SlotGridPanel.gameObject.activeSelf)
        {
            return;
        }

        else
        {
            Hide_AllSGP();

            head_SlotGridPanel.gameObject.SetActive(true);
            head_SlotGridPanel.DOMove(displayGoal.transform.position,
                        DOTweenValuesScriptableObject.TweenDuration,
                        DOTweenValuesScriptableObject.TweenSnapping);
        }




    }

    public void Show_TorsoSGP()
    {
        //If panel is already active -> No need for tween again
        if (torso_SlotGridPanel.gameObject.activeSelf)
        {
            return;
        }

        else
        {
            Hide_AllSGP();
            torso_SlotGridPanel.gameObject.SetActive(true);
            torso_SlotGridPanel.DOMove(displayGoal.transform.position,
                DOTweenValuesScriptableObject.TweenDuration,
                DOTweenValuesScriptableObject.TweenSnapping);
        }




    }
    public void Show_LegSGP()
    {
        //If panel is already active -> No need for tween again
        if (leg_SlotGridPanel.gameObject.activeSelf)
        {
            return;
        }

        else
        {

            Hide_AllSGP();

            leg_SlotGridPanel.gameObject.SetActive(true);
            leg_SlotGridPanel.DOMove(displayGoal.transform.position,
                DOTweenValuesScriptableObject.TweenDuration,
                DOTweenValuesScriptableObject.TweenSnapping);
        }


    }

    public void Show_MiscSGP()
    {
        //If panel is already active -> No need for tween again
        if (misc_SlotGridPanel.gameObject.activeSelf)
        {
            return;
        }

        else
        {
            Hide_AllSGP();

            misc_SlotGridPanel.gameObject.SetActive(true);
            misc_SlotGridPanel.DOMove(displayGoal.transform.position,
                DOTweenValuesScriptableObject.TweenDuration,
                DOTweenValuesScriptableObject.TweenSnapping);
        }


    }

    IEnumerator SmallDelay()
    {
        yield return new WaitForSeconds(0.1f);
    }
}
