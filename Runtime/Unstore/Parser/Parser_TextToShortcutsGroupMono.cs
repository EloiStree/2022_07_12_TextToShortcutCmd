using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parser_TextToShortcutsGroupMono : MonoBehaviour
{

    public ShortcutsGroupEvent m_linesFound;
    public void ParseAndPush(string text) => Parser_TextToShortcutsGroup
        .ParseAndPush(in text, m_linesFound.Invoke);
}
public class Parser_TextToShortcutsGroup
{
    public static void Parse(in string text, out ShortcutsGroup[] group)
    {
        ShortcutTextUtility.GetShortcutGroupsFromText(text, out group);
    }
    public static void ParseAndPush(in string text, in Action<ShortcutsGroup> whereToPush)
    {
        ShortcutTextUtility.GetShortcutGroupsFromText(text, out ShortcutsGroup[] group);
        foreach (var line in group)
        {
            whereToPush.Invoke(line);
        }

    }
}

