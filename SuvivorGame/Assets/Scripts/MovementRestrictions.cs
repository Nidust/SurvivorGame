using System;
using UnityEngine;

public enum RestrictionType
{
    Object,
    Camera,
}

public class MovementRestrictions : MonoBehaviour
{
    private static MovementRestrictions Instance;

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
}
