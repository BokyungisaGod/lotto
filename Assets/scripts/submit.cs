using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class submit : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;

    // Update is called once per frame
    public void eat() 
    {
        anim.SetTrigger("On");
    }
}
