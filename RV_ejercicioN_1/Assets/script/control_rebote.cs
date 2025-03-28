using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class control_rebote : MonoBehaviour
{
    public Player scriptrebote;
    public UnityEvent OnXRPointerEnter;
    public UnityEvent OnXRPointerExit;
    [SerializeField] private GameObject esfere;

    void Start()
    {
        
    }

    public void OnPointerEnterXR()
    {
        OnXRPointerEnter?.Invoke();
        scriptrebote.enabled = true;
    }

    public void OnPointerExitXR()
    {
        OnXRPointerExit?.Invoke();
        scriptrebote.enabled = true;
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
