using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;
using Rnd = UnityEngine.Random;

public class Cryptid : MonoBehaviour
{

    string ModuleName = "Cryptid";

    public KMBombModule module;
    public KMAudio Audio;

    static int ModuleIdCounter = 1;
    int ModuleId;

    int numRules;
    string solution;
    int letterCur = 0;
    int numberCur = 0;
    static Dictionary<string, List<List<string>>> spacesWithin;
    Rule[] rules;
    List<string> submitSpaces;
    Dictionary<string, string> queryResults;

    public KMSelectable letterUp;
    public KMSelectable letterDown;
    public KMSelectable numberUp;
    public KMSelectable numberDown;
    public KMSelectable query;
    public KMSelectable submit;
    public TextMesh mapSeedText;
    public TextMesh letterText;
    public TextMesh numberText;
    public MeshRenderer[] ruleMeshes;
    public Material[] ruleMats;
    public TextMesh[] ruleTexts;

    public AudioClip coordinateSFX;
    public AudioClip querySFX;
    public AudioClip solveSFX;
    void Awake()
    {
        ModuleId = ModuleIdCounter++;
        numRules = Rnd.Range(0, 3) + 3;
        generatePuzzle();
    }
    void generatePuzzle()
    {
    tryagain:
        Board board = new Board();
        if (spacesWithin == null)
        {
            SpaceWithinDict swd = new SpaceWithinDict();
            spacesWithin = swd.spacesWithin;
        }
        RuleGenerator rg = new RuleGenerator(board, spacesWithin, numRules);
        rules = rg.rules;
        if (rules == null)
            goto tryagain;
        Debug.LogFormat("[{0} #{1}] Map Seed: {2}", ModuleName, ModuleId, board.id);
        foreach (Rule rule in rules)
            Debug.LogFormat("[{0} #{1}] {2}", ModuleName, ModuleId, rule.toString());
        solution = rg.solution;
        Debug.LogFormat("[{0} #{1}] Solution: {2}", ModuleName, ModuleId, solution);
        //Generate 9 random spaces to be added to the solution
        submitSpaces = rg.generateSubmitSpaces();
        Debug.LogFormat("[{0} #{1}] Submit Spaces: {2} {3} {4} {5} {6} {7} {8} {9} {10} {11}", ModuleName, ModuleId, submitSpaces[0], submitSpaces[1], submitSpaces[2], submitSpaces[3], submitSpaces[4], submitSpaces[5], submitSpaces[6], submitSpaces[7], submitSpaces[8], submitSpaces[9]);

        mapSeedText.text = board.id.Substring(0, 11) + "\n" + board.id.Substring(11);
        for (int i = rules.Length; i < ruleMeshes.Length; i++)
            ruleMeshes[i].transform.localScale = new Vector3(0f, 0f, 0f);
        letterUp.OnInteract += delegate () { Audio.PlaySoundAtTransform(coordinateSFX.name, transform); letterCur = mod(letterCur + 1, 12); displayCoordinate(); return false; };
        letterDown.OnInteract += delegate () { Audio.PlaySoundAtTransform(coordinateSFX.name, transform); letterCur = mod(letterCur - 1, 12); displayCoordinate(); return false; };
        numberUp.OnInteract += delegate () { Audio.PlaySoundAtTransform(coordinateSFX.name, transform); numberCur = mod(numberCur + 1, 9); displayCoordinate(); return false; };
        numberDown.OnInteract += delegate () { Audio.PlaySoundAtTransform(coordinateSFX.name, transform); numberCur = mod(numberCur - 1, 9); displayCoordinate(); return false; };
        query.OnInteract += delegate () { pressedQuery(); return false; };
        submit.OnInteract += delegate () { pressedSubmit(); return false; };
        queryResults = new Dictionary<string, string>();
        displayCoordinate();
    }
    void displayCoordinate()
    {
        letterText.text = "ABCDEFGHIJKL"[letterCur] + "";
        numberText.text = (numberCur + 1) + "";
        string coord = letterText.text + numberText.text;
        if (submitSpaces.Contains(coord))
        {
            for (int i = 0; i < numRules; i++)
            {
                ruleMeshes[i].material = ruleMats[ruleMats.Length - 1];
                ruleTexts[i].text = "";
            }
        }
        else
        {
            for (int i = 0; i < numRules; i++)
                ruleMeshes[i].material = ruleMats[i];
            if (queryResults.ContainsKey(coord))
            {
                for (int i = 0; i < numRules; i++)
                    ruleTexts[i].text = queryResults[coord][i] + "";
            }
            else
            {
                foreach (TextMesh rt in ruleTexts)
                    rt.text = "";
            }
        }
    }
    void pressedSubmit()
    {
        string coord = letterText.text + numberText.text;
        if (submitSpaces.Contains(coord))
        {
            Debug.LogFormat("[{0} #{1}] User submitted {2}", ModuleName, ModuleId, coord);
            if (coord.Equals(solution))
                Solve();
            else
                Strike();
        }
    }
    void pressedQuery()
    {
        string coord = letterText.text + numberText.text;
        if (!submitSpaces.Contains(coord))
        {
            if (!queryResults.ContainsKey(coord))
                displayQuery(coord);
        }
    }
    void displayQuery(string coord)
    {
        string result = "";
        foreach (Rule rule in rules)
            result += rule.validSpaces.Contains(coord) ? "O" : "X";
        Debug.LogFormat("[{0} #{1}] Query result for {2}: {3}", ModuleName, ModuleId, coord, result);
        queryResults.Add(coord, result);
        Audio.PlaySoundAtTransform(querySFX.name, transform);
        displayCoordinate();
    }
    void Solve()
    {
        Audio.PlaySoundAtTransform(solveSFX.name, transform);
        letterUp.OnInteract = null;
        letterDown.OnInteract = null;
        numberUp.OnInteract = null;
        numberDown.OnInteract = null;
        submit.OnInteract = null;
        query.OnInteract = null;
        letterText.text = "";
        numberText.text = "";
        mapSeedText.text = "";
        module.HandlePass();
    }

