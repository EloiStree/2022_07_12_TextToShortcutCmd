using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShortInter_RGBCameraDemo : AbstractShortcutIntepretor
{
    public Color m_colorReceived = Color.black;
    public Eloi.ClassicUnityEvent_Color m_colorFound = new Eloi.ClassicUnityEvent_Color();
    public Camera [] m_targets= new Camera[0];

    public ShortInter_RGBCameraDemo() {

    }

    public override bool CanItUnderstand(in I_ShortcutAsTextGet shortcut)
    {
        string text = shortcut.GetText().ToLower();
        if (text.Length>4 && text[0] == 'r' && text[1] == 'g' && text[2] == 'b') {
            if (text[3] == ':') return true;
            if (text[3] == '#') return true;
        }
        return false;
    }

    public override void TryTranslate(out bool succedToTranslate, in I_ShortcutAsTextGet shortcut)
    {
        string text = shortcut.GetText();
        if (shortcut.GetTextLength() >=10 ) {
            if (text[3] == '#')
            {
                Eloi.E_StringUtility.SubstringBetween(3, 12, in text, out string textFound);
                Eloi.E_ColorUtility.ConvertHashFFFFFFFFToColor(textFound, out bool converted, out Color c);
                m_colorReceived = c;
                PushColorFound(in c);
                succedToTranslate = true;
                return;
            }
            if (text[3] == ':')
            {
                Eloi.E_StringUtility.SubstringBetween(4, 12, in text, out string textFound);
                Eloi.E_ColorUtility.ConvertHashFFFFFFFFToColor(textFound, out bool converted, out Color c);
                m_colorReceived = c;
                PushColorFound(in c);
                succedToTranslate=  true;
                return;
            }
        }
        succedToTranslate = false;
    }

    private void PushColorFound(in Color c)
    {
        m_colorFound.Invoke(c);
        for (int i = 0; i < m_targets.Length; i++)
        {
            if (m_targets[i] != null)
                m_targets[i].backgroundColor = c;
        }
    }
}
