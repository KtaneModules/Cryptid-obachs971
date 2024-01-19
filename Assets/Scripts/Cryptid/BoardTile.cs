using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile 
{
	public readonly SpaceType type;
	public readonly TerritoryType territory;
	public BoardTile(SpaceType type, TerritoryType territory)
	{
		this.type = type;
		this.territory = territory;
	}
}
