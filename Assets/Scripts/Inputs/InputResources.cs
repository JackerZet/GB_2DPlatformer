using System;
using UnityEngine;

namespace Platformer.Inputs
{
    public static class InputResources
    {
        public static T Load<T>(string path) where T : UnityEngine.Object
        {
            T component = Resources.Load<T>(path);

            if (component == null)
                throw new Exception($"The component in {path} is incorrectly named or missing from the resources folder");

            return component;
        }
        public static GameObject Load(string path)
        {
            var component = (GameObject)Resources.Load(path);

            if (component == null)
                throw new Exception($"The component in {path} is incorrectly named or missing from the resources folder");

            return component;
        }
    }
}
