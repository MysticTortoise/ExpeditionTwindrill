using UnityEngine;
using TMPro;

public class HyperlinkHandler : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, Input.mousePosition, null);
            if (linkIndex != -1)
            {
                TMP_LinkInfo linkInfo = text.textInfo.linkInfo[linkIndex];
                string url = linkInfo.GetLinkID();
                Application.OpenURL(url); // Open the URL in the default browser
            }
        }
    }
}
