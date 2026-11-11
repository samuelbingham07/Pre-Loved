using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InspectViewer : MonoBehaviour
{
    public static InspectViewer instance;

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
    }

    public void Show(Sprite image, string description)
    {
        picture.sprite = image;
        descriptionText.text = description;
        inspectPanel.SetActive(true);
        isOpen = true;
    }

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
