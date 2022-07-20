using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortInter_RGBCameraDemo_Mono : AbstractShortcutIntepreterMono
{
    public ShortInter_RGBCameraDemo m_interpreter;
 

    public override void GetInterpreter(out I_ShortcutIntepreter interpreter)
    {
        interpreter= m_interpreter;
    }

    public override I_Interpreter<I_ShortcutAsTextGet> GetInterpreter()
    {
        return m_interpreter;
    }
}
