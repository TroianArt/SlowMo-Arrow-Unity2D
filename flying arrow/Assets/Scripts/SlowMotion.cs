using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public float fullspeed = 1;

    public float slowspeed = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void startSlowMotion()
    {
        Time.timeScale = slowspeed;
    }


    public void endSlowMotion()
    {
        Time.timeScale = fullspeed;
    }

    // Update is called once per frame
    void Update()
    {
        float currentAmount = 0f;
        float maxAmount = 5f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                if (Time.timeScale == 1.0f)
                    Time.timeScale = 0.3f;

                else

                    Time.timeScale = 1.0f;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
            }


            if (Time.timeScale == 0.03f)
            {

                currentAmount += Time.deltaTime;
            }

            if (currentAmount > maxAmount)
            {

                currentAmount = 0f;
                Time.timeScale = 1.0f;

            }
        }
    }
}
