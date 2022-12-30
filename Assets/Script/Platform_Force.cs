using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Force : MonoBehaviour
{

    [SerializeField] private float angle;
    [SerializeField] private float force;

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(angle, 90, 0) * force, ForceMode.Force);
    }

}
