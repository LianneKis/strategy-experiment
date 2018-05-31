using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continent_World : World {

    public override void GenerateMap()
    {
        // First, call the baasae version to make all the hexes we need
        base.GenerateMap();

        // Make some kind of raised area
        ElevateArea(21, 15, 4);

        // Simulate Rainfall

        // Now make sure all the hex visuals are updated to match the data

        UpdateTileVisuals();
        
    }

    void ElevateArea(int q, int r, int radius)
    {

        Tile centerTile = GetTileAt(q, r);

        centerTile.Elevation = 0.5f;
    }

}
