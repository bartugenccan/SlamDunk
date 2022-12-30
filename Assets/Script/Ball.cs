using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioSource ballSound;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Basket"))
        {

            Vector3 closestPoint = other.ClosestPoint(transform.position);

            Vector3 normal = other.transform.TransformDirection(other.transform.up);

            float dotProduct = Vector3.Dot(transform.GetComponent<Rigidbody>().velocity, normal);

            if (dotProduct > 0)
            {
                gameManager.Score(transform.position);
            }
        }
        else if (other.CompareTag("GameOver"))
        {
            gameManager.GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ballSound.Play();
    }

}
