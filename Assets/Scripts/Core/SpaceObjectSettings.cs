using UnityEngine;

[CreateAssetMenu(fileName = "SpaceObjectSettings", menuName = "Settings/SpaceObjectSettings")]
public class SpaceObjectSettings : ScriptableObject
{
    public string Name;
    public bool IsStatic;
    public float Mass;
}