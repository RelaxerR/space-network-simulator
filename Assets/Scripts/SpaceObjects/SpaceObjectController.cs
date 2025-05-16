using System;
using UnityEngine;

public class SpaceObjectController : MonoBehaviour, IDynamicObject
{
    [SerializeField] private SpaceObjectController StaticSpaceObject;
    [SerializeField] private SpaceObjectSettings _settings;
    
    private static GlobalSettings _globalSettings => GlobalSettings.Instance;

    public Vector3 GetPositionFromTime(float time)
    {
        if (_settings.IsStatic)
            return transform.position;

        const float G = GlobalSettings.G;
        var scaledMass = _settings.Mass / _globalSettings.ParametersScale;
        var scaledDistance = _settings.DistanceToStatic / _globalSettings.ParametersScale;
        var scaledTime = time / _globalSettings.ParametersScale / _globalSettings.TimeScale;
        var staticObject = StaticSpaceObject.transform.position;
        var staticRight = StaticSpaceObject.transform.right;

        float angularVelocity;
        if (_settings.AngularVelocity > 0f)
        {
            angularVelocity = _settings.AngularVelocity;
        }
        else
        {
            angularVelocity = Mathf.Sqrt(G * scaledMass / Mathf.Pow(scaledDistance, 2));
        }

        var angle = angularVelocity * scaledTime;
        if (_settings.InvertedOrbit)
            angle = -angle;

        var x = scaledDistance * Mathf.Cos(angle);
        var z = scaledDistance * Mathf.Sin(angle);

        // Rotate the orbital plane around the static object's local X axis
        var position = new Vector3(x, 0f, z);
        position = Quaternion.AngleAxis(_settings.OrbitalInclination, staticRight) * position;

        return staticObject + position;
    }

    public Vector3 GetRotationFromTime(float time)
    {
        // Период вращения вокруг своей оси
        var rotationPeriod = _settings.OrbitalPeriod / _globalSettings.ParametersScale / _globalSettings.TimeScale;
        var scaledTime = time / _globalSettings.ParametersScale / _globalSettings.TimeScale;
        
        // Угол наклона оси вращения
        var tilt = _settings.RotationAxisTilt * Mathf.Deg2Rad;

        // Вычисляем угол поворота вокруг своей оси
        var angle = (scaledTime / rotationPeriod) * 360f;

        // Возвращаем поворот объекта
        return new Vector3(tilt, angle, 0);
    }

    public void UpdateSelf(float time)
    {
        transform.position = GetPositionFromTime(time);
        transform.rotation = Quaternion.Euler(GetRotationFromTime(time));
    }
}
