using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShortcutGroupSplitToShortcutsMono : MonoBehaviour
{
    public ShortcutTextEvent m_splitAsItems;
    public ShortcutTextEnumEvent m_splitAsList;

    public void PushToSplit(ShortcutsGroup group)
    {
        m_splitAsList.Invoke(group.m_shortcutList);
        foreach (var item in group.m_shortcutList)
        {
            m_splitAsItems.Invoke(item);
        }


    }

}
