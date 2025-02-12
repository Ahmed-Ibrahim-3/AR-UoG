/*
 * https://stackoverflow.com/a/36244111
 * programmer, dbc
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace CENSIS.Utility
{
    public static class FileHandler
    {
        public static List<T> ReadFromJSON<T>(string filename)
        {
            string content = Resources.Load<TextAsset>(filename).text;
            if (string.IsNullOrEmpty(content) || content == "{}")
            {
                return new List<T>();
            }

            List<T> res = JsonHelper.FromJson<T>(content).ToList();

            return res;
        }
    }

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonConvert.DeserializeObject<Wrapper<T>>(json);
            return wrapper.Items;
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }
}
