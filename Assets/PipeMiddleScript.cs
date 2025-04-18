using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    private const int BIRD_LAYER = 3;
    public LogicManagerScript logicManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.logicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == BIRD_LAYER)
        {
            this.logicManager.addScore(1);
        }
    }
}
