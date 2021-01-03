using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianAnimationController : CharacterAnimationController
{
    float delay;
    private void Start()
    {
        delay = Random.Range(1f, 5f);
        this.Wait(delay, () => InvokeTrigger("Walk"));
    }
}
