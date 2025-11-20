using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Core
{
    public class PlayerData : Singleton<PlayerData>
    {
        private float _r;
        private float _g;
        private float _b;

        private readonly Dictionary<Type, object> _data = new();

        public int CloseUpCardIndex;

        public float R => _r;
        public float G => _g;
        public float B => _b;

        protected override void Awake()
        {
            base.Awake();

            _r = Random.Range(0.0f, 1.0f);
            _g = Random.Range(0.0f, 1.0f);
            _b = Random.Range(0.0f, 1.0f);
        }

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
