using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Experiment_TextToShortcuts : MonoBehaviour
{
    [TextArea(0,20)]
    public string m_text;
    public string [] m_lines;
    public LineToShortcutsConvertion[] m_linesAsRaw;

    public bool m_groupSensitive;
    public ShortcutsGroupEvent m_groupReceived;
    public ShortcutTextEvent m_shortcutSoloReceived;

    [ContextMenu("Refresh")]
    void Refresh()
    {
        if (m_text.Length < 2)
            m_lines = new string[] { m_text };
        else 
            m_lines = m_text.Split('\n');

        m_linesAsRaw = new LineToShortcutsConvertion[m_lines.Length];
        for (int i = 0; i < m_lines.Length; i++)
        {
            m_linesAsRaw[i] = new LineToShortcutsConvertion();
            m_linesAsRaw[i].line = m_lines[i];
            ShortcutTextUtility.GetShortcutsFromLine( in m_linesAsRaw[i].line, out m_linesAsRaw[i].m_shortcutList);
            ShortcutTextUtility.GetShortcutGroupFromLine( in m_linesAsRaw[i].line, out m_linesAsRaw[i].m_shortcutGroup);
            if (m_groupSensitive)
            {
                m_groupReceived.Invoke(m_linesAsRaw[i].m_shortcutGroup);
            }
            else {
                ShortcutTextUtility.PushInShortcutSoloEvent(m_linesAsRaw[i].m_shortcutGroup, m_shortcutSoloReceived);
            }
        }
    }
}
[System.Serializable]
public class LineToShortcutsConvertion {
    public string line;
    public ShortcutAsText[] m_shortcutList;
    public ShortcutsGroup m_shortcutGroup;
}


