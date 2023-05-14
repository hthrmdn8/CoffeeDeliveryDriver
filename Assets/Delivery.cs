using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(127, 61, 229, 255);

    [SerializeField] Color32 noPackageColor = new Color32(28, 215, 184, 255);

    [SerializeField] float destroyDelay;

    bool hasPackage;
    SpriteRenderer spriteRenderer;
    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void CollisionEnter2D(Collision2D other) 
    {
           Debug.Log(hasPackage);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package" && !hasPackage){
            Debug.Log("package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);

        }
        if(other.tag == "Customer" && hasPackage){
            Debug.Log("package dropped off");
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }


    }
}
