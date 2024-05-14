using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofMover : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject roof1;
    private GameObject roof2;
    private Light light1;

    void Start()
    {
        roof1 = this.transform.GetChild(0).gameObject;

        roof2 = this.transform.GetChild(1).gameObject;

        light1 = this.transform.GetChild(2).GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FaceReality()
    {
        StartCoroutine(OpenUpTheSkies());
    }

    public IEnumerator OpenUpTheSkies()
    {
        light1.intensity = 0;
        float timer = 0f;
        float timeToLive = 20f;
        Vector3 startingPositionR1 = roof1.transform.position;
        Vector3 startingPositionR2 = roof2.transform.position;
        Vector3 r1Target = new Vector3(-259f, 0.4870427f, -0.00271542f);
        Vector3 r2Target = new Vector3(51f, 0.4870427f, 0.001357775f);
        yield return new WaitForSeconds(3);
        while (roof1.transform.position != r1Target)
        {
            float t = Mathf.SmoothStep(0, 1, timer / timeToLive);
            roof1.transform.position = Vector3.Lerp(startingPositionR1, r1Target, t);
            roof2.transform.position = Vector3.Lerp(startingPositionR2, r2Target, t);
            timer += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}
