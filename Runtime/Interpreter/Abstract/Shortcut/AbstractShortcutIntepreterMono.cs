using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_ShortcutInterpreterHolder
{
    I_ShortcutIntepreter GetInterpreter();
    bool IsInterpreterDefined();
}
public interface I_ShortcutIntepreter
{
    public void GetInterpreterDescriptionName(out string interpretorName);
    public string GetInterpreterDescriptionName();
    public void GetInterpreterUniqueID(out string uniqueId);
    public string GetInterpreterUniqueID();
    public bool CanItUnderstand(in I_ShortcutAsTextGet shortcut );
    public void TryTranslate(out bool succedToTransmit, in I_ShortcutAsTextGet shortcut);
    public bool TryTranslate( in I_ShortcutAsTextGet shortcut);
}

public abstract class AbstractShortcutIntepreterMono : MonoBehaviour, I_ShortcutInterpreterHolder, I_ShortcutIntepreter
{

    public bool CanItUnderstand(in I_ShortcutAsTextGet shortcut)
    {
        return GetInterpreter().CanItUnderstand(in shortcut);
    }
    public abstract I_ShortcutIntepreter GetInterpreter();
    public void GetInterpreterDescriptionName(out string interpretorName)
    {
        GetInterpreter().GetInterpreterDescriptionName(out interpretorName);
    }


    public void GetInterpreterUniqueID(out string uniqueId)
    {
        GetInterpreter().GetInterpreterUniqueID(out uniqueId);
    }

    public bool IsInterpreterDefined()
    {
        return GetInterpreter() != null;
    }
    public void TryTranslate(out bool succedToTransmit, in I_ShortcutAsTextGet shortcut)
    {
        GetInterpreter().TryTranslate(out succedToTransmit,in shortcut);
    }
    public bool TryTranslate(in I_ShortcutAsTextGet shortcut)
    {
        return GetInterpreter().TryTranslate(in shortcut);
    }

    public string GetInterpreterUniqueID()
    {
        GetInterpreter().GetInterpreterUniqueID(out string value);
        return value;
    }

    public string GetInterpreterDescriptionName()
    {
        GetInterpreter().GetInterpreterDescriptionName(out string value);
        return value;
    }
}
