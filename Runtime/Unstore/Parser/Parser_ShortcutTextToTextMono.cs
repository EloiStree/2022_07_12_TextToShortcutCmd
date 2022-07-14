using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parser_ShortcutTextToTextMono : MonoBehaviour
{
    public Eloi.PrimitiveUnityEvent_String m_textPushed;
    public void Push ( I_ShortcutAsTextGet shortcut)
    {
        m_textPushed.Invoke(shortcut.GetText());
    }
}
