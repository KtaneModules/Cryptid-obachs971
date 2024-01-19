using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile2 : MapTile
{
    public MapTile2()
    {
        id = 2;
        BoardTile[] spaces =
        {
            new BoardTile(SpaceType.Swamp, TerritoryType.Cougar),
            new BoardTile(SpaceType.Forest, TerritoryType.Cougar),
            new BoardTile(SpaceType.Forest, TerritoryType.Cougar),
            new BoardTile(SpaceType.Forest, TerritoryType.None),
            new BoardTile(SpaceType.Forest, TerritoryType.None),
            new BoardTile(SpaceType.Forest, TerritoryType.None),

            new BoardTile(SpaceType.Swamp, TerritoryType.None),
            new BoardTile(SpaceType.Swamp, TerritoryType.None),
            new BoardTile(SpaceType.Forest, TerritoryType.None),
            new BoardTile(SpaceType.Desert, TerritoryType.None),
            new BoardTile(SpaceType.Desert, TerritoryType.None),
            new BoardTile(SpaceType.Desert, TerritoryType.None),

            new BoardTile(SpaceType.Swamp, TerritoryType.None),
            new BoardTile(SpaceType.Mountain, TerritoryType.None),
            new BoardTile(SpaceType.Mountain, TerritoryType.None),
            new BoardTile(SpaceType.Mountain, TerritoryType.None),
            new BoardTile(SpaceType.Mountain, TerritoryType.None),
            new BoardTile(SpaceType.Desert, TerritoryType.None)
        };
        base.spaces = spaces;
    }
}
