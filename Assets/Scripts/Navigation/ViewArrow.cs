using UnityEngine;

// Put this on an arrow sprite that has a BoxCollider2D.
public class ViewArrow : MonoBehaviour, IInteractable
{
    // Index in ViewManager's list: 0 Closet, 1 Mirror
    public int targetView;
    public string label = "Mirror";

    public AudioClip clickSound;

    // Tick this on the arrow that goes to the Mirror:
    // it won't work until a garment has been picked
    public bool needsGarment = false;
    public string lockedLabel = "Pick a garment first";

    // How much bigger the arrow gets on hover
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

    // Locked if this arrow needs a garment and none has been picked yet
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
