using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBox : MonoBehaviour
{
    private bool isInCamera;
    public bool withMove = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isInCamera == true)
        {
            if (withMove)
            {
                Vector3 newPosition = transform.position;
                newPosition.x -= 100;
                transform.position = Vector3.MoveTowards(transform.position, newPosition, 3f * Time.deltaTime);
            }
            Debug.Log(Time.deltaTime.ToString());
            transform.Rotate(0f * Time.deltaTime, 0f * Time.deltaTime, (float)(100 * Time.deltaTime));
        }
        
    }
    void OnTriggerStay2D(Collider2D other)
    {               
        if (other.tag == "MainCamera") isInCamera = true; ;

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "MainCamera") isInCamera = false;
    }
}
