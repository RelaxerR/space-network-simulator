using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "SpaceObjectSettings", menuName = "Settings/SpaceObjectSettings")]
public class SpaceObjectSettings : ScriptableObject
{
    public string Name;
    public bool IsStatic;
    public float Mass;

    [HideInInspector] public float DistanceToStatic;
    [HideInInspector] public Vector3 StaticPosition;
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
            settings.StaticPosition = EditorGUILayout.Vector3Field("Static Position", settings.StaticPosition);
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(settings);
        }
    }
}