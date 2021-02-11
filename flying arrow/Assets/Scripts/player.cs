using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    bool directionUp = true;
    public float restartdelay = 2f;
   
    public GameObject PSdead;
    public GameObject PSacceleration;
    public float speed = 4f;
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public GameObject echo;
    bool isSlowMo = false;
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
            newPosition.x += 100;
            transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
        }
        else if (!directionUp)
        {
            Vector3 newPosition = transform.position;
            newPosition.y -= 100;
            newPosition.x += 100;
            transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
        }
        if (isSlowMo)
        {
            if (timeBtwSpawns <= 0)
            {
                if (directionUp)
                {
                    Instantiate(echo, transform.position, Quaternion.identity).transform.rotation = Quaternion.Euler(0, 0, 315);
                }
                else
                {
                    var ec = Instantiate(echo, transform.position, Quaternion.identity);
                    ec.transform.rotation = Quaternion.Euler(0, 0, 225);
                    //ec.transform.Rotate(180,0,0);
                }
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }



    }
    public void ChangeSlowmo()
    {
        isSlowMo = !isSlowMo;
    }
    public void change()
    {
        if (directionUp == true)
        {
            //transform.Rotate(0, 0, -90);
            transform.rotation = Quaternion.Euler(0, 0, 225);
        }
        else if (directionUp == false) transform.rotation = Quaternion.Euler(0, 0, 315); //transform.Rotate(0, 0, 90);
        directionUp = !directionUp;
    }
    void OnTriggerStay2D(Collider2D other)
    {               //если в тригере что то есть и у обьекта тег "ground"
        if (other.tag == "enemy")
        {
        
            Instantiate(PSdead, transform.position, Quaternion.identity);
            PSdead.SetActive(true);
            this.gameObject.SetActive(false);
            Invoke("restart", restartdelay);
            Time.timeScale = 1f;
            Time.fixedDeltaTime = Time.fixedDeltaTime * Time.timeScale;

        }//то включаем переменную "на земле"
        if (other.tag == "acceleration")
        {
            speed += 1f;
            Destroy(other);
            Instantiate(PSacceleration, transform.position, Quaternion.identity);
            PSdead.SetActive(true);
        }
       
    }
    public void pause()
    {
        if (Time.timeScale == 1.0f || Time.timeScale == 0.5f)
            Time.timeScale = 0f;
        else
        {
            if (isSlowMo) Time.timeScale = 0.5f;
            else Time.timeScale = 1.0f;
        }
        
    }
    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
