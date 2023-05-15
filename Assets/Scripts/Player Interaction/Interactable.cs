using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    public List<InteractOption> interactOptions;

    public void Interact(InteractOption interactOption)
    {
        foreach (UnityEvent unityEvent in interactOption.unityEvents)
        {
            unityEvent.Invoke();
        }   
    }
}

[System.Serializable] public class InteractOption
{
    public string interactingTextShown;
    public UnityEvent[] unityEvents;

    public InteractOption(string interactingTextShown , UnityEvent unityEvent, bool isSelected)
    {
        this.interactingTextShown = interactingTextShown;
    }
};