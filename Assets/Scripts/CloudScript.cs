using System;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public const float DEAD_ZONE = -45.0f;
    private float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float z = this.transform.position.z;
        float scale = Math.Max(Math.Min(3f - (z / 10 * 3f), 2.5f), 1f);
        this.transform.localScale = new Vector3(scale, scale);
        this.moveSpeed = scale + 2f;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.left * this.moveSpeed * Time.deltaTime;

        if (this.transform.position.x < DEAD_ZONE)
        {
            Debug.Log("Cloud deleted!");
            Destroy(this.gameObject);
        }
    }
}
