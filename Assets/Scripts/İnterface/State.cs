using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour,IState
{
    //public IState ýstate { get; set; }
    public void Run(bool state)
    {
        if (state)
        {
            StateTrue();
        }
        else
        {
            StateFalse();
        }
    }
    public abstract void StateTrue();
    public abstract void StateFalse();

}
