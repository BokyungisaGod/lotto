using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class select : MonoBehaviour
{
    Button[] btn;
    public static int cnt;

    public void checkButton()
    {
        if (cnt > 4)
        {
            Debug.Log("사탕 다 고름ㅋ");
        }
    }
}
