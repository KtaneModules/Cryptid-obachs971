using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile6 : MapTile
{
    public MapTile6()
    {
        id = 6;
        BoardTile[] spaces =
        {
            new BoardTile(SpaceType.Desert, TerritoryType.Bear),
            new BoardTile(SpaceType.Desert, TerritoryType.None),
            new BoardTile(SpaceType.Swamp, TerritoryType.None),
            new BoardTile(SpaceType.Swamp, TerritoryType.None),
            new BoardTile(SpaceType.Swamp, TerritoryType.None),
            new BoardTile(SpaceType.Forest, TerritoryType.None),

            new BoardTile(SpaceType.Mountain, TerritoryType.Bear),
            new BoardTile(SpaceType.Mountain, TerritoryType.None),
            new BoardTile(SpaceType.Swamp, TerritoryType.None),
            new BoardTile(SpaceType.Swamp, TerritoryType.None),
            new BoardTile(SpaceType.Forest, TerritoryType.None),
            new BoardTile(SpaceType.Forest, TerritoryType.None),

            new BoardTile(SpaceType.Mountain, TerritoryType.None),
            new BoardTile(SpaceType.Water, TerritoryType.None),
            new BoardTile(SpaceType.Water, TerritoryType.None),
            new BoardTile(SpaceType.Water, TerritoryType.None),
            new BoardTile(SpaceType.Water, TerritoryType.None),
            new BoardTile(SpaceType.Forest, TerritoryType.None)
        };
        base.spaces = spaces;
    }
}
