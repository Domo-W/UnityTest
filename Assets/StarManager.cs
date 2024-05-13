using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StarManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Star;

    private Vector3 a = new Vector3(0, 250, 0);
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.quoteKey.wasPressedThisFrame)
        {
           
        }
    }
}
