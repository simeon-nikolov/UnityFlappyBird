using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D birdRigidbody;
    public float flapStrength = 16;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.birdRigidbody.linearVelocity = Vector2.up * this.flapStrength;
        }
    }
}
