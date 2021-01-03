using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CarMovement : MonoBehaviour
{
    private void Start()
    {
        MoveCar();
    }
    public void MoveCar()
    {
        //transform.DOMove(transform.position + new Vector3(0f, 0f, -10f), 5f, false)
        //    .SetEase(Ease.Linear)
        //    .OnComplete(() =>
        //    {
        //        MoveCar();
        //    });
    }
}
