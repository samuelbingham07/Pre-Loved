using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // The ambient closet loop lives on this object's AudioSource
    // (Play On Awake + Loop checked). One-shot sounds play through it too.
    AudioSource managerAudio;

    // The garment the player opened last (empty until they pick one)
    public GarmentData selectedGarment;

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
        managerAudio = GetComponent<AudioSource>();
    }

    // Any script can call GameManager.instance.PlaySound(someClip)
    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            managerAudio.PlayOneShot(clip);
        }
    }

    public bool HasPickedGarment()
    {
        if (selectedGarment != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
