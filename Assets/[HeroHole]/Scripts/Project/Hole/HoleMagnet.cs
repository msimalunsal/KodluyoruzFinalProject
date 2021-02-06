using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;
[RequireComponent(typeof(SphereCollider))]
public class HoleMagnet : MonoBehaviour
{

    [SerializeField] float magnetForce = default;
    public GameObject vehiclesAll;
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
    #region Trigger Methods
    void OnTriggerEnter(Collider other)
    {
        var obj = other.GetComponent<Killable>();
        if (obj != null)
        {
            AddtoMagnetField(other.attachedRigidbody);
            obj.ClosePath();
        }
    }

    void OnTriggerExit(Collider other)
    {
        var obj = other.GetComponent<Killable>();
        if (obj != null)
        {
            RemoveFromMagnetField(other.attachedRigidbody);

            if (other.transform.position.y < -1f)
            {
                obj.Kill();
                Destroy(other.gameObject);
                other.gameObject.transform.SetParent(vehiclesAll.transform);
                other.gameObject.SetActive(false);
            }
                
            else
                other.GetComponent<PathFollower>().enabled = true;
        }
    }
    #endregion

    public void AddtoMagnetField(Rigidbody rigidbody)
    {
        affectedRigidBodies.Add(rigidbody);
    }

    public void RemoveFromMagnetField(Rigidbody rigidbody)
    {
        affectedRigidBodies.Remove(rigidbody);
    }
}
