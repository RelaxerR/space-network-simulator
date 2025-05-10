using UnityEngine;

public interface IDynamicObject
{
    public abstract Vector3 GetPositionFromTime(float time);
    public abstract Vector3 GetRotationFromTime(float time);
    public abstract void UpdatePosition(float time);
}