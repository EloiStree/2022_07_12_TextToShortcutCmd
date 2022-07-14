using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutTextAuctionHouseMono : MonoBehaviour
{

    public ShortcutInterpreterLoadedRegisterMono m_register;
    public IShortcutTextEvent m_received = new IShortcutTextEvent();
    public IShortcutTextEvent m_failToExecute = new IShortcutTextEvent();
    public IShortcutTextEvent m_exceptionHappened = new IShortcutTextEvent();
    public IShortcutTextEvent m_noInterpretor = new IShortcutTextEvent();
    public IShortcutTextEvent m_translated = new IShortcutTextEvent();

    public void PushToAuction(I_ShortcutAsTextGet shortcut) {

        m_received.Invoke(shortcut);
        I_ShortcutIntepreter interpreter=null;
        List < ShortcutInterpreterPiorityEntry > sinter = m_register.GetInterpreters();
        for (int i = 0; i < sinter.Count; i++)
        {
            if (sinter[i] != null && sinter[i].IsDefined())
            {
                sinter[i].GetInterpreter(out interpreter);
                if (interpreter != null && interpreter.CanItUnderstand(shortcut)) {
                    try
                    {
                        Debug.Log("S: " + shortcut.GetText() + "  I:"+ interpreter.GetInterpreterDescriptionName());
                        if (interpreter.TryTranslate(shortcut))
                        {
                            m_translated.Invoke(shortcut);
                        }
                        else { 
                            m_failToExecute.Invoke(shortcut);
                        }
                        return;
                    }
                    catch (Exception e) {
                        Debug.Log("Exception in translation:"+ e.StackTrace);
                        m_exceptionHappened.Invoke(shortcut);
                        return;
                    }
                }
            }
        }
        m_noInterpretor.Invoke(shortcut);
    }
    public void GetAllInterpretersFor(I_ShortcutAsTextGet shortcut, out bool found, out List<I_ShortcutIntepreter> interpreters) 
    {
        I_ShortcutIntepreter interpreter = null;
        interpreters = new List<I_ShortcutIntepreter>();
        List<ShortcutInterpreterPiorityEntry> sinter = m_register.GetInterpreters();
        for (int i = 0; i < sinter.Count; i++)
        {
            if (sinter[i] != null && sinter[i].IsDefined())
            {
                sinter[i].GetInterpreter(out interpreter);
                if (interpreter != null && interpreter.CanItUnderstand(shortcut))
                {
                    interpreters.Add(interpreter);
                }
            }
        }
        found = interpreters.Count>0;
    }
    public void GetFirstInterpreterFor(I_ShortcutAsTextGet shortcut, out bool found , out I_ShortcutIntepreter interpreter)
    {

        List<ShortcutInterpreterPiorityEntry> sinter = m_register.GetInterpreters();
        for (int i = 0; i < sinter.Count; i++)
        {
            if (sinter[i] != null && sinter[i].IsDefined())
            {
                sinter[i].GetInterpreter(out interpreter);
                if (interpreter != null && interpreter.CanItUnderstand(shortcut))
                {
                    found = true;
                    return;
                }
            }
        }
        found = false;
        interpreter = null;
    }
}
