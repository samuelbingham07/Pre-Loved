using System.Collections.Generic;
using UnityEngine;

// Flips through the closet "frames" when a RackArrow is clicked.
// Each frame is a full picture of the closet with the garments in a new spot.
public class RackController : MonoBehaviour
{
    // The SpriteRenderer that shows the closet picture
    public SpriteRenderer closetRenderer;

    // One picture per frame, in order (frame 0 = all six bunched on the right)
    public List<Sprite> frames = new();

    // The garment you can pick in each frame, in the same order as the frames.
    // Leave a slot empty if there's nothing to pick in that frame.
    public List<GarmentData> frameGarments = new();

    // Invisible click area over the spot where the pickable garment sits
    public GarmentHanger pickZone;

    public AudioClip slideSound;

    int currentFrame = 0;

    void Start()
    {
        ShowFrame();
    }

    // direction is 1 for the next frame, -1 to go back
    public void Slide(int direction)
    {
        int newFrame = currentFrame + direction;

        // Only move if that frame exists
        if (newFrame >= 0 && newFrame < frames.Count)
        {
            currentFrame = newFrame;
            ShowFrame();
            GameManager.instance.PlaySound(slideSound);
        }
    }

    void ShowFrame()
    {
        if (frames.Count > 0)
        {
            closetRenderer.sprite = frames[currentFrame];
        }

        // Tell the click area which garment it is now
        if (currentFrame < frameGarments.Count)
        {
            pickZone.garment = frameGarments[currentFrame];
        }
        else
        {
            pickZone.garment = null;
        }
    }
}
