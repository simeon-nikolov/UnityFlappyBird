using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2.0f;
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.timer < this.spawnRate)
        {
            this.timer += Time.deltaTime;
        }
        else
        {
            this.SpawnPipe();
            this.timer = 0f;
        }
    }

    private void SpawnPipe()
    {
        Instantiate(pipe, this.transform.position, this.transform.rotation);
    }
}
