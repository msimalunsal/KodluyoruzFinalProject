using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SphereCollider))]
public class HoleMagnet : MonoBehaviour
{

    [SerializeField] float magnetForce = default;

    List<Rigidbody> affectedRigidBodies = new List<Rigidbody>();
    Transform magnet;

    void Start()
    {
        magnet = transform;
        affectedRigidBodies.Clear();
    }

    void FixedUpdate()
    {
        foreach (Rigidbody rb in affectedRigidBodies)
        {
            if (rb != null)
            {
                rb.AddForce((magnet.position - rb.position) * magnetForce * Time.fixedDeltaTime);

            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //var pedestrian = other.GetComponent<Pedestrian>();
        //var car = other.GetComponent<Cars>();
        //if(pedestrian != null)
        //{
        //    pedestrian.moveTween.Kill();
        //    AddtoMagnetField(other.attachedRigidbody);
        //}
        //else if(car != null)
        //{
        //    Debug.Log("araba delikte");
        //    other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        //    car.moveTween.Kill();
        //    AddtoMagnetField(other.attachedRigidbody);
        //    car.Kill();
        //}
        var obj = other.GetComponent<Killable>();
        if (obj != null)
        {
            obj.Kill();
            AddtoMagnetField(other.attachedRigidbody);
        }
    }


    void OnTriggerExit(Collider other)
    {
        string tag = other.tag;
        if ((tag.Equals("Pedestrian") || tag.Equals("Car")))
        {
            RemoveFromMagnetField(other.attachedRigidbody);
        }
    }

    public void AddtoMagnetField(Rigidbody rigidbody)
    {
        affectedRigidBodies.Add(rigidbody);
    }

    public void RemoveFromMagnetField(Rigidbody rigidbody)
    {
        affectedRigidBodies.Remove(rigidbody);
    }
}
