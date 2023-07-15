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
        transform.DOMoveZ(finishLine.transform.position.z, reachTime); //on complete blend to the pistol cam
    }


}
