using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface I_ShortcutInterpreterHolder: I_InterpreterHolder<I_Interpreter<I_ShortcutAsTextGet>, I_ShortcutAsTextGet> { }

public interface I_ShortcutIntepreter: I_Interpreter<I_ShortcutAsTextGet>{ }

public abstract class AbstractShortcutIntepreterMono : MonoBehaviour, I_ShortcutInterpreterHolder ,I_ShortcutIntepreter
{

    public bool CanInterpreterUnderstand(in I_ShortcutAsTextGet shortcut)
    {
        return GetInterpreter().CanInterpreterUnderstand(in shortcut);
    }
    public abstract I_Interpreter<I_ShortcutAsTextGet> GetInterpreter();
    public abstract void GetInterpreter(out I_ShortcutIntepreter interpreter);
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
