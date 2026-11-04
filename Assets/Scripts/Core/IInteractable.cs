// Anything the player can hover and click (arrows, hangers, the bag...)
// signs this contract, so the Interactor can treat them all the same way.
public interface IInteractable
{
    void Interact();
    string InteractText();
}
