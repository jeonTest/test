﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    [SerializeField]
    [Range(1, 50)]
    private int width = 10;

    [SerializeField]
    [Range(1, 50)]
    private int height = 10;

    [SerializeField]
    private float size = 1f;

    [SerializeField]
    private Transform[] wallPrefab = null;

    //[SerializeField]
    //private Transform floorPrefab = null;

    void Start()
    {
        var maze = MazeGenerator.Generate(width, height);
        Draw(maze);
    }

    private void Draw(WallState[,] maze)
    {
        //var floor = Instantiate(floorPrefab, transform);
        //floor.localScale = new Vector3((float)width/10, 1, (float)height/10);
        //floor.position = new Vector3(-0.5f, 0, -0.5f);

        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                var cell = maze[i, j];
                var position = new Vector3(-width / 2 + i, 0, -height / 2 + j);

                if (cell.HasFlag(WallState.UP))
                {
                    var topWall = Instantiate(wallPrefab[Random.Range(0, wallPrefab.Length)], transform) as Transform;
                    topWall.position = position + new Vector3(0, (topWall.localScale.y/100), size / 2);
                    topWall.localScale = new Vector3(topWall.localScale.x, topWall.localScale.y, topWall.localScale.z);
                }

                if (cell.HasFlag(WallState.LEFT))
                {
                    var leftWall = Instantiate(wallPrefab[Random.Range(0, wallPrefab.Length)], transform) as Transform;
                    leftWall.position = position + new Vector3(-size / 2, (leftWall.localScale.y / 100), 0);
                    leftWall.localScale = new Vector3(leftWall.localScale.x, leftWall.localScale.y, leftWall.localScale.z);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                }

                if (i == width - 1)
                {
                    if (cell.HasFlag(WallState.RIGHT))
                    {
                        var rightWall = Instantiate(wallPrefab[Random.Range(0, wallPrefab.Length)], transform) as Transform;
                        rightWall.position = position + new Vector3(+size / 2, (rightWall.localScale.y / 100), 0);
                        rightWall.localScale = new Vector3(rightWall.localScale.x, rightWall.localScale.y, rightWall.localScale.z);
                        rightWall.eulerAngles = new Vector3(0, 90, 0);
                    }
                }

                if (j == 0)
                {
                    if (cell.HasFlag(WallState.DOWN))
                    {
                        var bottomWall = Instantiate(wallPrefab[Random.Range(0, wallPrefab.Length)], transform) as Transform;
                        bottomWall.position = position + new Vector3(0, (bottomWall.localScale.y / 100), -size / 2);
                        bottomWall.localScale = new Vector3(bottomWall.localScale.x, bottomWall.localScale.y, bottomWall.localScale.z);
                    }
                }
            }
        }
    }
}
