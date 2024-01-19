using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile1 : MapTile
{
    public MapTile1() 
    {
        id = 1;
        BoardTile[] spaces =
        {
            new BoardTile(SpaceType.Water, TerritoryType.None),
            new BoardTile(SpaceType.Water, TerritoryType.None),
            new BoardTile(SpaceType.Water, TerritoryType.None),
            new BoardTile(SpaceType.Water, TerritoryType.None),
            new BoardTile(SpaceType.Forest, TerritoryType.None),
            new BoardTile(SpaceType.Forest, TerritoryType.None),

            new BoardTile(SpaceType.Swamp, TerritoryType.None),
            new BoardTile(SpaceType.Swamp, TerritoryType.None),
            new BoardTile(SpaceType.Water, TerritoryType.None),
            new BoardTile(SpaceType.Desert, TerritoryType.None),
            new BoardTile(SpaceType.Forest, TerritoryType.None),
            new BoardTile(SpaceType.Forest, TerritoryType.None),

            new BoardTile(SpaceType.Swamp, TerritoryType.None),
            new BoardTile(SpaceType.Swamp, TerritoryType.None),
            new BoardTile(SpaceType.Desert, TerritoryType.None),
            new BoardTile(SpaceType.Desert, TerritoryType.Bear),
            new BoardTile(SpaceType.Desert, TerritoryType.Bear),
            new BoardTile(SpaceType.Forest, TerritoryType.None)
        };
        base.spaces = spaces;
    }
}
