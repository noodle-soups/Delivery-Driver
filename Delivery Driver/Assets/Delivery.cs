using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;

    private void Start()
    {
        Debug.Log(hasPackage);    
    }


    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Collision");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        
         if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered to customer");
            hasPackage = false;
        }

    }

}
