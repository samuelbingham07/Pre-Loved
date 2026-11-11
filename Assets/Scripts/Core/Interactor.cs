using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Interactor : MonoBehaviour
{
    public InputAction clickAction;

    public GameObject hoverPanel;
    public TextMeshProUGUI hoverText;

    IInteractable currentInteractable;
    IInteractable lastInteractable;

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
        UpdateHover();
        ShowHoverText();

        if (clickAction.triggered && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    void FindInteractable()
    {
        currentInteractable = null;

        bool blocked = false;
        if (ViewManager.instance != null && ViewManager.instance.IsFading())
        {
            blocked = true;
        }
        if (InspectViewer.instance != null && InspectViewer.instance.IsOpen())
        {
            blocked = true;
        }

        if (blocked == false)
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

    void UpdateHover()
    {
        if (currentInteractable != lastInteractable)
        {
            if (lastInteractable != null)
            {
                lastInteractable.SetHover(false);
            }

            if (currentInteractable != null)
            {
                currentInteractable.SetHover(true);
            }

            lastInteractable = currentInteractable;
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
