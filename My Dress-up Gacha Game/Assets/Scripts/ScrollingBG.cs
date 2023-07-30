using UnityEngine;
using UnityEngine.UI;

public class ScrollingBG: MonoBehaviour
{
    [SerializeField]
    private RawImage scrollingBG_IMG;
    [SerializeField]
    private float xOffset, yOffset;

    // Update is called once per frame
    void Update()
    {
        scrollingBG_IMG.uvRect = new Rect(scrollingBG_IMG.uvRect.position + new Vector2(xOffset, yOffset) * Time.deltaTime, scrollingBG_IMG.uvRect.size);
    }
}
