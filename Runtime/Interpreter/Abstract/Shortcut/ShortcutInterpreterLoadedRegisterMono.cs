using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ShortcutInterpreterLoadedRegisterMono : MonoBehaviour
{

    public List<ShortcutInterpreterPiorityEntry> m_interpretersUse;
    public UnityEvent m_onInterpreterAdded;

    public void RemoveDoubleThenSort()
    {
        RemoveDouble();
        SortByPriorityPoints_0Hightest();
    }

    public void RemoveDouble()
    {
        m_interpretersUse = m_interpretersUse.GroupBy(x => x.m_shortcutInScene.GetInterpreterUniqueID()).Select(y => y.First()).ToList();
    }

    public List<ShortcutInterpreterPiorityEntry> GetInterpreters() { return m_interpretersUse; }
    public void SortByPriorityPoints_0Hightest()
    {
        m_interpretersUse = m_interpretersUse.OrderBy(k=>k.m_priorityPoint).ToList();
    }

    public void AddInterpreter(int priorityPoint, bool isActivebyDefault, I_ShortcutIntepreter shortcutInScene) {
        m_interpretersUse.Add(new ShortcutInterpreterPiorityEntry(priorityPoint, isActivebyDefault, shortcutInScene));
        RemoveDoubleThenSort();
        m_onInterpreterAdded.Invoke();
    }
    public void AddInterpreter(MonoShortcutInterpreterPiorityEntry entry)
    {
        m_interpretersUse.Add(new ShortcutInterpreterPiorityEntry(entry.m_priorityPoint, entry.m_isActive, entry.m_shortcutInScene));
        RemoveDoubleThenSort();
        m_onInterpreterAdded.Invoke();
    }
}


[System.Serializable]
public class ShortcutInterpreterPiorityEntry
{

    public string m_interpretName;
    public string m_interpretID;
    public int m_priorityPoint = 500;
    public bool m_isActive = true;
    public I_ShortcutIntepreter m_shortcutInScene;
    public bool IsDefined() { return m_shortcutInScene != null; }
    public bool IsMonoInterpreter() { return m_shortcutInScene is MonoBehaviour; }
    public bool IsAbstractMonoInterpreter() { return m_shortcutInScene is AbstractShortcutIntepreterMono; }

    public void GetInterpreter(out I_ShortcutIntepreter interpreter)
    {
        interpreter = m_shortcutInScene;
    }
    public I_ShortcutIntepreter GetInterpreter()
    {
        return  m_shortcutInScene;
    }

    public ShortcutInterpreterPiorityEntry(int priorityPoint, bool isActivebyDefault, I_ShortcutIntepreter shortcutInScene)
    {
        m_priorityPoint = priorityPoint;
        m_isActive = isActivebyDefault;
        m_shortcutInScene = shortcutInScene;
        m_shortcutInScene.GetInterpreterDescriptionName(out m_interpretName);
        m_shortcutInScene.GetInterpreterUniqueID(out m_interpretID);
}
    public ShortcutInterpreterPiorityEntry( MonoShortcutInterpreterPiorityEntry shortcutInScene)
    {
        m_priorityPoint = shortcutInScene.m_priorityPoint;
        m_isActive = shortcutInScene.m_isActive;
        m_shortcutInScene = shortcutInScene.m_shortcutInScene;
        m_shortcutInScene.GetInterpreterDescriptionName(out m_interpretName);
        m_shortcutInScene.GetInterpreterUniqueID(out m_interpretID);
    }
}
