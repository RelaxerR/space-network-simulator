using UnityEngine;

public class SpaceObject
{
    public string Name { get; private set; }
    public bool IsStatic { get; private set; }
    public float Radius { get; private set; }
    public float RotationPeriod { get; private set; }
    
    public SpaceObject(string name, bool isStatic, float radius, float rotationPeriod)
    {
        Name = name;
        IsStatic = isStatic;
        Radius = radius;
        RotationPeriod = rotationPeriod;
    }
}