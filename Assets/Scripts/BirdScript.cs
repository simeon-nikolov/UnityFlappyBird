using System.Collections;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private const float UPPER_BOUND = 18.5f;
    private const float BOTTOM_BOUND = -18.5f;
    private const float OOUT_OF_SCENE_Y = -20f;

    public LogicManagerScript logicManager;
    public Rigidbody2D birdRigidbody;
    public AudioSource wingFlapAudio;
    public Animator animator;

    public float flapStrength = 16;
    private bool isBirdAlive = true;
    private float flapTimer = 0.0f;

    public bool GetIsBirdAlive()
    {
        return this.isBirdAlive;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.CheckIsJumpPressed() && this.isBirdAlive)
        {
            this.birdRigidbody.linearVelocity = Vector2.up * this.flapStrength;
            this.FlapWings();
        }

        if (this.CheckIsBirdOutOfBounds())
        {
            this.birdRigidbody.linearVelocity = Vector2.down;
            this.Die();
        }

        if (this.CheckIsBirdOutOfScene())
        {
            Destroy(this.gameObject);
        }

        this.UpdateFlapping();
    }

    private void FlapWings()
    {
        this.wingFlapAudio.Stop();
        this.wingFlapAudio.time = 0.2f;
        this.wingFlapAudio.Play();
        this.flapTimer = 0.4f;
        StartCoroutine(AnimateFlapping());
    }

    IEnumerator AnimateFlapping()
    {
        this.animator.SetBool("isFlapping", false);
        yield return new WaitForSeconds(0.1f);
        this.animator.SetBool("isFlapping", true);
    }

    private void UpdateFlapping()
    {
        if (this.flapTimer > 0f)
        {
            this.flapTimer -= Time.deltaTime;

            if (this.flapTimer <= 0f)
            {
                StopFlappingAnimation();
            }
        }
    }

    private void StopFlappingAnimation()
    {
        this.animator.SetBool("isFlapping", false);
    }

    private bool CheckIsJumpPressed()
    {
        return
            Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.Mouse0);
    }

    private bool CheckIsBirdOutOfBounds()
    {
        float y_pos = this.transform.position.y;
        return y_pos < BOTTOM_BOUND || UPPER_BOUND < y_pos;
    }

    private bool CheckIsBirdOutOfScene()
    {
        return this.transform.position.y < OOUT_OF_SCENE_Y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.Die();
    }

    private void Die()
    {
        this.isBirdAlive = false;
        this.logicManager.GameOver();
    }
}
