using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace HacMan_GD07
{
    public class EnemyInputComponent :MovementComponent
    {
        private readonly IntVector2[] _movementDirections = new[]
        {
            IntVector2.up,
            IntVector2.down,
            IntVector2.right,
            IntVector2.left,
        };

        protected override void Update()
        {
            if (transform.position == targetgridPosition.ToVector3())
            {
                // ------------------ Normal Way ------------------
                // var possibleDirections = new List<IntVector2>();
                //
                // foreach (var movementDirection in movementDirections)
                // {
                //     var potentialTargetPosition = targetGridPosition + movementDirection; // use targetGridPosition to be safe
                //
                //     if (potentialTargetPosition.IsWall()) continue;
                //     
                //     if (movementDirection != -currentInputDirection)
                //     {
                //         possibleDirections.Add(movementDirection);
                //     }
                // }

                // ------------------ Using LINQ ------------------
                var possibleDirections = _movementDirections.Where(movementDirection =>
                        !((targetgridPosition + movementDirection).IsWall()) &&
                        movementDirection != -currentInputDirection)
                    .ToList();

                // If we're at a dead end, turn back
                if (possibleDirections.Count < 1)
                {
                    possibleDirections.Add(-currentInputDirection);
                }

                var direction = Random.Range(0, possibleDirections.Count);

                currentInputDirection = possibleDirections[direction];
            }

            base.Update();
        }
    }

}

