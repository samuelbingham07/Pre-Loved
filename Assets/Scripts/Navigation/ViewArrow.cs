using UnityEngine;

// Put this on an arrow sprite that has a BoxCollider2D.
public class ViewArrow : MonoBehaviour, IInteractable
{
    // Index in ViewManager's list: 0 Rack, 1 Shelves, 2 Drawer, 3 Mirror
    public int targetView;
    public string label = "Shelves";

    public AudioClip clickSound;

    public string InteractText()
    {
        return label;
    }

    public void Interact()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.PlaySound(clickSound);
        }

        ViewManager.instance.GoToView(targetView);
    }
}
