using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parser_TextToShortcutTextListMono : MonoBehaviour
{
    public ShortcutTextEvent m_shortcutFound;
    public ShortcutTextEnumEvent m_shortcutEnumFound;
    public void ParseAndPush(string text)
    {
        Parser_TextToShortcutTextList.ParseAndPush(text, m_shortcutFound.Invoke, m_shortcutEnumFound.Invoke);
    }
}
public class Parser_TextToShortcutTextList
{
   
    public static void Parse(in string text, out ShortcutAsText[] group)
    {
        ShortcutTextUtility.GetShortcutsFromLine(text, out group);
    }
    public static void ParseAndPush(in string text, in Action<IEnumerable<ShortcutAsText>> whereToPush)
    {
        ShortcutTextUtility.GetShortcutsFromLine(text, out ShortcutAsText[]  group);
        whereToPush.Invoke(group);


    }
    public static void ParseAndPush(in string text, in Action<ShortcutAsText> whereToPush)
    {
        ShortcutTextUtility.GetShortcutsFromLine(text, out ShortcutAsText[] group);
        foreach (var item in group)
        {
            whereToPush.Invoke(item);
        }

    }
    public static void ParseAndPush(in string text, in Action<ShortcutAsText> whereToPush, in Action<IEnumerable<ShortcutAsText>> whereToPushGroup)
    {
        ShortcutTextUtility.GetShortcutsFromLine(text, out ShortcutAsText[] group);
        foreach (var item in group)
        {
            whereToPush.Invoke(item);
        }
        whereToPushGroup.Invoke(group);
    }
}

  