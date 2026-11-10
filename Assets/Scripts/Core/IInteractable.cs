// Anything the player can hover and click (arrows, hangers, the bag...)
// signs this contract, so the Interactor can treat them all the same way.
public interface IInteractable
{
    void Interact();
    string InteractText();

    // Called with true when the mouse moves onto the object, false when it leaves
    void SetHover(bool isHovered);
}
