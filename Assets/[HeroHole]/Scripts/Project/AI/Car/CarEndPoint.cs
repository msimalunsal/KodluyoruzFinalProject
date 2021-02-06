using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEndPoint : MonoBehaviour
{
    public GameObject vehiclesAll = default ;
    private void OnCollisionEnter(Collision collision)
    {
        var obj = collision.gameObject.GetComponent<Car>();
        if (obj != null)
        {
            obj.transform.SetParent(vehiclesAll.transform);
        }
    }
}
