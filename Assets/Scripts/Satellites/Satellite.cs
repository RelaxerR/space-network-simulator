using System.Collections.Generic;
using UnityEngine;

public class Satellite
{
    public float OrbitalRadius { get; private set; }
    public float OrbitalPeriod { get; private set; }
    
    private readonly List<AerialLink> _aerialLinks;

    public Satellite()
    {
        _aerialLinks = new List<AerialLink>();
    }
    
    public void CreateAerialLink(Satellite incomingSatellite)
    {
        var aerialLink = new AerialLink(this, incomingSatellite);
        _aerialLinks.Add(aerialLink);
    }
}