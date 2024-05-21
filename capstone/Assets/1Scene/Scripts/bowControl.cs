using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class bowControl : MonoBehaviour
{
    public InputActionReference leftGrabAction;
    public GameObject leftController;
    public GameObject arrowPrefab;//화살 프리팹
    public GameObject bowPoint;//화살 생성 위치
    public GameObject arrowPoint;//발사된 화살의 부모로 삼을 오브젝트, GameManager에서 사용됨
    public grabPoint grabpoint;
    public DynamicMoveProvider dynamicMoveProvider;

    private bool isGrabbing = false;
    public bool haveArrow = false;
    private GameObject arrow;

    public bool player = true;

    
    void OnEnable()
    {
        leftGrabAction.action.performed += GrabPerformed;
        leftGrabAction.action.canceled += GrabCanceled;
        leftGrabAction.action.Enable();
    }

    
    void OnDisable()
    {
        leftGrabAction.action.performed -= GrabPerformed;
        leftGrabAction.action.Disable();
    }

    //왼쪽 컨트롤러 Grab 시 동작
    void GrabPerformed(InputAction.CallbackContext context)
    {
        isGrabbing = true;
        if (dynamicMoveProvider != null)
        {
            dynamicMoveProvider.enabled = false;
        }
        //RemoveControllerModel();
    }

    //왼쪽 컨트롤러 Grab 해제 시 동작
    void GrabCanceled(InputAction.CallbackContext context)
    {
        isGrabbing = false;
        if (dynamicMoveProvider != null)
        {
            dynamicMoveProvider.enabled = true;
        }
        //RestoreControllerModel();
    }

    //활을 컨트롤러 위치로 설정
    void MoveBowToControllerPosition()
    {
        this.transform.position = leftController.transform.position;
        this.transform.rotation = leftController.transform.rotation;
    }

    void RemoveControllerModel()
    {
        Renderer[] renderers = leftController.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = false;
        }
    }
    void RestoreControllerModel()
    {
        Renderer[] renderers = leftController.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = true;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbing && player)
        {
            MoveBowToControllerPosition();
        }
        /*if (!haveArrow)
        {
            Invoke("reloadArrow", 2f);
            haveArrow = true;
        }*/
        
    }

    //재장전
    public void reloadArrow()
    {
        if (arrowPrefab != null && bowPoint != null)
        {
            arrow = Instantiate(arrowPrefab, bowPoint.transform.position,
                bowPoint.transform.rotation);
            arrow.transform.parent = bowPoint.transform;
            grabpoint.reloadArrow(arrow, player);
            haveArrow = true;
        }
        else
        {
            Debug.LogWarning("arrowPrefab 또는 bowPoint가 설정되지 않았습니다.");
        }
    }
}
