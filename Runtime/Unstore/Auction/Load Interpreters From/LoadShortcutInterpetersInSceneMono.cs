using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadShortcutInterpetersInSceneMono : MonoBehaviour
{
    public ShortcutInterpreterLoadedRegisterMono m_register;
    public List<MonoShortcutInterpreterPiorityEntry> m_interpretersInScene; 
    
    public void Awake()
    {
        foreach (var item in m_interpretersInScene)
        {
            m_register.AddInterpreter(item);
        }
        m_register.RemoveDoubleThenSort();
    }
}
[System.Serializable]
public class MonoShortcutInterpreterPiorityEntry
{
    public int m_priorityPoint = 500;
    public bool m_isActive = true;
    public AbstractShortcutIntepreterMono m_shortcutInScene;

}