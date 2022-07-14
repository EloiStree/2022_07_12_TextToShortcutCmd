using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractShortcutIntepretor : I_ShortcutIntepreter
{

    public string m_interpreterId = Guid.NewGuid().ToString();
    public string m_interpreterName = "Unnamed Interperter ";


    [ContextMenu("Generate new id")]
    public void GenerateNewId() { m_interpreterId = Guid.NewGuid().ToString(); }
    public void GetInterpreterDescriptionName(out string interpreterName) => interpreterName = m_interpreterName;
    public void GetInterpreterUniqueID(out string uniqueId) => uniqueId = m_interpreterId;

    public bool TryTranslate(in I_ShortcutAsTextGet shortcut)
    {
        TryTranslate(out bool result, in shortcut);
        return result;
    }
    public abstract bool CanItUnderstand(in I_ShortcutAsTextGet shortcut);
    public abstract void TryTranslate(out bool succedToTranslate, in I_ShortcutAsTextGet shortcut);

    public string GetInterpreterDescriptionName()
    {
        return m_interpreterName;
    }

    public string GetInterpreterUniqueID()
    {
        return m_interpreterId;
    }
}
