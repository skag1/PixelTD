using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform startPoint;
    public Transform startPoint1;
    public Transform startPoint2;
    public Transform[] path;
    public Transform[] path1;
    public Transform[] path2;

    private void Awake()
    {
        main = this;
    }
}
