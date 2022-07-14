using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ShortcutsGroupEvent : UnityEvent<ShortcutsGroup> { }
[System.Serializable]
public class ShortcutTextEvent : UnityEvent<ShortcutAsText> { }
[System.Serializable]
public class IShortcutTextEvent : UnityEvent<I_ShortcutAsTextGet> { }
[System.Serializable]
public class ShortcutTextEnumEvent : UnityEvent<IEnumerable<ShortcutAsText>> { }

