using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HacMan_GD07.BaseGridObject;

namespace HacMan_GD07
{
    public static class ExtensionMethods
    {
        // Start is called before the first frame update
        public static Vector3 ToVector3(this IntVector2 vector2)
        {
            return new Vector3(vector2.x, vector2.y);
        }

        public static IntVector2 ToIntVector2(this Vector3 vector3)
        {
            return new IntVector2((int)vector3.x, (int)vector3.y);
        }

        public static bool IsWall(this IntVector2 vector2)
        {
            return LevelGeneratorSystem.Grid0[Mathf.Abs(vector2.y), Mathf.Abs(vector2.x)] == 1;
            return LevelGeneratorSystem.Grid1[Mathf.Abs(vector2.y), Mathf.Abs(vector2.x)] == 1;
            return LevelGeneratorSystem.Grid2[Mathf.Abs(vector2.y), Mathf.Abs(vector2.x)] == 1;
            return LevelGeneratorSystem.Grid3[Mathf.Abs(vector2.y), Mathf.Abs(vector2.x)] == 1;
            return LevelGeneratorSystem.Grid4[Mathf.Abs(vector2.y), Mathf.Abs(vector2.x)] == 1;
            return LevelGeneratorSystem.Grid5[Mathf.Abs(vector2.y), Mathf.Abs(vector2.x)] == 1;
            return LevelGeneratorSystem.Grid6[Mathf.Abs(vector2.y), Mathf.Abs(vector2.x)] == 1;
            return LevelGeneratorSystem.Grid7[Mathf.Abs(vector2.y), Mathf.Abs(vector2.x)] == 1;
            return LevelGeneratorSystem.Grid8[Mathf.Abs(vector2.y), Mathf.Abs(vector2.x)] == 1;
            return LevelGeneratorSystem.Grid9[Mathf.Abs(vector2.y), Mathf.Abs(vector2.x)] == 1;
        }
    }
}
