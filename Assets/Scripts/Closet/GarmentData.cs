using UnityEngine;

[CreateAssetMenu(fileName = "GarmentData", menuName = "Scriptable Objects/GarmentData")]
public class GarmentData : ScriptableObject
{
    public string displayName;

    public Sprite mirrorImage;

    public string tryOnText;
}
