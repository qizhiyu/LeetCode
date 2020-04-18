using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    ///<summary>
    ///Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.
    ///</summary>
    public int NumIslands(char[][] grid)
    {
        var width = grid.Length;
        if (width == 0) return 0;

        var height = grid[0].Length;
        var map = grid.Select(x => x.Select(y => 0).ToList()).ToList();
        // var links = new Dictionary<int, int>();

        var id = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                // water
                if (grid[i][j] == '0') continue;

                // touched
                if (map[i][j] != 0)
                    continue;

                map[i][j] = ++id;

                //update all neighbors 
                Mark(map, grid, i, j, id);

            }
        }

        return id - 1;
    }

    void Mark(List<List<int>> map, char[][] grid, int i, int j, int id)
    {
        if (grid[i][j] == '1' && map[i][j] == 0)
        {
            map[i][j] = id;
            MarkAllNeighbors(map, grid, i, j, id);
        }
    }

    void MarkAllNeighbors(List<List<int>> map, char[][] grid, int i, int j, int id)
    {
        //left
        if (i > 0)
        {
            Mark(map, grid, i - 1, j, id);
        }

        //up
        if (j > 0)
        {
            Mark(map, grid, i, j - 1, id);
        }

        //right
        if (j + 1 < grid[i].Length)
        {
            Mark(map, grid, i, j + 1, id);
        }

        //below
        if (i + 1 < grid.Length)
        {
            Mark(map, grid, i + 1, j, id);
        }

    }

}
