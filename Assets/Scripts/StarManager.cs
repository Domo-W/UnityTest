using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StarManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Star;
    public GameObject SpawnArea;

    private Vector3 a;
    void Start()
    {
        StartCoroutine(SpawnStars());
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.quoteKey.wasPressedThisFrame)
        {

            Debug.Log("Spawn star");

            float x = Random.Range(100.0f, 150.0f);
            float y = Random.Range(20.0f, 40.0f);
            float z = Random.Range(100.0f, 150.0f);

            float yRot = Random.Range(-40f, 40f);
 

            float timeToLive = Random.Range(1.5f, 2.0f);

            float speed = Random.Range(1.0f, 2.0f);

            Instantiate(Star, a, Quaternion.identity);
        }
    }

    private IEnumerator SpawnStars()
    {
        a = new Vector3(Random.Range(-80.0f, 80.0f), 250, Random.Range(-80.0f, 80.0f));
        Instantiate(Star, a, Quaternion.identity);
        yield return new WaitForSeconds(1);
        StartCoroutine(SpawnStars());
    }
}
