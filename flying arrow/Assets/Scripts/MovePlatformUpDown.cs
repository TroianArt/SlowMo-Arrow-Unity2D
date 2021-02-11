using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformUpDown : MonoBehaviour
{
    bool directionUp = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (directionUp)
        {
            Vector3 newPosition = transform.position;
            newPosition.y += 100;
            transform.position = Vector3.MoveTowards(transform.position, newPosition, 2f * Time.deltaTime);
        }
        else if (!directionUp)
        {
            Vector3 newPosition = transform.position;
            newPosition.y -= 100;
            transform.position = Vector3.MoveTowards(transform.position, newPosition, 1.5f * Time.deltaTime);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {               //если в тригере что то есть и у обьекта тег "ground"
        if (other.tag == "enemy") directionUp = !directionUp;
   
    }
}
