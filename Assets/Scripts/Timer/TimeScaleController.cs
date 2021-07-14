using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleController
{
    public static void ChangeTimeScaleSpeed(float timeSpeed)
    {
        Time.timeScale = timeSpeed;
    }
}
