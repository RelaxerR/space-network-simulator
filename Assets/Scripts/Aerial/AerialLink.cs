using UnityEngine;

public class AerialLink
{
    private Satellite _outcomingSatellite;
    private Satellite _incomingSatellite;
    
    public AerialLink(Satellite outcomingSatellite, Satellite incomingSatellite)
    {
        _outcomingSatellite = outcomingSatellite;
        _incomingSatellite = incomingSatellite;
    }
}