using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HacMan_GD07
{
    public class LevelGrid 
    {
        public int[,] Grid;

        public LevelGrid(int[,] grid)
        {
            this.Grid = grid;
        }

    }
}
