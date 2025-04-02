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
        GazeManager.Instance.SetUpGaze(1.5f);
        OnXRPointerEnter?.Invoke();
    }

    public void OnPointerExitXR()
    {
        scriptrebote.enabled = false;
        GazeManager.Instance.SetUpGaze(2.5f);
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
