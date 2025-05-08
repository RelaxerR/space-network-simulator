using UnityEngine;

[CreateAssetMenu(fileName = "GlobalSettings", menuName = "Settings/GlobalSettings")]
public class GlobalSettings : ScriptableObject
{
    // Добавьте сюда ваши настройки
    public float TimeStep = 0.1f;
    public const float G = 6.6743e-11f;

    #region Convert

    public float MetersInUnit = 100f;
    public float TimeScale = 1.0f;

    #endregion
}