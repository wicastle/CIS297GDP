using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyMusic : MonoBehaviour
{
    private static DoNotDestroyMusic instance = null;
    public static DoNotDestroyMusic Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

}
