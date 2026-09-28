using _Project.Develop.Common;
using UnityEngine;

namespace _Project.Develop.Utils.TransformUtils
{
    public interface IRotatable : IUpdatable
    {
        void SetDirection(Vector3 direction);
    }
}