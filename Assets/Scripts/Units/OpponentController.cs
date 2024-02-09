using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

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

	public class OpponentFabrik : Factory<float, float, GameController, OpponentController>
}