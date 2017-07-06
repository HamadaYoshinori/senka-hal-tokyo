﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class MainThreadExecutor : MonoBehaviour
{
    public static Queue<Action> actions = new Queue<Action>();    // 非同期タスク

    void Update()
    {
        lock (actions)
        {
            while (actions.Count != 0)
            {
                var action = actions.Dequeue();
                action();
            }
        }
    }

    public static void Enqueue(Action action)
    {
        lock (actions)
        {
            actions.Enqueue(action);
        }
    }

    public static void Clear()
    {
        lock (actions)
        {
            Debug.LogWarning("actions clear");
            actions.Clear();
        }
    }
}
