using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Extensions
{
    internal static class AnimatorExtensions
    {
        public static bool HasParameter(this Animator animator, string name)
        {
            return animator.parameters.SingleOrDefault(x => x.name == name) != null;
        }
    }
}
