using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PursueTransform : MonoBehaviour
{
    public Transform _toPursue;

    private void Update()
    {
        if (!_toPursue.IsUnityNull())
            transform.position = _toPursue.position;
    }
}
