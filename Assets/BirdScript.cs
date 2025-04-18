using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public LogicManagerScript logicManager;
    public Rigidbody2D birdRigidbody;
    public float flapStrength = 16;
    private bool birdIsAlive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && this.birdIsAlive)
        {
            this.birdRigidbody.linearVelocity = Vector2.up * this.flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.birdIsAlive = false;
        this.logicManager.gameOver();
    }
}
