using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile4 : MapTile
{
    public MapTile4()
    {
        id = 4;
        BoardTile[] spaces =
        {
            new BoardTile(SpaceType.Desert, TerritoryType.None),
            new BoardTile(SpaceType.Desert, TerritoryType.None),
            new BoardTile(SpaceType.Mountain, TerritoryType.None),
            new BoardTile(SpaceType.Mountain, TerritoryType.None),
            new BoardTile(SpaceType.Mountain, TerritoryType.None),
            new BoardTile(SpaceType.Mountain, TerritoryType.None),

            new BoardTile(SpaceType.Desert, TerritoryType.None),
            new BoardTile(SpaceType.Desert, TerritoryType.None),
            new BoardTile(SpaceType.Mountain, TerritoryType.None),
            new BoardTile(SpaceType.Water, TerritoryType.None),
            new BoardTile(SpaceType.Water, TerritoryType.None),
            new BoardTile(SpaceType.Water, TerritoryType.Cougar),

            new BoardTile(SpaceType.Desert, TerritoryType.None),
            new BoardTile(SpaceType.Desert, TerritoryType.None),
            new BoardTile(SpaceType.Desert, TerritoryType.None),
            new BoardTile(SpaceType.Forest, TerritoryType.None),
            new BoardTile(SpaceType.Forest, TerritoryType.None),
            new BoardTile(SpaceType.Forest, TerritoryType.Cougar)
        };
        base.spaces = spaces;
    }
}
