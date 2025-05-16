using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "SpaceObjectSettings", menuName = "Settings/SpaceObjectSettings")]
public class SpaceObjectSettings : ScriptableObject
{
    public string Name;
    public bool IsStatic;
    public float Mass;
    
    [Header("Self-orbiting")]
    public float Radius; // Радиус объекта в метрах
    public float OrbitalPeriod; // Период одного оборота вокруг своей оси в секундах
    public float RotationAxisTilt; // Угол наклона оси вращения в градусах
    public bool InvertedRotation; // Инвертировать вращение вокруг своей оси
    
    [Header("Orbiting around another object")]
    public float OrbitalInclination; // Orbital inclination in degrees
    public float AngularVelocity; // Angular velocity in radians per second (optional)
    public bool InvertedOrbit; // Инвертировать вращение вокруг статического объекта (если не статический)
    
    [HideInInspector] public float DistanceToStatic; // Расстояние до статического объекта в метрах (если не статический)
}

[CustomEditor(typeof(SpaceObjectSettings))]
public class SpaceObjectSettingsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var settings = (SpaceObjectSettings)target;

        settings.Name = EditorGUILayout.TextField("Name", settings.Name);
        settings.IsStatic = EditorGUILayout.Toggle("Is Static", settings.IsStatic);
        settings.Mass = EditorGUILayout.FloatField("Mass", settings.Mass);
        settings.Radius = EditorGUILayout.FloatField("Radius", settings.Radius);
        settings.OrbitalPeriod = EditorGUILayout.FloatField("OrbitalPeriod", settings.OrbitalPeriod);
        settings.RotationAxisTilt = EditorGUILayout.FloatField("RotationAxisTilt", settings.RotationAxisTilt);
        settings.OrbitalInclination = EditorGUILayout.FloatField("Orbital Inclination", settings.OrbitalInclination);
        settings.AngularVelocity = EditorGUILayout.FloatField("Angular Velocity", settings.AngularVelocity);
        settings.InvertedRotation = EditorGUILayout.Toggle("Inverted Rotation", settings.InvertedRotation);
        settings.InvertedOrbit = EditorGUILayout.Toggle("Inverted Orbit", settings.InvertedOrbit);
        
        if (!settings.IsStatic)
        {
            settings.DistanceToStatic = EditorGUILayout.FloatField("Distance To Static", settings.DistanceToStatic);
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(settings);
        }
    }
}