using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    float horizontal;
    float vertical;
    Vector3 velocity;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * speed;
        vertical = Input.GetAxis("Vertical") * speed;
        velocity = new Vector3(horizontal, 0, vertical);
        

        
        transform.Translate(velocity);
    }
}
