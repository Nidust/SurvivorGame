using System;
using UnityEngine;

public enum RestrictionType
{
    Object,
    Camera,
}

public class MovementBoundary : MonoBehaviour
{
    private static MovementBoundary Instance;

    [SerializeField]
    private Boundary objectLimit;
    [SerializeField]
    private Boundary cameraLimit;

    private void Awake()
    {
        Instance = this;
    }

    public static Bounds GetLimit(RestrictionType restriction)
    {
        switch (restriction)
        {
            case RestrictionType.Object:
                return Instance.objectLimit.GetBounds();
            case RestrictionType.Camera:
                return Instance.cameraLimit.GetBounds();
            default:
                throw new Exception("???? ?? RestrictionType ???");
        }
    }

    public static bool IsInside(Vector3 position, RestrictionType type)
    {
        Bounds bounds = GetLimit(type);

        return bounds.min.x < position.x 
            && bounds.max.x > position.x
            && bounds.min.y < position.y
            && bounds.max.y > position.y;
    }
}
