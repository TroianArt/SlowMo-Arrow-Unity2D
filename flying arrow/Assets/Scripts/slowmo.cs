using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowmo : MonoBehaviour
{
    // Start is called before the first frame update
    private float fixedDeltaTime;
    void Awake()
    {
        // Make a copy of the fixedDeltaTime, it defaults to 0.02f, but it can be changed in the editor
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.5f;
            else
                Time.timeScale = 1.0f;
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        }
    }
    public void SlowMo()
    {
        if (Time.timeScale != 0f)
        {
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.5f;
            else
                Time.timeScale = 1.0f;
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        }
    }

}
