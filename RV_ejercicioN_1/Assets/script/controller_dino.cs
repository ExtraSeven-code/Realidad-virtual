using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class controller_dino : MonoBehaviour
{
    public UnityEvent OnXRPointerEnter;
    public UnityEvent OnXRPointerExit;

    public float moveDistance = 2f;
    public float moveSpeed = 2f;

    [SerializeField] private bool _isMoving = false;
    [SerializeField] private Animator moviendo;
    private Vector3 _targetPosition;
    private Camera xRCamera;

    void Start()
    {
        xRCamera = CameraPointerManager.instance.gameObject.GetComponent<Camera>();
        moviendo = GetComponent<Animator>();
    }

    public void OnPointerEnterXR()
    {
        OnXRPointerEnter?.Invoke();
    }

    public void OnPointerExitXR()
    {
        OnXRPointerExit?.Invoke();
    }

    public void OnPointerClickXR()
    {
        MovimientoDino();
    }

    private void MovimientoDino()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!_isMoving)
        {
            _isMoving = true;
            moviendo.SetBool("corriendo", true);
            _targetPosition = transform.position + transform.forward * moveDistance;
            StartCoroutine(MoveToTarget());
        }
    }

    private IEnumerator MoveToTarget()
    {
        float elapsedTime = 0f;
        Vector3 startPos = transform.position;

        while (elapsedTime < 1f)
        {
            transform.position = Vector3.Lerp(startPos, _targetPosition, elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }

        transform.position = _targetPosition;
        _isMoving = false;
        moviendo.SetBool("corriendo", false);
    }
}
