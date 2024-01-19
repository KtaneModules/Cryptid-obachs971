using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile5 : MapTile
{
    public MapTile5()
    {
        id = 5;
        BoardTile[] spaces =
        {
            new BoardTile(SpaceType.Swamp, TerritoryType.None),
            new BoardTile(SpaceType.Swamp, TerritoryType.None),
            new BoardTile(SpaceType.Swamp, TerritoryType.None),
            new BoardTile(SpaceType.Mountain, TerritoryType.None),
            new BoardTile(SpaceType.Mountain, TerritoryType.None),
            new BoardTile(SpaceType.Mountain, TerritoryType.None),

            new BoardTile(SpaceType.Swamp, TerritoryType.None),
            new BoardTile(SpaceType.Desert, TerritoryType.None),
            new BoardTile(SpaceType.Desert, TerritoryType.None),
            new BoardTile(SpaceType.Water, TerritoryType.None),
            new BoardTile(SpaceType.Mountain, TerritoryType.None),
            new BoardTile(SpaceType.Mountain, TerritoryType.Bear),

            new BoardTile(SpaceType.Desert, TerritoryType.None),
            new BoardTile(SpaceType.Desert, TerritoryType.None),
            new BoardTile(SpaceType.Water, TerritoryType.None),
            new BoardTile(SpaceType.Water, TerritoryType.None),
            new BoardTile(SpaceType.Water, TerritoryType.Bear),
            new BoardTile(SpaceType.Water, TerritoryType.Bear)
        };
        base.spaces = spaces;
    }
}
