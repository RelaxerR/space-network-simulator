using System;
using UnityEngine;

public class SpaceObjectController : MonoBehaviour, IDynamicObject
{
    [SerializeField] private SpaceObjectSettings _settings;
    private SpaceObject _spaceObject;

    private void Awake()
    {
        _spaceObject = new SpaceObject
            (
                _settings.name,
                _settings.IsStatic,
                _settings.Radius,
                _settings.RotationPeriod
                );
        
    }

    public Vector3 GetPositionFromTime(float time)
    {
        throw new NotImplementedException();
    }

    public Vector3 GetRotationFromTime(float time)
    {
        //Напиши метод GetRotationFromTime. Он должен рассчитывать вращение объекта из __spaceObject.RotationPeriod и _settings.RotationOffset (это параметр, отвечающий за смещение оси орбиты). Мне 
        throw new NotImplementedException();
    }

    public void UpdatePosition()
    {
        throw new NotImplementedException();
    }
}
