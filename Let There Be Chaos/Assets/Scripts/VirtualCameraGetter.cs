using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCameraGetter : MonoBehaviour
{
    [SerializeField]
    private GameObject virtualCamera;

    public GameObject GetVirtualCamera()
    {
        return virtualCamera;
    }
}
