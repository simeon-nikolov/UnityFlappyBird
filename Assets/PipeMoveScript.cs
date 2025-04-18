using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.left * this.moveSpeed * Time.deltaTime;
    }
}
