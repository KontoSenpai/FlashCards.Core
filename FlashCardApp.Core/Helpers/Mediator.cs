using System;
using System.Collections.Generic;
using System.Linq;

namespace FlashCardApp.Core.Helpers
{
    public static class Mediator
    {
        private static IDictionary<string, List<Action<object>>> _dictionary =
            new Dictionary<string, List<Action<object>>>();

        public static void Subscribe(string key, Action<object> callback)
        {
            if (!_dictionary.ContainsKey(key))
            {
                _dictionary.Add(key, new List<Action<object>>
                {
                    callback
                });
            }
            else
            {
                if(!_dictionary[key].Any(c => c.Method.ToString() == callback.Method.ToString()))
                {
                    _dictionary[key].Add(callback);
                }
            }
        }

        public static void Unsubscribe(string key, Action<object> callback)
        {
            if (_dictionary.ContainsKey(key))
            {
                _dictionary[key].Remove(callback);
            }
        }

        public static void Notify(string key, object args = null)
        {
            if (_dictionary.ContainsKey(key))
            {
                _dictionary[key].ForEach(c => c(args));
            }
        }
    }
}
