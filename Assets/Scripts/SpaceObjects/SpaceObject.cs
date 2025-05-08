using UnityEngine;

public class SpaceObject
{
    public string Name { get; private set; }
    public bool IsStatic { get; private set; }
    public float DistanceToStatic { get; private set; }
    public float Mass { get; private set; }
    
    public SpaceObject(string name, bool isStatic, float distanceToStatic, float mass)
    {
        Name = name;
        IsStatic = isStatic;
        DistanceToStatic = distanceToStatic;
        Mass = mass;
    }
}