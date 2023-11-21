using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounceApl;
    public AudioSource pong;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            pong.Play();
            Vector2 normal = collision.GetContact(0).normal;
            ball.AddForce(-normal * this.bounceApl);
        }
    }
}
