using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Interactor : MonoBehaviour
{
    // In the Inspector, add a binding: Left Button [Mouse]
    public InputAction clickAction;

    // Small label that shows what the mouse is over (optional)
    public GameObject hoverPanel;
    public TextMeshProUGUI hoverText;

    IInteractable currentInteractable;

    private void OnEnable()
    {
        clickAction.Enable();
    }

    private void OnDisable()
    {
        clickAction.Disable();
    }

    void Update()
    {
        FindInteractable();
        ShowHoverText();

        if (clickAction.triggered && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    // Send a ray from the mouse into the scene and remember
    // the first object we hit that is an IInteractable.
    void FindInteractable()
    {
        currentInteractable = null;

        // Ignore the mouse while the screen is fading between views
        bool fading = false;
        if (ViewManager.instance != null)
        {
            fading = ViewManager.instance.IsFading();
        }

        if (fading == false)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition, Vector2.zero);

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].transform.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable))
                {
                    currentInteractable = interactable;
                }
            }
        }
    }

    void ShowHoverText()
    {
        if (hoverPanel != null)
        {
            if (currentInteractable != null)
            {
                hoverText.text = currentInteractable.InteractText();
                hoverPanel.SetActive(true);
            }
            else
            {
                hoverText.text = "";
                hoverPanel.SetActive(false);
            }
        }
    }
}
