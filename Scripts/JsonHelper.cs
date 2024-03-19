using System;
using System.Collections.Generic;
using UnityEngine;

namespace VHon
{
    public static class JsonHelper
    {
        public static List<T> FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }        

        public static string ToJson<T>(List<T> list)
        {
            Wrapper<T> wrapper = new() { Items = list };
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(List<T> list, bool prettyPrint)
        {
            Wrapper<T> wrapper = new() { Items = list };
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        class Wrapper<T>
        {
            public List<T> Items;
        }
    }
}