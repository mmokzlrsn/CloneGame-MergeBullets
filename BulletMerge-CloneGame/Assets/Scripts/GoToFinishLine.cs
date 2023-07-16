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
        transform.DOMove(finishLine.transform.position, reachTime).SetEase(Ease.OutExpo); //on complete blend to the pistol cam
    }


}
