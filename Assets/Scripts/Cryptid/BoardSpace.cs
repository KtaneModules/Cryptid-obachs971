using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpace 
{
	public readonly string id;
	public readonly SpaceType type;
	public readonly TerritoryType territory;

	public BoardSpace(string id, SpaceType type, TerritoryType territory)
	{
		this.id = id;
		this.type = type;
		this.territory = territory;
	}
	
}
