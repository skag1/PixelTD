using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action<int> EnemyFinished;

    public static void OnEnemyFinished(int hpCost)
    {
        EnemyFinished?.DynamicInvoke(hpCost);
    }
}
