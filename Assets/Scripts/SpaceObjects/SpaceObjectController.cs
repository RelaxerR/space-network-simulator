using System;
using UnityEngine;

public class SpaceObjectController : MonoBehaviour, IDynamicObject
{
    [SerializeField] private SpaceObjectController StaticSpaceObject;
    [SerializeField] private SpaceObjectSettings _settings;
    private SpaceObject _spaceObject;
    
    private static GlobalSettings _globalSettings => GlobalSettings.Instance;

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
        if (_settings.IsStatic)
            return transform.position;

        // Гравитационная постоянная
        const float G = GlobalSettings.G;

        // Масштабируем параметры
        var scaledMass = StaticSpaceObject._spaceObject.Mass / _globalSettings.ParametersScale;
        var scaledDistance = _settings.DistanceToStatic / _globalSettings.ParametersScale;
        var scaledTime = time / _globalSettings.ParametersScale / _globalSettings.TimeScale;

        // Получаем статический объект, вокруг которого вращается текущее тело
        var staticObject = StaticSpaceObject.transform.position;

        // Вычисляем угловую скорость (ω) для круговой орбиты
        var angularVelocity = Mathf.Sqrt(G * scaledMass / Mathf.Pow(scaledDistance, 3));

        // Вычисляем текущий угол на орбите
        var angle = angularVelocity * scaledTime;

        // Вычисляем координаты x и z (движение по круговой орбите в плоскости XZ)
        var x = staticObject.x + scaledDistance * Mathf.Cos(angle);
        var z = staticObject.z + scaledDistance * Mathf.Sin(angle);

        // Возвращаем позицию (y остаётся неизменной, если орбита в плоскости XZ)
        return new Vector3(x, transform.position.y, z);
    }

    public Vector3 GetRotationFromTime(float time)
    {
        throw new NotImplementedException();
    }

    public void UpdatePosition(float time)
    {
        transform.position = GetPositionFromTime(time);
    }
}
