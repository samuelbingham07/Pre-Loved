using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    AudioSource managerAudio;

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
