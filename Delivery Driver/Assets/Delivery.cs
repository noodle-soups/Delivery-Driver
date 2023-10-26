using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColour = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColour = new Color32 (1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            spriteRenderer.color = hasPackageColour;
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered to customer");
            hasPackage = false;
            spriteRenderer.color = noPackageColour;
        }

    }

}
