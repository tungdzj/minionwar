using UnityEngine;
using System.Collections;

public class Boom : BaseTrap {

    private float timeToExplose = 2;
    public override void Update()
    {
        timeToExplose -= Time.deltaTime;
        if (timeToExplose <= 0)
        {

        }
    }

    public override int OnBoom()
    {
        return base.OnBoom();
    }
}
