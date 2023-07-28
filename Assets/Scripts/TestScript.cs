using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    Bounce bounce;
    public SpriteRenderer rend;
    // public float RotationSpeed;
    // public float Rotations;
    // Start is called before the first frame update
    void Start()
    {
        bounce = FindObjectOfType<Bounce>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bounce.isFlip)
            rend.flipY = true;
        if(!bounce.isFlip)
            rend.flipY = false;
        // Rotations += Time.deltaTime * RotationSpeed;
        // transform.rotation = Quaternion.Euler(0,0, Rotations);
    }
}
