using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToFinishLine : MonoBehaviour
{
    [SerializeField] Transform finishLine;
    [SerializeField] float reachTime = 2f;

    public void GoFinishLine()
    {
        

        transform.DOMove(finishLine.transform.position, reachTime).SetEase(Ease.Linear).OnComplete(() =>
        {
            //camera switch
            CameraManager.instance.ChangeToNextCamera();
            PistolManager.instance.SetPistolPositions();
            InputManager.instance.CanMove = true;
            
        })
            ; //on complete blend to the pistol cam
    }


}
