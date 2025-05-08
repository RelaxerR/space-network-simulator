using UnityEngine;

[CreateAssetMenu(fileName = "GlobalSettings", menuName = "Settings/GlobalSettings")]
public class GlobalSettings : ScriptableObject
{
    // Добавьте сюда ваши настройки
    public float TimeStep = 0.1f;
}