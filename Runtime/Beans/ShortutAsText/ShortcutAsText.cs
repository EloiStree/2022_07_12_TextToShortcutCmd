using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface I_ShortcutAsTextGet {

    string GetText();
    void GetText(out string text);
    int GetTextLength();
    void GetTextLength(out int textLength);
}

[System.Serializable]
public class ShortcutAsText : I_ShortcutAsTextGet
{
    public string m_text;

    public ShortcutAsText(string text)
    {
        if (text == null || string.IsNullOrWhiteSpace(text))
            m_text = "";
        else
            m_text = text.Trim();
    }
    public ShortcutAsText()
    {
            m_text = "";
    }

    public string GetText()
    {
        return m_text;
    }

    public void GetText(out string text)=>
        text = m_text;
    
    public int GetTextLength()
    {
        return m_text.Length;
    }

    public void GetTextLength(out int textLength)=>
        textLength = m_text.Length;
    
}
