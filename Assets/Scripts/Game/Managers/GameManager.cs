using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Point = 0;

    public float PlayerMovementSpeed = 1f;



    public void AddPoint(int point)
    {
        Point += point;
    }
}
