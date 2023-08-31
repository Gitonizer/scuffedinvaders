using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public delegate void GameOver();
    public static GameOver OnGameOver;
}
