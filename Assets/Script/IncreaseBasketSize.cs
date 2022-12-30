using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBasketSize : MonoBehaviour
{

    [SerializeField] private float startingTime;
    [SerializeField] private GameManager _GameManager;
    void Start()
    {
        
    }

    void Update()
    {
        StartCoroutine(StartCounting());
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        startingTime = 7;
        _GameManager.IncreaseBasketSize(transform.position);
    }

    IEnumerator StartCounting()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            startingTime -= Time.deltaTime;

            if(startingTime <= 0)
            {
                gameObject.SetActive(false);
                startingTime = 7;
                break;
            }
        }
    }
}
