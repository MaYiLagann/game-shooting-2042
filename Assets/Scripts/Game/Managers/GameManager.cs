using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public float PlayerMovementSpeed = 1f;

    public UnityEvent OnValueChange;



    [NonSerialized]
    public int Point = 0;



    public void AddPoint(int point)
    {
        Point += point;

        OnValueChange.Invoke();
    }
}
