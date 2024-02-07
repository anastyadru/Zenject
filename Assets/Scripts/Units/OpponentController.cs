using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : AbstractUnit
{
    protected override void Move()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
        if (transform.position.y > _finishPos)
        {
            Debug.Log("You loose");
        }
    }
}