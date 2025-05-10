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
    public float OrbitalPeriod; // Период одного оборота вокруг своей оси в секунду
    public float RotationAxisTilt; // Угол наклона оси вращения в градусах

    [HideInInspector] public float DistanceToStatic;
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