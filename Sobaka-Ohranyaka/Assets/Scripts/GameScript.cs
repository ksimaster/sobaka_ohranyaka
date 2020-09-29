using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
   int activeDog = 0;
    [SerializeField]
    Animator animator;
    [SerializeField]
    GameObject calmDown;


    void Update()
    {
        ChangeAnimation();
        ActiveCalmDownButton();
        
    }

    void ChangeAnimation()
    {
        animator.SetInteger("activeDog", activeDog);
    }
    public void ReturnIdle()
    {
        if (activeDog != 0) activeDog = 0;
        calmDown.SetActive(false);
    }
    void ActiveCalmDownButton()
    {
        if (activeDog != 0) calmDown.SetActive(true);
    }
    public void GrowlButtonClick()
    {
        activeDog = 1;
    }

    public void BarkButtonClick()
    {
        activeDog = 2;
    }
  
}
