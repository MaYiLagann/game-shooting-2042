using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float PlayerMovementSpeed = 1f;



    [NonSerialized]
    public int Point = 0;



    public void AddPoint(int point)
    {
        Point += point;
    }
}
