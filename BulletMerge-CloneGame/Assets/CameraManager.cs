using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    private void Awake()
    {
        instance = this;
    }
    public CinemachineVirtualCamera[] cameras;

    public CinemachineVirtualCamera bulletCamera;
    public CinemachineVirtualCamera pistolCamera;

    public void ChangeToNextCamera()
    {
        var temp = bulletCamera.Priority;
        bulletCamera.Priority = pistolCamera.Priority;
        pistolCamera.Priority = temp;
    }

}
