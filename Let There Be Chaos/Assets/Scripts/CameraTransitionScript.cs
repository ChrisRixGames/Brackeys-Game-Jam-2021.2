using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTransitionScript : MonoBehaviour
{

    private CinemachineVirtualCamera vCam;
    private CinemachineConfiner2D confiner2D;
    [SerializeField]
    private float dampeningTransitionSpeed;
    [SerializeField]
    private float sizeTransitionSpeed;

    public PolygonCollider2D[] cameraZones;
    public float[] cameraZoneLensSize;

    Coroutine lerpCoroutine;

    private void Awake()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        confiner2D = GetComponent<CinemachineConfiner2D>();
    }
    
    public void TransitionCamera(int id)
    {
        StopCoroutine(lerpCoroutine);
        confiner2D.m_BoundingShape2D = cameraZones[id];
        confiner2D.m_Damping = 0.5f;
        lerpCoroutine = StartCoroutine(TransitionLerp(id));
    }

    public void TransitionCamera(PolygonCollider2D collider, float lensSize)
    {
        if (lerpCoroutine != null)
        {
            StopCoroutine(lerpCoroutine);
        }
        
        confiner2D.m_BoundingShape2D = collider;
        confiner2D.m_Damping = 0.5f;
        //vCam.m_Lens.OrthographicSize = lensSize;
        lerpCoroutine = StartCoroutine(TransitionLerp(collider, lensSize));
    }

    private IEnumerator TransitionLerp(int id)
    {
        while (confiner2D.m_Damping != 0 && vCam.m_Lens.OrthographicSize != cameraZoneLensSize[id])
        {
            confiner2D.m_Damping = Mathf.MoveTowards(confiner2D.m_Damping, 0, dampeningTransitionSpeed * Time.deltaTime);
            vCam.m_Lens.OrthographicSize = Mathf.MoveTowards(vCam.m_Lens.OrthographicSize, cameraZoneLensSize[id], sizeTransitionSpeed * Time.deltaTime);
            yield return null;
        }

        yield return null;
    }

    private IEnumerator TransitionLerp(PolygonCollider2D collider, float lensSize)
    {
        Debug.Log("Transitioning");
        while (confiner2D.m_Damping != 0 && vCam.m_Lens.OrthographicSize != lensSize)
        {
            confiner2D.m_Damping = Mathf.MoveTowards(confiner2D.m_Damping, 0, dampeningTransitionSpeed * Time.deltaTime);
            Camera.main.orthographicSize = Mathf.MoveTowards(vCam.m_Lens.OrthographicSize, lensSize, sizeTransitionSpeed * Time.deltaTime);
            yield return null;
        }

        yield return null;
    }
}
