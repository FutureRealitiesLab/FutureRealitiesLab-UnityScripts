using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerColliderEvents : MonoBehaviour
{
    [Header("Settings")]
    public bool useTrigger = true; // Switch between Trigger (default) and Collision detection
    public bool eventActive = true;

    [Header("Tag Filter (Leave empty to detect all)")]
    public string filterTag = null;

    [Space(10)]
    public UnityEvent OnEnterEvent;
    [Space(5)]
    public UnityEvent OnStayEvent;
    [Space(5)]
    public UnityEvent OnExitEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (useTrigger && eventActive && IsTagValid(other.tag))
        {
            OnEnterEvent.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (useTrigger && eventActive && IsTagValid(other.tag))
        {
            OnStayEvent.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (useTrigger && eventActive && IsTagValid(other.tag))
        {
            OnExitEvent.Invoke();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!useTrigger && eventActive && IsTagValid(collision.collider.tag))
        {
            OnEnterEvent.Invoke();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!useTrigger && eventActive && IsTagValid(collision.collider.tag))
        {
            OnStayEvent.Invoke();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!useTrigger && eventActive && IsTagValid(collision.collider.tag))
        {
            OnExitEvent.Invoke();
        }
    }

    // Helper method to validate the tag
    private bool IsTagValid(string otherTag)
    {
        return string.IsNullOrEmpty(filterTag) || otherTag == filterTag;
    }
}
