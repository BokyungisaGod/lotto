using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    public Text text;
    public int Num;
    public GameObject img;

    public void CountNumber()
    {
        text.text = ""+Num;
        img.SetActive(true);

        if(Num > 1)
        {
            Invoke("CountNumber", 1f);
            Num--;
        }
        else
        {
            SceneManager.LoadScene("lotto");
        }
    }
}