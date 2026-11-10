using System.Collections.Generic;
using UnityEngine;

// Put this on the Mirror view object.
// Every time the view turns on, it hangs up the garment that was picked in the closet.
public class MirrorView : MonoBehaviour
{
    // Every garment, in the same order as the groups below
    public List<GarmentData> garments = new();

    // One group per garment: its hanging picture plus its DetailSpots as children
    public List<GameObject> hangingGarments = new();

    // OnEnable runs each time ViewManager turns this view on
    private void OnEnable()
    {
        GarmentData picked = null;
        if (GameManager.instance != null)
        {
            picked = GameManager.instance.selectedGarment;
        }

        // Turn on the picked garment's group and turn off all the others
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
