using UnityEngine;

[CreateAssetMenu(fileName = "GlobalSettings", menuName = "Settings/GlobalSettings")]
public class GlobalSettings : ScriptableObject
{
    private const string _settingsPath = "Settings/Default";
    
    // Добавьте сюда ваши настройки
    public float TimeStep = 0.1f;
    public const float G = 6.6743e-11f;

    #region Convert
    
    /// <summary>
    /// На сколько делить реальные физические параметры
    /// </summary>
    public float ParametersScale = 1000f;
    public float TimeScale = 1.0f;

    #endregion

    #region Singleton

    private static GlobalSettings _instance;
    public static GlobalSettings Instance
    {
        get
        {
            if (_instance == null)
            {
                // Попробуем найти существующий экземпляр в ресурсах
                _instance = Resources.Load<GlobalSettings>(_settingsPath);

                // Если не найден, создадим новый экземпляр
                if (_instance == null)
                {
                    Debug.LogError("GlobalSettings instance not found. Please create one in the Resources folder.");
                }
            }
            return _instance;
        }
    }

    #endregion
}