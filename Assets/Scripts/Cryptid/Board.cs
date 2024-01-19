using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board  
{
    public readonly string id;
    public readonly BoardSpace[] spaces;
    public readonly List<Structure> structures;
    public Board()
    {
        string cols = "ABCDEFGHIJKL";
        MapTile[] tiles = { new MapTile1(), new MapTile2(), new MapTile3(), new MapTile4(), new MapTile5(), new MapTile6() };
        tiles.Shuffle();
        spaces = new BoardSpace[108];
        id = "";
        List<string> spaceIDs = new List<string>();
        structures = new List<Structure>();
        for (int i = 0; i < tiles.Length; i++)
        {
            
            int startCol = (i % 2) * 6, startRow = (i / 2) * 3;
            BoardTile[] bt = tiles[i].spaces;
            switch(tiles[i].id)
            {
                case 1:
                    id += "001";
                    break;
                case 2:
                    id += "010";
                    break;
                case 3:
                    id += "011";
                    break;
                case 4:
                    id += "100";
                    break;
                case 5:
                    id += "101";
                    break;
                case 6:
                    id += "110";
                    break;
            }
            id += Random.Range(0, 2);
            if (id[id.Length - 1] == '0')
            {
                for (int j = 0; j < bt.Length; j++)
                {
                    int col = startCol + (j % 6);
                    int row = startRow + (j / 6);
                    spaces[(row * 12) + col] = new BoardSpace(cols[col] + "" + (row + 1), bt[j].type, bt[j].territory);
                    spaceIDs.Add(spaces[(row * 12) + col].id);
                }
            }
            else
            {
                for (int j = 0; j < bt.Length; j++)
                {
                    int col = startCol + (j % 6);
                    int row = startRow + (j / 6);
                    spaces[(row * 12) + col] = new BoardSpace(cols[col] + "" + (row + 1), bt[bt.Length - j - 1].type, bt[bt.Length - j - 1].territory);
                    spaceIDs.Add(spaces[(row * 12) + col].id);
                }
            }
        }
        id = binToHex(id);
        spaceIDs.Shuffle();
        structures.Add(new Structure(StructureType.AbandonedShack, StructureColor.Red, spaceIDs[0]));
        structures.Add(new Structure(StructureType.StandingStone, StructureColor.Red, spaceIDs[1]));
        structures.Add(new Structure(StructureType.AbandonedShack, StructureColor.Yellow, spaceIDs[2]));
        structures.Add(new Structure(StructureType.StandingStone, StructureColor.Yellow, spaceIDs[3]));
        structures.Add(new Structure(StructureType.AbandonedShack, StructureColor.Blue, spaceIDs[4]));
        structures.Add(new Structure(StructureType.StandingStone, StructureColor.Blue, spaceIDs[5]));
        structures.Add(new Structure(StructureType.AbandonedShack, StructureColor.White, spaceIDs[6]));
        structures.Add(new Structure(StructureType.StandingStone, StructureColor.White, spaceIDs[7]));
        foreach (Structure structure in structures)
            id += structure.spaceName;
        
    }
    private string binToHex(string bin)
    {
        string hex = "";
        for(int i = 0; i < bin.Length; i+=4)
        {
            switch(bin.Substring(i, 4))
            {
                case "0000":
                    hex += "0";
                    break;
                case "0001":
                    hex += "1";
                    break;
                case "0010":
                    hex += "2";
                    break;
                case "0011":
                    hex += "3";
                    break;
                case "0100":
                    hex += "4";
                    break;
                case "0101":
                    hex += "5";
                    break;
                case "0110":
                    hex += "6";
                    break;
                case "0111":
                    hex += "7";
                    break;
                case "1000":
                    hex += "8";
                    break;
                case "1001":
                    hex += "9";
                    break;
                case "1010":
                    hex += "A";
                    break;
                case "1011":
                    hex += "B";
                    break;
                case "1100":
                    hex += "C";
                    break;
                case "1101":
                    hex += "D";
                    break;
                case "1110":
                    hex += "E";
                    break;
                case "1111":
                    hex += "F";
                    break;
            }
        }
        return hex;
    }
}
