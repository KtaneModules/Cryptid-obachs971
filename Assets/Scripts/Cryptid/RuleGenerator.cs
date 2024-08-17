using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleGenerator 
{

    public Rule[] rules;
    public string solution;
    private List<string> allSpaces;
    public RuleGenerator(Board board, Dictionary<string, List<List<string>>> spacesWithin, int numRules)
    {
        initAllSpaces(board);
        rules = generateRules(board, spacesWithin, numRules);
    }
    public List<string> generateSubmitSpaces()
    {
        Dictionary<string, int> scores = new Dictionary<string, int>();
        foreach(char let in "ABCDEFGHIJKL")
        {
            for (int num = 1; num <= 9; num++)
                scores.Add(let + "" + num, 0);
        }
        foreach(Rule rule in rules)
        {
            foreach (string space in rule.validSpaces)
                scores[space]++;
        }
        List<string> submitSpaces = new List<string>();
        int best = rules.Length;
        while (submitSpaces.Count < 9)
        {
            best--;
            foreach (KeyValuePair<string, int> entry in scores)
            {
                if (entry.Value == best)
                    submitSpaces.Add(entry.Key);
            }
            submitSpaces.Shuffle();
            while (submitSpaces.Count > 9)
                submitSpaces.RemoveAt(0);
        }
        submitSpaces.Add(solution);
        return submitSpaces;
    }
	private Rule[] generateRules(Board board, Dictionary<string, List<List<string>>> spacesWithin, int numRules)
    {
        List<Rule> rules = generateAllRules(board, spacesWithin);
        //Debug.LogFormat("RULE COUNT: {0}", rules.Count);
        switch(numRules)
        {
            case 3:
                for (int a = 0; a < rules.Count; a++)
                {
                    for (int b = a + 1; b < rules.Count; b++)
                    {
                        for (int c = b + 1; c < rules.Count; c++)
                        {
                            HashSet<string> validSpaces = new HashSet<string>(rules[a].validSpaces);
                            validSpaces.IntersectWith(rules[b].validSpaces);
                            validSpaces.IntersectWith(rules[c].validSpaces);
                            if (validSpaces.Count == 1)
                            {
                                bool r = hasRedundancy(new Rule[] { rules[a], rules[b], rules[c] });
                                if (!r)
                                {
                                    solution = validSpaces.PickRandom();
                                    return new Rule[] { rules[a], rules[b], rules[c] };
                                }
                            }

                        }
                    }
                }
                return null;
            case 4:
                for (int a = 0; a < rules.Count; a++)
                {
                    for (int b = a + 1; b < rules.Count; b++)
                    {
                        for (int c = b + 1; c < rules.Count; c++)
                        {
                            for(int d = c + 1; d < rules.Count; d++)
                            {
                                HashSet<string> validSpaces = new HashSet<string>(rules[a].validSpaces);
                                validSpaces.IntersectWith(rules[b].validSpaces);
                                validSpaces.IntersectWith(rules[c].validSpaces);
                                validSpaces.IntersectWith(rules[d].validSpaces);
                                if (validSpaces.Count == 1)
                                {
                                    bool r = hasRedundancy(new Rule[] { rules[a], rules[b], rules[c], rules[d] });
                                    if (!r)
                                    {
                                        solution = validSpaces.PickRandom();
                                        return new Rule[] { rules[a], rules[b], rules[c], rules[d] };
                                    }
                                }
                            }
                        }
                    }
                }
                return null;
            case 5:
                for (int a = 0; a < rules.Count; a++)
                {
                    for (int b = a + 1; b < rules.Count; b++)
                    {
                        for (int c = b + 1; c < rules.Count; c++)
                        {
                            for (int d = c + 1; d < rules.Count; d++)
                            {
                                for(int e = d + 1; e < rules.Count; e++)
                                {
                                    HashSet<string> validSpaces = new HashSet<string>(rules[a].validSpaces);
                                    validSpaces.IntersectWith(rules[b].validSpaces);
                                    validSpaces.IntersectWith(rules[c].validSpaces);
                                    validSpaces.IntersectWith(rules[d].validSpaces);
                                    validSpaces.IntersectWith(rules[e].validSpaces);
                                    if (validSpaces.Count == 1)
                                    {
                                        bool r = hasRedundancy(new Rule[] { rules[a], rules[b], rules[c], rules[d], rules[e] });
                                        if (!r)
                                        {
                                            solution = validSpaces.PickRandom();
                                            return new Rule[] { rules[a], rules[b], rules[c], rules[d], rules[e] };
                                        }
                                            
                                    }
                                }
                            }
                        }
                    }
                }
                return null;
        }
        return null;
    }
    private List<Rule> generateAllRules(Board board, Dictionary<string, List<List<string>>> spacesWithin)
    {
        List<Rule> rules = new List<Rule>();
        List<string> forestSpaces = getTerrainSpaces(board, SpaceType.Forest);
        List<string> desertSpaces = getTerrainSpaces(board, SpaceType.Desert);
        List<string> waterSpaces = getTerrainSpaces(board, SpaceType.Water);
        List<string> swampSpaces = getTerrainSpaces(board, SpaceType.Swamp);
        List<string> mountainSpaces = getTerrainSpaces(board, SpaceType.Mountain);

        rules.AddRange(generateRuleSet1(forestSpaces, desertSpaces, waterSpaces, swampSpaces, mountainSpaces));
        rules.AddRange(generateRuleSet2(forestSpaces, desertSpaces, waterSpaces, swampSpaces, mountainSpaces, board, spacesWithin));
        rules.AddRange(generateRuleSet3(board, spacesWithin));
        rules.AddRange(generateRuleSet4(board, spacesWithin));
        return rules.Shuffle();
    }
    private List<Rule> generateRuleSet1(List<string> forestSpaces, List<string> desertSpaces, List<string> waterSpaces, List<string> swampSpaces, List<string> mountainSpaces)
    {
        HashSet<string> fd = new HashSet<string>();
        fd.UnionWith(forestSpaces);
        fd.UnionWith(desertSpaces);
        HashSet<string> fw = new HashSet<string>();
        fw.UnionWith(forestSpaces);
        fw.UnionWith(waterSpaces);
        HashSet<string> fs = new HashSet<string>();
        fs.UnionWith(forestSpaces);
        fs.UnionWith(swampSpaces);
        HashSet<string> fm = new HashSet<string>();
        fm.UnionWith(forestSpaces);
        fm.UnionWith(mountainSpaces);
        HashSet<string> dw = new HashSet<string>();
        dw.UnionWith(desertSpaces);
        dw.UnionWith(waterSpaces);
        HashSet<string> ds = new HashSet<string>();
        ds.UnionWith(desertSpaces);
        ds.UnionWith(swampSpaces);
        HashSet<string> dm = new HashSet<string>();
        dm.UnionWith(desertSpaces);
        dm.UnionWith(mountainSpaces);
        HashSet<string> ws = new HashSet<string>();
        ws.UnionWith(waterSpaces);
        ws.UnionWith(swampSpaces);
        HashSet<string> wm = new HashSet<string>();
        wm.UnionWith(waterSpaces);
        wm.UnionWith(mountainSpaces);
        HashSet<string> sm = new HashSet<string>();
        sm.UnionWith(swampSpaces);
        sm.UnionWith(mountainSpaces);

        HashSet<string> noFD = new HashSet<string>();
        noFD.UnionWith(waterSpaces);
        noFD.UnionWith(swampSpaces);
        noFD.UnionWith(mountainSpaces);
        HashSet<string> noFW = new HashSet<string>();
        noFW.UnionWith(desertSpaces);
        noFW.UnionWith(swampSpaces);
        noFW.UnionWith(mountainSpaces);
        HashSet<string> noFS = new HashSet<string>();
        noFS.UnionWith(desertSpaces);
        noFS.UnionWith(waterSpaces);
        noFS.UnionWith(mountainSpaces);
        HashSet<string> noFM = new HashSet<string>();
        noFM.UnionWith(desertSpaces);
        noFM.UnionWith(waterSpaces);
        noFM.UnionWith(swampSpaces);
        HashSet<string> noDW = new HashSet<string>();
        noDW.UnionWith(forestSpaces);
        noDW.UnionWith(swampSpaces);
        noDW.UnionWith(mountainSpaces);
        HashSet<string> noDS = new HashSet<string>();
        noDS.UnionWith(forestSpaces);
        noDS.UnionWith(waterSpaces);
        noDS.UnionWith(mountainSpaces);
        HashSet<string> noDM = new HashSet<string>();
        noDM.UnionWith(forestSpaces);
        noDM.UnionWith(waterSpaces);
        noDM.UnionWith(swampSpaces);
        HashSet<string> noWS = new HashSet<string>();
        noWS.UnionWith(forestSpaces);
        noWS.UnionWith(desertSpaces);
        noWS.UnionWith(mountainSpaces);
        HashSet<string> noWM = new HashSet<string>();
        noWM.UnionWith(forestSpaces);
        noWM.UnionWith(desertSpaces);
        noWM.UnionWith(swampSpaces);
        HashSet<string> noSM = new HashSet<string>();
        noSM.UnionWith(forestSpaces);
        noSM.UnionWith(desertSpaces);
        noSM.UnionWith(waterSpaces);

        List<Rule> rules = new List<Rule>();
        rules.Add(new Rule("The habitat is on Forest or Desert", fd));
        rules.Add(new Rule("The habitat is on Forest or Water", fw));
        rules.Add(new Rule("The habitat is on Forest or Swamp", fs));
        rules.Add(new Rule("The habitat is on Forest or Mountain", fm));
        rules.Add(new Rule("The habitat is on Desert or Water", dw));
        rules.Add(new Rule("The habitat is on Desert or Swamp", ds));
        rules.Add(new Rule("The habitat is on Desert or Mountain", dm));
        rules.Add(new Rule("The habitat is on Water or Swamp", ws));
        rules.Add(new Rule("The habitat is on Water or Mountain", wm));
        rules.Add(new Rule("The habitat is on Swamp or Mountain", sm));

        rules.Add(new Rule("The habitat is NOT on Forest or Desert", noFD));
        rules.Add(new Rule("The habitat is NOT on Forest or Water", noFW));
        rules.Add(new Rule("The habitat is NOT on Forest or Swamp", noFS));
        rules.Add(new Rule("The habitat is NOT on Forest or Mountain", noFM));
        rules.Add(new Rule("The habitat is NOT on Desert or Water", noDW));
        rules.Add(new Rule("The habitat is NOT on Desert or Swamp", noDS));
        rules.Add(new Rule("The habitat is NOT on Desert or Mountain", noDM));
        rules.Add(new Rule("The habitat is NOT on Water or Swamp", noWS));
        rules.Add(new Rule("The habitat is NOT on Water or Mountain", noWM));
        rules.Add(new Rule("The habitat is NOT on Swamp or Mountain", noSM));

        return rules;
    }
    private List<Rule> generateRuleSet2(List<string> forestSpaces, List<string> desertSpaces, List<string> waterSpaces, List<string> swampSpaces, List<string> mountainSpaces, Board board, Dictionary<string, List<List<string>>> spacesWithin)
    {
        HashSet<string> f1 = new HashSet<string>();
        
        foreach(string space in forestSpaces)
        {
            f1.UnionWith(spacesWithin[space][0]);
            f1.UnionWith(spacesWithin[space][1]);
        }
        HashSet<string> d1 = new HashSet<string>();
        foreach (string space in desertSpaces)
        {
            d1.UnionWith(spacesWithin[space][0]);
            d1.UnionWith(spacesWithin[space][1]);
        }
        HashSet<string> w1 = new HashSet<string>();
        foreach (string space in waterSpaces)
        {
            w1.UnionWith(spacesWithin[space][0]);
            w1.UnionWith(spacesWithin[space][1]);
        }
        HashSet<string> s1 = new HashSet<string>();
        foreach (string space in swampSpaces)
        {
            s1.UnionWith(spacesWithin[space][0]);
            s1.UnionWith(spacesWithin[space][1]);
        }
        HashSet<string> m1 = new HashSet<string>();
        foreach (string space in mountainSpaces)
        {
            m1.UnionWith(spacesWithin[space][0]);
            m1.UnionWith(spacesWithin[space][1]);
        }
        HashSet<string> t1 = new HashSet<string>();
        foreach (BoardSpace space in board.spaces)
        {
            if(space.territory != TerritoryType.None)
            {
                t1.UnionWith(spacesWithin[space.id][0]);
                t1.UnionWith(spacesWithin[space.id][1]);
            }
        }
        HashSet<string> noF1 = new HashSet<string>();
        noF1.UnionWith(allSpaces);
        noF1.ExceptWith(f1);
        HashSet<string> noD1 = new HashSet<string>();
        noD1.UnionWith(allSpaces);
        noD1.ExceptWith(d1);
        HashSet<string> noW1 = new HashSet<string>();
        noW1.UnionWith(allSpaces);
        noW1.ExceptWith(w1);
        HashSet<string> noS1 = new HashSet<string>();
        noS1.UnionWith(allSpaces);
        noS1.ExceptWith(s1);
        HashSet<string> noM1 = new HashSet<string>();
        noM1.UnionWith(allSpaces);
        noM1.ExceptWith(m1);
        HashSet<string> noT1 = new HashSet<string>();
        noT1.UnionWith(allSpaces);
        noT1.ExceptWith(t1);

        List<Rule> rules = new List<Rule>();
        rules.Add(new Rule("The habitat is within one space of Forest", f1));
        rules.Add(new Rule("The habitat is within one space of Desert", d1));
        rules.Add(new Rule("The habitat is within one space of Water", w1));
        rules.Add(new Rule("The habitat is within one space of Swamp", s1));
        rules.Add(new Rule("The habitat is within one space of Mountain", m1));
        rules.Add(new Rule("The habitat is within one space of either Animal Territory", t1));

        rules.Add(new Rule("The habitat is NOT within one space of Forest", noF1));
        rules.Add(new Rule("The habitat is NOT within one space of Desert", noD1));
        rules.Add(new Rule("The habitat is NOT within one space of Water", noW1));
        rules.Add(new Rule("The habitat is NOT within one space of Swamp", noS1));
        rules.Add(new Rule("The habitat is NOT within one space of Mountain", noM1));
        rules.Add(new Rule("The habitat is NOT within one space of either Animal Territory", noT1));

        return rules;
    }
    private List<Rule> generateRuleSet3(Board board, Dictionary<string, List<List<string>>> spacesWithin)
    {
        List<Structure> structures = board.structures;
        HashSet<string> as2 = new HashSet<string>();
        HashSet<string> ss2 = new HashSet<string>();
        foreach (Structure structure in structures)
        {
            if(structure.type == StructureType.AbandonedShack)
            {
                for (int i = 0; i < 3; i++)
                    as2.UnionWith(spacesWithin[structure.spaceName][i]);
            }
            else
            {
                for (int i = 0; i < 3; i++)
                    ss2.UnionWith(spacesWithin[structure.spaceName][i]);
            }
        }
        HashSet<string> b2 = new HashSet<string>();
        HashSet<string> c2 = new HashSet<string>();
        foreach (BoardSpace space in board.spaces)
        {
            if (space.territory == TerritoryType.Bear)
            {
                for(int i = 0; i < 3; i++)
                    b2.UnionWith(spacesWithin[space.id][i]);
            }
            else if (space.territory == TerritoryType.Cougar)
            {
                for (int i = 0; i < 3; i++)
                    c2.UnionWith(spacesWithin[space.id][i]);
            }
        }
        
        HashSet<string> noAS2 = new HashSet<string>();
        noAS2.UnionWith(allSpaces);
        noAS2.ExceptWith(as2);
        HashSet<string> noSS2 = new HashSet<string>();
        noSS2.UnionWith(allSpaces);
        noSS2.ExceptWith(ss2);
        HashSet<string> noB2 = new HashSet<string>();
        noB2.UnionWith(allSpaces);
        noB2.ExceptWith(b2);
        HashSet<string> noC2 = new HashSet<string>();
        noC2.UnionWith(allSpaces);
        noC2.ExceptWith(c2);

        List<Rule> rules = new List<Rule>();
        rules.Add(new Rule("The habitat is within two spaces of an Abandoned Shack", as2));
        rules.Add(new Rule("The habitat is within two spaces of a Standing Stone", ss2));
        rules.Add(new Rule("The habitat is within two spaces of Bear Territory", b2));
        rules.Add(new Rule("The habitat is within two spaces of Cougar Territory", c2));

        rules.Add(new Rule("The habitat is NOT within two spaces of an Abandoned Shack", noAS2));
        rules.Add(new Rule("The habitat is NOT within two spaces of a Standing Stone", noSS2));
        rules.Add(new Rule("The habitat is NOT within two spaces of Bear Territory", noB2));
        rules.Add(new Rule("The habitat is NOT within two spaces of Cougar Territory", noC2));

        return rules;
    }
    private List<Rule> generateRuleSet4(Board board, Dictionary<string, List<List<string>>> spacesWithin)
    {
        List<Structure> structures = board.structures;
        HashSet<string> rs3 = new HashSet<string>();
        HashSet<string> bs3 = new HashSet<string>();
        HashSet<string> ys3 = new HashSet<string>();
        HashSet<string> ws3 = new HashSet<string>();
        foreach (Structure structure in structures)
        {
            switch(structure.color)
            {
                case StructureColor.Red:
                    for (int i = 0; i < 4; i++)
                        rs3.UnionWith(spacesWithin[structure.spaceName][i]);
                    break;
                case StructureColor.Yellow:
                    for (int i = 0; i < 4; i++)
                        ys3.UnionWith(spacesWithin[structure.spaceName][i]);
                    break;
                case StructureColor.Blue:
                    for (int i = 0; i < 4; i++)
                        bs3.UnionWith(spacesWithin[structure.spaceName][i]);
                    break;
                case StructureColor.White:
                    for (int i = 0; i < 4; i++)
                        ws3.UnionWith(spacesWithin[structure.spaceName][i]);
                    break;
            }
        }


        HashSet<string> noRS3 = new HashSet<string>();
        noRS3.UnionWith(allSpaces);
        noRS3.ExceptWith(rs3);
        HashSet<string> noYS3 = new HashSet<string>();
        noYS3.UnionWith(allSpaces);
        noYS3.ExceptWith(ys3);
        HashSet<string> noBS3 = new HashSet<string>();
        noBS3.UnionWith(allSpaces);
        noBS3.ExceptWith(bs3);
        HashSet<string> noWS3 = new HashSet<string>();
        noWS3.UnionWith(allSpaces);
        noWS3.ExceptWith(ws3);

        List<Rule> rules = new List<Rule>();
        rules.Add(new Rule("The habitat is within three spaces of a Red Structure", rs3));
        rules.Add(new Rule("The habitat is within three spaces of a Yellow Structure", ys3));
        rules.Add(new Rule("The habitat is within three spaces of a Blue Structure", bs3));
        rules.Add(new Rule("The habitat is within three spaces of a White Structure", ws3));

        rules.Add(new Rule("The habitat is NOT within three spaces of a Red Structure", noRS3));
        rules.Add(new Rule("The habitat is NOT within three spaces of a Yellow Structure", noYS3));
        rules.Add(new Rule("The habitat is NOT within three spaces of a Blue Structure", noBS3));
        rules.Add(new Rule("The habitat is NOT within three spaces of a White Structure", noWS3));
        return rules;
    }
    private List<string> getTerrainSpaces(Board board, SpaceType type)
    {
        List<string> spaces = new List<string>();
        foreach(BoardSpace space in board.spaces)
        {
            if (space.type == type)
                spaces.Add(space.id);
        }
        return spaces;
    }
    private bool hasRedundancy(Rule[] rules)
    {
        for(int i = 0; i < rules.Length; i++)
        {
            List<Rule> check = new List<Rule>();
            check.AddRange(rules);
            check.RemoveAt(i);
            if (canSolve(check))
                return true;
        }
        return false;
    }
    private bool canSolve(List<Rule> rules)
    {
        HashSet<string> validSpaces = new HashSet<string>(rules[0].validSpaces);
        for (int i = 1; i < rules.Count; i++)
            validSpaces.IntersectWith(rules[i].validSpaces);
        //Debug.LogFormat("{0}: {1}", validSpaces.Count, validSpaces.Join(" "));
        return (validSpaces.Count == 1);
    }
    private void initAllSpaces(Board board)
    {
        allSpaces = new List<string>();
        foreach (BoardSpace space in board.spaces)
            allSpaces.Add(space.id);
    }
}
