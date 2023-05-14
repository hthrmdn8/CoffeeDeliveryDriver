using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{


    [SerializeField] const float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 20f;

    [SerializeField]  float slowSpeed = 15f;
    [SerializeField]  float boostSpeed = 25f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {        
        float steerAmount =  Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);    
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed = slowSpeed;
        Debug.Log("Slowing down because you hit something!!!");            
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Speed Up"){
            moveSpeed = boostSpeed;
            Debug.Log("Speeding Up!!!");
        }
        if(other.tag == "Slow Down"){
            moveSpeed = slowSpeed;
            Debug.Log("Slowing Down!!!");            
        }

    }


}
