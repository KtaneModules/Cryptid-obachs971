using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure 
{
    public readonly StructureType type;
    public readonly StructureColor color;
    public string spaceName;
    public Structure(StructureType type, StructureColor color, string spaceName)
    {
        this.type = type;
        this.color = color;
        this.spaceName = spaceName;
    }
}
