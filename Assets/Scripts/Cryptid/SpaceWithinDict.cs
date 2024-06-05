using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceWithinDict 
{
    public readonly Dictionary<string, List<List<string>>> spacesWithin;
    public SpaceWithinDict()
    {
        Dictionary<string, string[]> map = new Dictionary<string, string[]>();
        map.Add("A1", new string[] { "A2", "B1" });
        map.Add("B1", new string[] { "A1", "A2", "B1", "C1", "C2" });
        map.Add("C1", new string[] { "B1", "C2", "D1" });
        map.Add("D1", new string[] { "C1", "C2", "D2", "E1", "E2" });
        map.Add("E1", new string[] { "D1", "E2", "F1" });
        map.Add("F1", new string[] { "E1", "E2", "F2", "G1", "G2" });
        map.Add("G1", new string[] { "F1", "G2", "H1" });
        map.Add("H1", new string[] { "G1", "G2", "H2", "I1", "I2" });
        map.Add("I1", new string[] { "H1", "I2", "J1" });
        map.Add("J1", new string[] { "I1", "I2", "J2", "K1", "K2" });
        map.Add("K1", new string[] { "J1", "K2", "L1" });
        map.Add("L1", new string[] { "K1", "K2", "L2" });

        map.Add("A2", new string[] { "A1", "A3", "B1", "B2" });
        map.Add("B2", new string[] { "A2", "A3", "B1", "B3", "C2", "C3" });
        map.Add("C2", new string[] { "B1", "B2", "C1", "C3", "D1", "D2" });
        map.Add("D2", new string[] { "C2", "C3", "D1", "D3", "E2", "E3" });
        map.Add("E2", new string[] { "D1", "D2", "E1", "E3", "F1", "F2" });
        map.Add("F2", new string[] { "E2", "E3", "F1", "F3", "G2", "G3" });
        map.Add("G2", new string[] { "F1", "F2", "G1", "G3", "H1", "H2" });
        map.Add("H2", new string[] { "G2", "G3", "H1", "H3", "I2", "I3" });
        map.Add("I2", new string[] { "H1", "H2", "I1", "I3", "J1", "J2" });
        map.Add("J2", new string[] { "I2", "I3", "J1", "J3", "K2", "K3" });
        map.Add("K2", new string[] { "J1", "J2", "K1", "K3", "L1", "L2" });
        map.Add("L2", new string[] { "K2", "K3", "L1", "L3" });

        map.Add("A3", new string[] { "A2", "A4", "B2", "B3" });
        map.Add("B3", new string[] { "A3", "A4", "B2", "B4", "C3", "C4" });
        map.Add("C3", new string[] { "B2", "B3", "C2", "C4", "D2", "D3" });
        map.Add("D3", new string[] { "C3", "C4", "D2", "D4", "E3", "E4" });
        map.Add("E3", new string[] { "D2", "D3", "E2", "E4", "F2", "F3" });
        map.Add("F3", new string[] { "E3", "E4", "F2", "F4", "G3", "G4" });
        map.Add("G3", new string[] { "F2", "F3", "G2", "G4", "H2", "H3" });
        map.Add("H3", new string[] { "G3", "G4", "H2", "H4", "I3", "I4" });
        map.Add("I3", new string[] { "H2", "H3", "I2", "I4", "J2", "J3" });
        map.Add("J3", new string[] { "I3", "I4", "J2", "J4", "K3", "K4" });
        map.Add("K3", new string[] { "J2", "J3", "K2", "K4", "L2", "L3" });
        map.Add("L3", new string[] { "K3", "K4", "L2", "L4" });

        map.Add("A4", new string[] { "A3", "A5", "B3", "B4" });
        map.Add("B4", new string[] { "A4", "A5", "B3", "B5", "C4", "C5" });
        map.Add("C4", new string[] { "B3", "B4", "C3", "C5", "D3", "D4" });
        map.Add("D4", new string[] { "C4", "C5", "D3", "D5", "E4", "E5" });
        map.Add("E4", new string[] { "D3", "D4", "E3", "E5", "F3", "F4" });
        map.Add("F4", new string[] { "E4", "E5", "F3", "F5", "G4", "G5" });
        map.Add("G4", new string[] { "F3", "F4", "G3", "G5", "H3", "H4" });
        map.Add("H4", new string[] { "G4", "G5", "H3", "H5", "I4", "I5" });
        map.Add("I4", new string[] { "H3", "H4", "I3", "I5", "J3", "J4" });
        map.Add("J4", new string[] { "I4", "I5", "J3", "J5", "K4", "K5" });
        map.Add("K4", new string[] { "J3", "J4", "K3", "K5", "L3", "L4" });
        map.Add("L4", new string[] { "K4", "K5", "L3", "L5" });

        map.Add("A5", new string[] { "A4", "A6", "B4", "B5" });
        map.Add("B5", new string[] { "A5", "A6", "B4", "B6", "C5", "C6" });
        map.Add("C5", new string[] { "B4", "B5", "C4", "C6", "D4", "D5" });
        map.Add("D5", new string[] { "C5", "C6", "D4", "D6", "E5", "E6" });
        map.Add("E5", new string[] { "D4", "D5", "E4", "E6", "F4", "F5" });
        map.Add("F5", new string[] { "E5", "E6", "F4", "F6", "G5", "G6" });
        map.Add("G5", new string[] { "F4", "F5", "G4", "G6", "H4", "H5" });
        map.Add("H5", new string[] { "G5", "G6", "H4", "H6", "I5", "I6" });
        map.Add("I5", new string[] { "H4", "H5", "I4", "I6", "J4", "J5" });
        map.Add("J5", new string[] { "I5", "I6", "J4", "J6", "K5", "K6" });
        map.Add("K5", new string[] { "J4", "J5", "K4", "K6", "L4", "L5" });
        map.Add("L5", new string[] { "K5", "K6", "L4", "L6" });

        map.Add("A6", new string[] { "A5", "A7", "B5", "B6" });
        map.Add("B6", new string[] { "A6", "A7", "B5", "B7", "C6", "C7" });
        map.Add("C6", new string[] { "B5", "B6", "C5", "C7", "D5", "D6" });
        map.Add("D6", new string[] { "C6", "C7", "D5", "D7", "E6", "E7" });
        map.Add("E6", new string[] { "D5", "D6", "E5", "E7", "F5", "F6" });
        map.Add("F6", new string[] { "E6", "E7", "F5", "F7", "G6", "G7" });
        map.Add("G6", new string[] { "F5", "F6", "G5", "G7", "H5", "H6" });
        map.Add("H6", new string[] { "G6", "G7", "H5", "H7", "I6", "I7" });
        map.Add("I6", new string[] { "H5", "H6", "I5", "I7", "J5", "J6" });
        map.Add("J6", new string[] { "I6", "I7", "J5", "J7", "K6", "K7" });
        map.Add("K6", new string[] { "J5", "J6", "K5", "K7", "L5", "L6" });
        map.Add("L6", new string[] { "K6", "K7", "L5", "L7" });

        map.Add("A7", new string[] { "A6", "A8", "B6", "B7" });
        map.Add("B7", new string[] { "A7", "A8", "B6", "B8", "C7", "C8" });
        map.Add("C7", new string[] { "B6", "B7", "C6", "C8", "D6", "D7" });
        map.Add("D7", new string[] { "C7", "C8", "D6", "D8", "E7", "E8" });
        map.Add("E7", new string[] { "D6", "D7", "E6", "E8", "F6", "F7" });
        map.Add("F7", new string[] { "E7", "E8", "F6", "F8", "G7", "G8" });
        map.Add("G7", new string[] { "F6", "F7", "G6", "G8", "H6", "H7" });
        map.Add("H7", new string[] { "G7", "G8", "H6", "H8", "I7", "I8" });
        map.Add("I7", new string[] { "H6", "H7", "I6", "I8", "J6", "J7" });
        map.Add("J7", new string[] { "I7", "I8", "J6", "J8", "K7", "K8" });
        map.Add("K7", new string[] { "J6", "J7", "K6", "K8", "L6", "L7" });
        map.Add("L7", new string[] { "K7", "K8", "L6", "L8" });

        map.Add("A8", new string[] { "A7", "A9", "B7", "B8" });
        map.Add("B8", new string[] { "A8", "A9", "B7", "B9", "C8", "C9" });
        map.Add("C8", new string[] { "B7", "B8", "C7", "C9", "D7", "D8" });
        map.Add("D8", new string[] { "C8", "C9", "D7", "D9", "E8", "E9" });
        map.Add("E8", new string[] { "D7", "D8", "E7", "E9", "F7", "F8" });
        map.Add("F8", new string[] { "E8", "E9", "F7", "F9", "G8", "G9" });
        map.Add("G8", new string[] { "F7", "F8", "G7", "G9", "H7", "H8" });
        map.Add("H8", new string[] { "G8", "G9", "H7", "H9", "I8", "I9" });
        map.Add("I8", new string[] { "H7", "H8", "I7", "I9", "J7", "J8" });
        map.Add("J8", new string[] { "I8", "I9", "J7", "J9", "K8", "K9" });
        map.Add("K8", new string[] { "J7", "J8", "K7", "K9", "L7", "L8" });
        map.Add("L8", new string[] { "K8", "K9", "L7", "L9" });

        map.Add("A9", new string[] { "A8", "B8", "B9" });
        map.Add("B9", new string[] { "A9", "B8", "C9" });
        map.Add("C9", new string[] { "B8", "B9", "C8", "D8", "D9" });
        map.Add("D9", new string[] { "C9", "D8", "E9" });
        map.Add("E9", new string[] { "D8", "D9", "E8", "F8", "F9" });
        map.Add("F9", new string[] { "E9", "F8", "G9" });
        map.Add("G9", new string[] { "F8", "F9", "G8", "H8", "H9" });
        map.Add("H9", new string[] { "G9", "H8", "I9" });
        map.Add("I9", new string[] { "H8", "H9", "I8", "J8", "J9" });
        map.Add("J9", new string[] { "I9", "J8", "K9" });
        map.Add("K9", new string[] { "J8", "J9", "K8", "L8", "L9" });
        map.Add("L9", new string[] { "K9", "L8" });

        spacesWithin = new Dictionary<string, List<List<string>>>();
        foreach (KeyValuePair<string, string[]> entry in map)
        {
            List<List<string>> spaces = new List<List<string>>();
            for(int i = 0; i < 4; i++)
                spaces.Add(getSpaces(map, entry.Key, i));
            spacesWithin.Add(entry.Key, spaces);
        }
        
        foreach (List<string> row in spacesWithin["I2"])
        {
            Debug.LogFormat("{0}", string.Join(" ", row.ToArray()));
        }
        
    }
    private List<string> getSpaces(Dictionary<string, string[]> map, string space, int away)
    {
        List<string> spacesVisted = new List<string>();
        List<string> currSpaces = new List<string>();
        currSpaces.Add(space);
        spacesVisted.Add(space);
        for (int i = 0; i < away; i++)
        {
            List<string> newSpaces = new List<string>();
            foreach(string sp in currSpaces)
            {
                string[] nextSpaces = map[sp];
                foreach(string ns in nextSpaces)
                {
                    if(!spacesVisted.Contains(ns))
                    {
                        newSpaces.Add(ns);
                        spacesVisted.Add(ns);
                    }
                }
            }
            currSpaces = newSpaces;
        }
        return currSpaces;
    }
}
