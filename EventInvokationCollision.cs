using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventInvokationCollision : MonoBehaviour
{
    public bool EventInvokationCollisionActive = true;

    [Header("Leave empty to detect all collisions")]
    public string ColliderTag = null;

    [Space(5)]
    public UnityEvent OnCollisionEnterEvent;
    [Space(5)]
    public UnityEvent OnCollisionStayEvent;
    [Space(5)]
    public UnityEvent OnCollisionExitEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if (!EventInvokationCollisionActive) return;

        if (string.IsNullOrEmpty(ColliderTag) || collision.collider.CompareTag(ColliderTag))
        {
            OnCollisionEnterEvent.Invoke();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!EventInvokationCollisionActive) return;

        if (string.IsNullOrEmpty(ColliderTag) || collision.collider.CompareTag(ColliderTag))
        {
            OnCollisionStayEvent.Invoke();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!EventInvokationCollisionActive) return;

        if (string.IsNullOrEmpty(ColliderTag) || collision.collider.CompareTag(ColliderTag))
        {
            OnCollisionExitEvent.Invoke();
        }
    }
}
