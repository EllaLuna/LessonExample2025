using System.Collections;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] float delayForDestroy = 0.4f;
    [SerializeField] float waitForPlayer = 1f;
    [SerializeField] int score = 1;
    SpriteRenderer sprite;
    bool playerNotReached = false;
    bool playerTouched = false;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !playerNotReached)
        {
            playerTouched = true;
            sprite.color = Color.green;
            Events.OnScoreUpdate?.Invoke(score);
            Destroy(gameObject, delayForDestroy);
            return;
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(DelayDestruction());
        }
    }

    IEnumerator DelayDestruction()
    {
        yield return new WaitForSeconds(waitForPlayer);
        if (!playerTouched)
        {
            playerNotReached = true;
            sprite.color = Color.red;
            Events.OnScoreUpdate?.Invoke(-score);
            Destroy(gameObject, delayForDestroy);
        }
    }
}
