using System.Collections;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] CollectableData collectableData;
    SpriteRenderer sprite;
    bool playerNotReached = false;
    bool playerTouched = false;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = collectableData?.sprite;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !playerNotReached)
        {
            playerTouched = true;
            sprite.color = Color.green;
            Events.OnScoreUpdate?.Invoke(collectableData.score);
            Destroy(gameObject, collectableData.delayForDestroy);
            return;
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(DelayDestruction());
        }
    }

    public void SetCollectableData(CollectableData collectableData)
    {
        this.collectableData = collectableData;
    }

    IEnumerator DelayDestruction()
    {
        yield return new WaitForSeconds(collectableData.waitForPlayer);
        if (!playerTouched)
        {
            playerNotReached = true;
            sprite.color = Color.red;
            Events.OnScoreUpdate?.Invoke(-collectableData.score);
            Destroy(gameObject, collectableData.delayForDestroy);
        }
    }
}
