using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootingStarScript : MonoBehaviour
{
    // Start is called before the first frame update
    private double speed = 1.0;

    private float x;
    private float y;
    private float z;
    private float timeToLive;

    void Start()
    {
        x = Random.Range(15.0f, 30.0f);
        y = Random.Range(5.0f, 10.0f);
        z = Random.Range(15.0f, 30.0f);

        timeToLive = Random.Range(1.5f, 2.0f);

        speed = Random.Range(1.0f, 2.0f);

        StartCoroutine(StartMetorite());

}

    // Update is called once per frame
    void Update()
    {
     
    }

    private IEnumerator StartMetorite()
    {
        float timer = 0f;
        Vector3 targetPosition = new Vector3(x, y, z);
        Vector3 startingPosition = transform.position;
        while(timer < timeToLive)
        {
            float t = Mathf.SmoothStep(0, 1, timer / timeToLive);
            transform.position = Vector3.Lerp(startingPosition, targetPosition, t);
            timer += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        // destroy here 
        this.gameObject.SetActive(false);
    }


    // you have a star spawning manager, that spawns them in a random position and a slightly random angle 
    // on spawn they start a coroutine that moves them in a set direction at a slightly random speed and death timer and random color?
}
