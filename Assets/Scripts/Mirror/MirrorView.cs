using System.Collections.Generic;
using UnityEngine;

public class MirrorView : MonoBehaviour
{
    public List<GarmentData> garments = new();

    public List<GameObject> hangingGarments = new();

    private void OnEnable()
    {
        GarmentData picked = null;
        if (GameManager.instance != null)
        {
            picked = GameManager.instance.selectedGarment;
        }

        for (int i = 0; i < hangingGarments.Count; i++)
        {
            if (i < garments.Count && garments[i] == picked)
            {
                hangingGarments[i].SetActive(true);
            }
            else
            {
                hangingGarments[i].SetActive(false);
            }
        }
    }
}
