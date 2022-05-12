using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace HacMan_GD07
{
    public class MovementComponent : BaseGridObject
    {
        public float MovementSpeed;
        protected IntVector2 currentInputDirection;
        protected float ProgressToTarget = 1f;
        protected IntVector2 previousInputDirection;
        protected IntVector2 targetgridPosition;
        // Start is called before the first frame update
        protected virtual void Start()
        {
            targetgridPosition = transform.position.ToIntVector2();
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            // Debug.Log($"Transform: {transform.position}|| TargetGridPosition: {targetGridPosition.x}||{targetGridPosition.y}");
            // If we're arrived...
            if (transform.position == targetgridPosition.ToVector3())
            {
                ProgressToTarget = 0f;
                GridPosition = targetgridPosition;
            }

            // If we set a new target AND our current input is VALID -> NOT A WALL
            if (GridPosition == targetgridPosition && !(GridPosition + currentInputDirection).IsWall())
            {
                targetgridPosition += currentInputDirection;
                previousInputDirection = currentInputDirection;
            }
            // If we set a new target AND our current input is NOT VALID -> IS A WALL
            else if (GridPosition == targetgridPosition && !(GridPosition + previousInputDirection).IsWall())
            {
                targetgridPosition += previousInputDirection;
            }

            if (GridPosition == targetgridPosition) return;

            ProgressToTarget += MovementSpeed * Time.deltaTime;

            transform.position = Vector3.Lerp(transform.position, targetgridPosition.ToVector3(), ProgressToTarget);
        }
    }
    [Serializable]
    public struct IntVector2
    {
        public int x;
        public int y;

        public static IntVector2 zero => new IntVector2(0, 0);
        public static IntVector2 right => new IntVector2(1, 0);
        public static IntVector2 left => new IntVector2(-1, 0);
        public static IntVector2 up => new IntVector2(0, 1);
        public static IntVector2 down => new IntVector2(0, -1);

        public IntVector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static IntVector2 operator +(IntVector2 v1, IntVector2 v2)
        {
            return new IntVector2(v1.x + v2.x, v1.y + v2.y);
        }

        public static IntVector2 operator -(IntVector2 v)
        {
            return new IntVector2(-v.x, -v.y);
        }

        public static bool operator ==(IntVector2 v1, IntVector2 v2)
        {
            return (v1.x == v2.x && v1.y == v2.y);
        }

        public static bool operator !=(IntVector2 v1, IntVector2 v2)
        {
            return (v1.x != v2.x || v1.y != v2.y);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}




