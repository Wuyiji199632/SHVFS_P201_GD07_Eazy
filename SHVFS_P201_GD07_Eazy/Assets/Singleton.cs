using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HacMan_GD07
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance != null) return instance;
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    instance = new GameObject(typeof(T).Name).AddComponent<T>();
                    
                }
                DontDestroyOnLoad(instance.gameObject);
                return instance;
            }
        }
        protected virtual void Awake()
        {
            if(instance!=null&&instance!=(T)this)
            {
                Destroy(gameObject);
            }
        }
    }
}

