using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Util : MonoBehaviour
{
    public static IEnumerator CloseButtonInteraction(Button button ,float duration)
    {
        button.interactable= false;
        yield return new WaitForSeconds(duration);
        button.interactable = true;
    }
}
