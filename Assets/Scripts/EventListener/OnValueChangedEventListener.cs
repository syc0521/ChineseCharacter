using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnValueChangedEventListener<T>
{
    public delegate void OnValueChanged(T newValue);
    public event OnValueChanged OnValueChangedEvent;
    private T m_Value;
    public T Value
    {
        get
        {
            return m_Value;
        }
        set
        {
            if(m_Value.Equals(value)) return;
            OnValueChangedEvent?.Invoke(value);
            m_Value=value;
        }
    }
}
