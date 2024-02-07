using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractUnit : MonoBehaviour
{
    protected float _speed;
    protected float _finishPos;
    protected GameController _gameController;

    void Update()
    {
        if(_gameController.CanMove)
    }
    
}