using System;
using UnityEngine;

namespace Assets.Scripts.Extensions
{
    internal static class VectorExtensions
    {
        public static Vector3 Limit(
            this Vector3 position,
            RestrictionType restrictionType = RestrictionType.Object,
            Vector2? padding = null)
        {
            Bounds limit = MovementBoundary.GetLimit(restrictionType);

            if (padding == null)
            {
                padding = Vector2.zero;
            }

            position.x = Mathf.Clamp(
                value: position.x,
                min: limit.min.x + (padding?.x ?? 0),
                max: limit.max.x - (padding?.x ?? 0)
            );

            position.y = Mathf.Clamp(
                value: position.y,
                min: limit.min.y + (padding?.y ?? 0),
                max: limit.max.y - (padding?.y ?? 0)
            );

            return position;
        }
    }
}