    void Strike()
    {
        Debug.LogFormat("[{0} #{1}] That was the wrong space! Time to reveal which rule(s) wasn't satisfied!", ModuleName, ModuleId);
        module.HandleStrike();
        string coord = letterText.text + numberText.text;
        submitSpaces.Remove(coord);
        displayQuery(coord);
    }

    
    int mod(int n, int m)
    {
        while (n < 0)
            n += m;
        return (n % m);
    }

    bool TPautosolve = false;
#pragma warning disable 414
    private readonly string TwitchHelpMessage = @"!{0} (C)ycle will cycle through all the coordinates. !{0} (Q)uery F3 will query the F3 space. !{0} (S)ubmit G7 will submit the G7 space.";
#pragma warning restore 414

    IEnumerator ProcessTwitchCommand(string command)
    {
        if(!TPautosolve)
        {
            string[] param = command.ToUpper().Split(' ');
            if ((Regex.IsMatch(param[0], @"^\s*CYCLE\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant) || Regex.IsMatch(param[0], @"^\s*C\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)) && param.Length == 1)
            {
                yield return null;
                while (letterText.text[0] != 'A')
                {
                    letterUp.OnInteract();
                    yield return new WaitForSeconds(0.1f);
                }
                while (numberText.text[0] != '1')
                {
                    numberUp.OnInteract();
                    yield return new WaitForSeconds(0.1f);
                }
                yield return new WaitForSeconds(1f);
                for (int i = 0; i < 12; i++)
                {
                    for(int j = 0; j < 9; j++)
                    {
                        yield return "trycancel Cycling has been cancelled due to a cancel request.";
                        numberUp.OnInteract();
                        yield return new WaitForSeconds(1f);
                    }
                    yield return "trycancel Cycling has been cancelled due to a cancel request.";
                    letterUp.OnInteract();
                    yield return new WaitForSeconds(1f);
                }
            }
            else if ((Regex.IsMatch(param[0], @"^\s*QUERY\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant) || Regex.IsMatch(param[0], @"^\s*Q\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)) && param.Length == 2 && isValidSpace(param[1]))
            {
                yield return null;
                while(letterText.text[0] != param[1][0])
                {
                    letterUp.OnInteract();
                    yield return new WaitForSeconds(0.1f);
                }
                while (numberText.text[0] != param[1][1])
                {
                    numberUp.OnInteract();
                    yield return new WaitForSeconds(0.1f);
                }
                query.OnInteract();
            }
            else if ((Regex.IsMatch(param[0], @"^\s*SUBMIT\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant) || Regex.IsMatch(param[0], @"^\s*S\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)) && param.Length == 2 && isValidSpace(param[1]))
            {
                yield return null;
                while (letterText.text[0] != param[1][0])
                {
                    letterUp.OnInteract();
                    yield return new WaitForSeconds(0.1f);
                }
                while (numberText.text[0] != param[1][1])
                {
                    numberUp.OnInteract();
                    yield return new WaitForSeconds(0.1f);
                }
                submit.OnInteract();
            }
            else
                yield return "sendtochat An error occured because the user inputted something wrong.";
        }
        else
            yield return "sendtochat Module is being solved at the moment.";
        yield return null;
    }
    bool isValidSpace(string input)
    {
        if(input.Length == 2)
            return "ABCDEFGHIJKL".Contains(input[0]) && "123456789".Contains(input[1]);
        return false;
    }

    IEnumerator TwitchHandleForcedSolve()
    {
        TPautosolve = true;
        yield return null;
        while (letterText.text[0] != solution[0])
        {
            letterUp.OnInteract();
            yield return new WaitForSeconds(0.1f);
        }
        while (numberText.text[0] != solution[1])
        {
            numberUp.OnInteract();
            yield return new WaitForSeconds(0.1f);
        }
        submit.OnInteract();
    }

}
