using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {

public Tile(int q, int r)
    {
        this.Q = q;
        this.R = r;
        this.S = -(q + r);
    }

    public readonly int Q; // Column
    public readonly int R; // Row
    public readonly int S; // 

    // Data for map generation and maybe in-game effects.
    public float Elevation;
    public float Moisture;

    static readonly float WIDTH_MULTIPLIER = Mathf.Sqrt(3) / 2;

    float radius = 1f;

    public Vector3 Position()
    {
        return new Vector3(

            TileHorizontalSpacing() * (this.Q + this.R/2f),
            0,
            TileVerticalSpacing() * this.R
            );

    }

    public float TileHeight()
    {
        return radius * 2 ;
    }

    public float TileWidth()
    {
        return WIDTH_MULTIPLIER * TileHeight();
    }

    public float TileVerticalSpacing()
    {
        return TileHeight() * 0.75f;
    }

    public float TileHorizontalSpacing()
    {
        return TileWidth();
    }

}
