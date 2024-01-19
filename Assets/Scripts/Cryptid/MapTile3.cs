using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile3 : MapTile
{
    public MapTile3()
    {
        id = 3;
        BoardTile[] spaces =
        {
            new BoardTile(SpaceType.Swamp, TerritoryType.None),
            new BoardTile(SpaceType.Swamp, TerritoryType.None),
            new BoardTile(SpaceType.Forest, TerritoryType.None),
            new BoardTile(SpaceType.Forest, TerritoryType.None),
            new BoardTile(SpaceType.Forest, TerritoryType.None),
            new BoardTile(SpaceType.Water, TerritoryType.None),

            new BoardTile(SpaceType.Swamp, TerritoryType.Cougar),
            new BoardTile(SpaceType.Swamp, TerritoryType.Cougar),
            new BoardTile(SpaceType.Forest, TerritoryType.None),
            new BoardTile(SpaceType.Mountain, TerritoryType.None),
            new BoardTile(SpaceType.Water, TerritoryType.None),
            new BoardTile(SpaceType.Water, TerritoryType.None),

            new BoardTile(SpaceType.Mountain, TerritoryType.Cougar),
            new BoardTile(SpaceType.Mountain, TerritoryType.None),
            new BoardTile(SpaceType.Mountain, TerritoryType.None),
            new BoardTile(SpaceType.Mountain, TerritoryType.None),
            new BoardTile(SpaceType.Water, TerritoryType.None),
            new BoardTile(SpaceType.Water, TerritoryType.None)
        };
        base.spaces = spaces;
    }
}
