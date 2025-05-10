using UnityEngine;

public class SpaceObject
{
    public string Name { get; private set; }
    public bool IsStatic { get; private set; }
    public float DistanceToStatic { get; private set; }
    public float Mass { get; private set; }
    public Vector3 Velocity { get; set; } // Add this property to store velocity
    
    public SpaceObject(string name, bool isStatic, float distanceToStatic, float mass)
    {
        Name = name;
        IsStatic = isStatic;
        DistanceToStatic = distanceToStatic;
        Mass = mass;
        Velocity = Vector3.zero; // Initialize velocity to zero
    }
}