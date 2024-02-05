using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPositionController : MonoBehaviour
{
    private int _posCounter;

    public Vector3 GetNewPos()
    {
        _posCounter++;
        return new Vector3();
    }
}