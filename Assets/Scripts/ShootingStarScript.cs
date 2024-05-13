using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootingStarScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 2.0f;

    private float x;
    private float y;
    private float z;
    private float timeToLive;

    public GameObject Target;
    public GameObject Particles;
    private GameObject t;
    private ParticleSystem p;
    void Start()
    {
        float posX = transform.position.x;
        float posZ = transform.position.x;
        int coinFlip = Random.Range(0, 1);
        int colorNum = Random.Range(0, 6);
        if(coinFlip == 0)
        {
            x = Random.Range(posX + 100.0f, posX + 150.0f);
            y = Random.Range(20.0f, 40.0f);
            z = Random.Range(posZ + 100.0f, posZ + 150.0f);
        }
        else
        {
            x = Random.Range(posX - 100.0f, posX - 150.0f);
            y = Random.Range(20.0f, 40.0f);
            z = Random.Range(posZ - 100.0f, posZ - 150.0f);
        }

        switch(colorNum)
        {
            case 0:

                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;

        }

       
        timeToLive = Random.Range(1.5f, 2.0f);
        speed = Random.Range(2.0f, 3.0f);

        t = Instantiate(Target, new Vector3(x, transform.position.y, z), Quaternion.identity);
        StartCoroutine(StartMetorite2());
        //StartCoroutine(PushMetorite());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StartMetorite()
    {
        transform.LookAt(t.transform);
        float timer = 0f;
        Vector3 targetPosition = new Vector3(x, transform.position.y - y, z);
        Vector3 startingPosition = transform.position;

        
        while(timer < timeToLive)
        {
            float t = Mathf.SmoothStep(0, 1, timer / timeToLive) * speed;
            transform.position = Vector3.Lerp(startingPosition, targetPosition, t);
            timer += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        // destroy here 
        Destroy(this.gameObject);
        Destroy(t.gameObject);
    }

    private IEnumerator StartMetorite2()
    {
        transform.LookAt(t.transform);
        float timer = 0f;
        Vector3 targetPosition = new Vector3(x, transform.position.y - y, z);
        Vector3 startingPosition = transform.position;


        while (transform.position != targetPosition)
        {
            float t = Mathf.SmoothStep(0, 1, timer / timeToLive) * speed;
            transform.position = Vector3.Lerp(startingPosition, targetPosition, t);
            timer += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        // destroy here 
        Destroy(this.gameObject);
        Destroy(t.gameObject);
    }

    // you have a star spawning manager, that spawns them in a random position and a slightly random angle 
    // on spawn they start a coroutine that moves them in a set direction at a slightly random speed and death timer and random color?
}
