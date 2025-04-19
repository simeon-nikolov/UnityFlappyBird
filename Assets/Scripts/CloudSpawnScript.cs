using UnityEngine;

public class CloudSpawnScript : MonoBehaviour
{
    public GameObject cloud;
    public float spawnRate = 15.0f;
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int initialCloudsCount = 3;
        for (int i = 0; i < initialCloudsCount; i++)
        {
            float leftBound = -10 * initialCloudsCount + i * 10;
            float righBound = initialCloudsCount * 10 - (initialCloudsCount - i) * 10;
            float x = Random.Range(leftBound, righBound);
            this.SpawnCloud(x);
        }
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
            this.SpawnCloud();
            this.timer = 0f;
        }
    }

    private void SpawnCloud(float x = 40.0f)
    {
        float y = Random.Range(-14.0f, 14.0f);
        float z = Random.Range(0f, 10.0f);
        Vector3 position = new Vector3(x, y, z);

        Instantiate(cloud, position, this.transform.rotation);
    }
}
