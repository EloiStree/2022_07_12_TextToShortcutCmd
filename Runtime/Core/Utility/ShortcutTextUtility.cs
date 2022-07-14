using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ShortcutTextUtility
{

    public static void PushInShortcutSoloEvent(in IEnumerable<ShortcutAsText> shortcuts, in ShortcutTextEvent eventPusher)
    {
        foreach (var item in shortcuts) eventPusher.Invoke(item);
    }
    public static void PushInShortcutSoloEvent(in ShortcutsGroup group, in ShortcutTextEvent eventPusher)
    {
        foreach (var item in group.m_shortcutList) eventPusher.Invoke(item);
    }
    public static void GetShortcutsFromLine(in string textAsLine, out ShortcutAsText[] shortcuts)
    {
        string[] tokens = textAsLine.Split(' ').Where(k => !string.IsNullOrWhiteSpace(k)).ToArray();
        GetFromTokens(tokens, out shortcuts);

    }
    public static void GetShortcutGroupsFromText(in string text, out ShortcutsGroup[] shortcutsGroup)
    {
        string[] tokens = text.Split('\n').Where(k => !string.IsNullOrWhiteSpace(k)).ToArray();
        shortcutsGroup = new ShortcutsGroup[tokens.Length];
        for (int i = 0; i < tokens.Length; i++)
        {
            GetShortcutGroupFromLine(in tokens[i], out shortcutsGroup[i]);
        }

    }
    public static void GetShortcutGroupFromLine(in string textAsLine, out ShortcutsGroup shortcutsGroup)
    {
        GetFromLine(textAsLine, out ShortcutAsText[] found, ' ');
        shortcutsGroup = new ShortcutsGroup(found);
    }

    public static void GetFromTokens(string[] tokens, out ShortcutAsText[] shortcutList)
    {
        if (tokens.Length == 0)
        {
            shortcutList = new ShortcutAsText[0];
        }
        else
        {
            shortcutList = tokens.Select(k => new ShortcutAsText(k)).ToArray();
        }
    }
    public static void GetFromLine(string text, out ShortcutAsText[] shortcutList, char spliter = ' ')
    {
        GetFromTokens(text.Split(spliter), out shortcutList);
    }
    public static void GetFromTokensRemoveEmpty(string[] tokens, out ShortcutAsText[] shortcutList)
    {
        if (tokens.Length == 0)
        {
            shortcutList = new ShortcutAsText[0];
        }
        else
        {
            shortcutList = tokens.Where(k => !string.IsNullOrWhiteSpace(k.Trim())).Select(k => new ShortcutAsText(k)).ToArray();
        }
    }
    public static void GetFromLineRemoveEmpty(string text, out ShortcutAsText[] shortcutList, char spliter)
    {
        GetFromTokensRemoveEmpty(text.Split(spliter).Where(k => !string.IsNullOrWhiteSpace(k.Trim())).ToArray(), out shortcutList);
    }

}