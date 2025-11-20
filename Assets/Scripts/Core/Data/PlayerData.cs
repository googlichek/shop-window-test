using System;
using System.Collections.Generic;

namespace Game.Core
{
    public class PlayerData : Singleton<PlayerData>
    {
        private readonly Dictionary<Type, object> _data = new();

        public int CloseUpCardIndex;

        public T GetData<T>() where T : class
        {
            var type = typeof(T);

            if (_data.TryGetValue(type, out var data))
            {
                return data as T;
            }

            return null;
        }

        public void SetData<T>(T data) where T : class
        {
            _data[typeof(T)] = data;
        }
    }
}
