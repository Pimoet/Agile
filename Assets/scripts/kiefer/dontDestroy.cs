using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
