using System;
using UnityEngine;

public class SpaceObjectController : MonoBehaviour, IDynamicObject
{
    [SerializeField] private SpaceObjectSettings _settings;
    private SpaceObject _spaceObject;

    private void Awake()
    {
        _spaceObject = new SpaceObject(
            _settings.Name,
            _settings.IsStatic,
            _settings.DistanceToStatic,
            _settings.Mass
        );

    }

    public Vector3 GetPositionFromTime(float time)
    {
        if (_settings.IsStatic) return Vector3.zero;
        
        var r = _settings.DistanceToStatic;
        var M = _settings.Mass; // Предполагаем, что это масса центрального тела

        // Угловая скорость для круговой орбиты
        var angularVelocity = Mathf.Sqrt(GlobalSettings.G * M / Mathf.Pow(r, 3));

        // Позиция на плоскости XZ (можно изменить ось)
        var x = r * Mathf.Cos(angularVelocity * time);
        var y = 0f;
        var z = r * Mathf.Sin(angularVelocity * time);

        return new Vector3(x, y, z);
    }

    public Vector3 GetRotationFromTime(float time)
    {
        throw new NotImplementedException();
    }

    public void UpdatePosition()
    {
        throw new NotImplementedException();
    }
}
