using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace HacMan_GD07
{
    public class BaseGridObject : MonoBehaviour
    {
        public IntVector2 GridPosition;
        private Vector3 asdf;
        public Vector2Int GridPos;
        // Start is called before the first frame update
        private void OnEnable()
        {
            var whatever = Vector2Int.zero;
            var whateverAlso = new Vector2(0, 0);
            var whateverAgain = IntVector2.zero;
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
       
    }
}
