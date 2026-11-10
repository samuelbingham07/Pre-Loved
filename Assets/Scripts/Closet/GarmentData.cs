using UnityEngine;

// One asset per garment in the closet.
[CreateAssetMenu(fileName = "GarmentData", menuName = "Scriptable Objects/GarmentData")]
public class GarmentData : ScriptableObject
{
    public string displayName;

    // Photo of me wearing it, shown when you click the mirror
    public Sprite mirrorImage;

    // Text shown under the mirror photo
    public string tryOnText;
}
