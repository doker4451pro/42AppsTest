using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    [SerializeField,Range(30,90)] private int _FPS;
    private void Awake()
    {
        Application.targetFrameRate = _FPS;
    }
}
