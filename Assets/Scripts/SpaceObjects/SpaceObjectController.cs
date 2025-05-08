using System;
using UnityEngine;

public class SpaceObjectController : MonoBehaviour
{
    private SpaceObject _spaceObject;

    private void Awake()
    {
        _spaceObject = new SpaceObject();
    }
    
    
}
