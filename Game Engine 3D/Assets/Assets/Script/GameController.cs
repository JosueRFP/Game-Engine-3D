using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public UnityEvent OnSniperMode;
    public UnityEvent OnRifleMode;
   
    void Awake()
    {
        instance = this;
    }

   
}
