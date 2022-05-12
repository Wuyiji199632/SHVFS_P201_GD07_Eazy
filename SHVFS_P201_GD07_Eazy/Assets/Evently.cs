using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace HacMan_GD07
{
    public class Evently
    {
        private static Evently instance;
        public static Evently Instance => instance??=new Evently();
        private readonly Dictionary<Type, Delegate> delegates = new Dictionary<Type, Delegate>();
        public void Subscribe<T>(Action<T> del)
        {
            if(delegates.ContainsKey(typeof(T)))
            { delegates[typeof(T)] = Delegate.Combine(delegates[typeof(T)], del); }
            else { delegates[typeof(T)] = del; }
                // delegates.Add(T.GetType();del);
        }
        public void UnSubscribe<T>(Action<T> del)
        {
            if (delegates.ContainsKey(typeof(T))) return;
          var curDel = Delegate.Remove(delegates[typeof(T)], del);
            if(curDel==null)
            {
                delegates.Remove(typeof(T));
            }
            else { delegates[typeof(T)] = curDel; }
        }
        public void Publish<T>(T e)
        {
            if(e==null)
            {
                Debug.Log($"invalid event arg:{typeof(T)}");
                return;
            }
            if(delegates.ContainsKey(e.GetType()))
            {
                delegates[e.GetType()].DynamicInvoke(e);
            }
        }
        

    }
    
}
