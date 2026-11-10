using TMPro;
using UnityEngine;
using UnityEngine.UI;

// The close-up screen: one big picture with a description under it.
// Used by DetailSpot (close-ups) and MirrorSpot (trying it on).
public class InspectViewer : MonoBehaviour
{
    public static InspectViewer instance;

    // A UI panel under the Canvas. Starts turned off.
    public GameObject inspectPanel;

    public Image picture;
    public TextMeshProUGUI descriptionText;

    bool isOpen = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        inspectPanel.SetActive(false);

        // Keep photos their real shape instead of stretching them to fill the box
        picture.preserveAspect = true;
    }

    public void Show(Sprite image, string description)
    {
        picture.sprite = image;
        descriptionText.text = description;
        inspectPanel.SetActive(true);
        isOpen = true;
    }

    // Hook this up to the Close button's On Click () in the Inspector
    public void Close()
    {
        inspectPanel.SetActive(false);
        isOpen = false;
    }

    public bool IsOpen()
    {
        if (isOpen)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
