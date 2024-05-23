using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


//https://www.youtube.com/watch?v=vGZlTfZIfRo
public class AnimateHandController : MonoBehaviour
{
    public InputActionReference gripAction;
    public InputActionReference triggerAction;
    public GameObject rightHandRayInteractor;

    private Animator animator;
    private float gripValue;
    private float triggerValue;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        grip();
        trigger();
    }
    void grip()
    {
        gripValue = gripAction.action.ReadValue<float>();
        if (gripValue > 0f && rightHandRayInteractor != null)
        {
            rightHandRayInteractor.SetActive(true);
        }
        if (gripValue < 1f && rightHandRayInteractor != null)
        {
            rightHandRayInteractor.SetActive(false);
        }
        animator.SetFloat("Grip", gripValue);
    }
    void trigger()
    {
        triggerValue= triggerAction.action.ReadValue<float>();
        animator.SetFloat("Trigger", triggerValue);
    }
}
