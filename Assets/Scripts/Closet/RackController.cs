using System.Collections.Generic;
using UnityEngine;

public class RackController : MonoBehaviour
{
    public SpriteRenderer closetRenderer;

    public List<Sprite> frames = new();

    public List<GarmentData> frameGarments = new();

    public GarmentHanger pickZone;

    public AudioClip slideSound;

    int currentFrame = 0;

    void Start()
    {
        ShowFrame();
    }

    public void Slide(int direction)
    {
        int newFrame = currentFrame + direction;

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
