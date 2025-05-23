using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControlInput : InputHandler
{

    private float horizontalAxis;

    private void Start()
    {
        StartCoroutine(Move());
    }

    public override bool GetFire1Button()
    {
        return true;
    }

    public override float GetHorizontalAxis()
    {
        return horizontalAxis;
    }

    public override float GetVerficalAxis()
    {
        return 0;
    }

    IEnumerator Move()
    {
        while (true)
        {
            horizontalAxis = -.5f;
            yield return new WaitForSeconds(2);
            horizontalAxis = .5f;
            yield return new WaitForSeconds(2);
        }
    }
}
