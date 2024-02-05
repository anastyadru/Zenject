using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Create game config")]
public class GameConfig : ScriptableObject
{
    public int OpponentsCount;
    public float OpponentMinSpeed;
    public float OpponentMaxSpeed;
    public float PlayerSpeed;
}