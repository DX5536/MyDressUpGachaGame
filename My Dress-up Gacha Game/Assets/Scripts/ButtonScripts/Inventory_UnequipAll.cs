using UnityEngine;

public class Inventory_UnequipAll: MonoBehaviour
{
    [SerializeField]
    private GameObject[] bodyDrawing_HAIRS, bodyDrawing_HEADS, bodyDrawing_TORSOS, bodyDrawing_LEGS, bodyDrawing_MISCS;

    [SerializeField]
    private string hairSpriteTag, headSpriteTag, torsoSpriteTag, legSpriteTag, miscSpriteTag;

    // Start is called before the first frame update
    void Start()
    {
        bodyDrawing_HAIRS = GameObject.FindGameObjectsWithTag(hairSpriteTag);
        bodyDrawing_HEADS = GameObject.FindGameObjectsWithTag(headSpriteTag);
        bodyDrawing_TORSOS = GameObject.FindGameObjectsWithTag(torsoSpriteTag);
        bodyDrawing_LEGS = GameObject.FindGameObjectsWithTag(legSpriteTag);
        bodyDrawing_MISCS = GameObject.FindGameObjectsWithTag(miscSpriteTag);

        DeactivateALLGO();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //This is a workaround as FindGameObectsWithTag cannot find inactive Items
    //So first all the items are active (Frankenstein) -> Found and save -> Deactivate them
    public void DeactivateALLGO()
    {
        foreach (var hair in bodyDrawing_HAIRS)
        {
            hair.SetActive(false);
        }
        foreach (var head in bodyDrawing_HEADS)
        {
            head.SetActive(false);
        }
        foreach (var torso in bodyDrawing_TORSOS)
        {
            torso.SetActive(false);
        }

        foreach (var leg in bodyDrawing_LEGS)
        {
            leg.SetActive(false);
        }

        foreach (var misc in bodyDrawing_MISCS)
        {
            misc.SetActive(false);
        }

    }

    public void UnequipItemsFromSelectedGroup1(string selectedGroup_NAME)
    {
        switch (selectedGroup_NAME)
        {
            case null:
                Debug.Log("Cannot unequip items -> Check spelling in Event (must be ALLCAP)");
                break;

            case "HAIR":
                foreach (var hair in bodyDrawing_HAIRS)
                {
                    hair.SetActive(false);

                    Debug.Log(hair.name + "is unequipping");
                }
                break;

            case "HEAD":
                foreach (var head in bodyDrawing_HEADS)
                {
                    head.SetActive(false);
                }
                break;

            case "TORSO":
                foreach (var torso in bodyDrawing_TORSOS)
                {
                    torso.SetActive(false);
                }
                break;

            case "LEG":
                foreach (var leg in bodyDrawing_LEGS)
                {
                    leg.SetActive(false);
                }
                break;

            case "MISC":
                foreach (var misc in bodyDrawing_MISCS)
                {
                    misc.SetActive(false);
                }
                break;
        }
    }

    public void UnequipItemsFromSelectedGroup(string selectedGroup_NAME)
    {
        if (selectedGroup_NAME == null)
        {
            Debug.Log("CheckSpelling in ALLCAP");
        }

        else if (selectedGroup_NAME == "HAIR")
        {
            foreach (var hair in bodyDrawing_HAIRS)
            {
                if (hair.activeSelf == true)
                {
                    hair.SetActive(false);

                    Debug.Log(hair.name + "is unequipping");
                }
            }
        }

    }
}
