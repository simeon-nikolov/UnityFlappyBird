using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 4.0f;
    private float timer = 0f;
    public float heightOffset = 10f;

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
        float lowestPoint = this.transform.position.y - this.heightOffset;
        float highestPoint = this.transform.position.y + this.heightOffset;
        Vector3 spawnPosition = new Vector3(this.transform.position.x, Random.Range(lowestPoint, highestPoint), 0);

        Instantiate(pipe, spawnPosition, this.transform.rotation);
    }
}
