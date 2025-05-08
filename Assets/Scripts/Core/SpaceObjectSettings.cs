using UnityEngine;

[CreateAssetMenu(fileName = "SpaceObjectSettings", menuName = "Settings")]
public class SpaceObjectSettings : ScriptableObject
{
    public string Name;
    public bool IsStatic;
    public float Radius;
    public float RotationPeriod;
}