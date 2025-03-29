using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class control_rebote : MonoBehaviour
{
    public UnityEvent OnXRPointerEnter;
    public UnityEvent OnXRPointerExit;
    public Player scriptrebote;


    void Start()
    {
    }

    public void OnPointerEnterXR()
    {
        scriptrebote.enabled = false;
        OnXRPointerEnter?.Invoke();
    }

    public void OnPointerExitXR()
    {
        scriptrebote.enabled = false;
        OnXRPointerEnter?.Invoke();
    }

    public void OnPointerClickXR()
    {
        rebote();
    }

    private void rebote()
    {
        scriptrebote.enabled = true;
    }
        
}
