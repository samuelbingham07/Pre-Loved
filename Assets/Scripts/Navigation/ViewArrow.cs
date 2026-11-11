using UnityEngine;

public class ViewArrow : MonoBehaviour, IInteractable
{
    public int targetView;
    public string label = "Mirror";

    public AudioClip clickSound;

    public bool needsGarment = false;
    public string lockedLabel = "Pick a garment first";

    public float hoverScale = 1.15f;

    Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
    }

    public string InteractText()
    {
        if (IsLocked())
        {
            return lockedLabel;
        }
        else
        {
            return label;
        }
    }

    public void Interact()
    {
        if (IsLocked())
        {
            print("Can't go yet: no garment picked");
        }
        else
        {
            GameManager.instance.PlaySound(clickSound);
            ViewManager.instance.GoToView(targetView);
        }
    }

    bool IsLocked()
    {
        if (needsGarment && GameManager.instance.HasPickedGarment() == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetHover(bool isHovered)
    {
        if (isHovered)
        {
            transform.localScale = startScale * hoverScale;
        }
        else
        {
            transform.localScale = startScale;
        }
    }
}
