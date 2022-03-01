using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransitionThresholdScript : MonoBehaviour
{

    private CameraTransitionScript transitionScript;
    [SerializeField]
    private bool horizontal;
    [SerializeField]
    private PolygonCollider2D firstCollider;
    [SerializeField]
    private float firstLensSize;
    [SerializeField]
    private PolygonCollider2D secondCollider;
    [SerializeField]
    private float secondLensSize;

    private void Awake()
    {
        transitionScript = Camera.main.GetComponent<VirtualCameraGetter>().GetVirtualCamera().GetComponent<CameraTransitionScript>();
        Debug.Log(Camera.main.GetComponent<VirtualCameraGetter>());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (horizontal)
        {
            if (Vector3.Dot(Vector3.right, collision.transform.position - transform.position) > 1)
            {
                transitionScript.TransitionCamera(firstCollider, firstLensSize);
            }
            else
            {
                transitionScript.TransitionCamera(secondCollider, secondLensSize);
            }
        }
        else
        {
            if (Vector3.Dot(Vector3.up, collision.transform.position - transform.position) > 1)
            {
                transitionScript.TransitionCamera(firstCollider, firstLensSize);
            }
            else
            {
                transitionScript.TransitionCamera(secondCollider, secondLensSize);
            }
        }
    }
}
