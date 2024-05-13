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
        int colorNum = Random.Range(0, 6);
        a = new Vector3(Random.Range(-450.0f, 450.0f), 250, Random.Range(-450.0f, 450.0f)); //
        GameObject instance = Instantiate(Star, a, Quaternion.identity);
        Material[] temp;
        
        switch (colorNum)
        {
            case 0:
                temp = instance.GetComponent<ShootingStarScript>().Particles.GetComponent<ParticleSystemRenderer>().materials; //  red
                temp[1].SetColor("_Color", new Color(2, 0, 0.24f));
                temp[1].SetColor("_EmissionColor", new Color(2, 0, 0.24f));
                break;
            case 1:
                temp = instance.GetComponent<ShootingStarScript>().Particles.GetComponent<ParticleSystemRenderer>().materials; // orange
                temp[1].SetColor("_Color", new Color(2, 0.4f, 0));
                temp[1].SetColor("_EmissionColor", new Color(2, 0.4f, 0));
                break;
            case 2:                                                                                                            // yellow  
                break;
            case 3:
                Debug.Log("Green spawned");
                temp = instance.GetComponent<ShootingStarScript>().Particles.GetComponent<ParticleSystemRenderer>().materials; // green
                temp[1].SetColor("_Color", new Color(0.4f, 2, 0.24f));
                temp[1].SetColor("_EmissionColor", new Color(0.4f, 2, 0.24f));
                break;
            case 4:
                temp = instance.GetComponent<ShootingStarScript>().Particles.GetComponent<ParticleSystemRenderer>().materials; // blue 
                temp[1].SetColor("_Color", new Color(0, 0.3f, 2));
                temp[1].SetColor("_EmissionColor", new Color(0, 0.3f, 2));
                break;
            case 5:
                temp = instance.GetComponent<ShootingStarScript>().Particles.GetComponent<ParticleSystemRenderer>().materials; // purple
                temp[1].SetColor("_Color", new Color(1.50f, 0, 1.75f));
                temp[1].SetColor("_EmissionColor", new Color(1.50f, 0, 1.75f));
                break;
            case 6:
                temp = instance.GetComponent<ShootingStarScript>().Particles.GetComponent<ParticleSystemRenderer>().materials; // violet
                temp[1].SetColor("_Color", new Color(2, 0, 0.7f));
                temp[1].SetColor("_EmissionColor", new Color(2, 0, 0.7f));
                break;
        }
        //instance.GetComponent<ShootingStarScript>().Particles.GetComponent<ParticleSystemRenderer>().material.EnableKeyword("_EMISSION");
        

        yield return new WaitForSeconds(.1f);
        StartCoroutine(SpawnStars());
    }
}
