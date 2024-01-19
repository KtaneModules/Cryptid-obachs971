using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule 
{
    public string ruleStr;
    public HashSet<string> validSpaces;
    public Rule(string ruleStr, HashSet<string> validSpaces)
    {
        this.ruleStr = ruleStr;
        this.validSpaces = validSpaces;
    }

    public string toString()
    {
        return ruleStr;
    }
}
