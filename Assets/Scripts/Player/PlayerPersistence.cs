using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPersistence : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
