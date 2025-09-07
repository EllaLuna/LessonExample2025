using UnityEngine;

[CreateAssetMenu(fileName = "CollectableData", menuName = "Scriptable Objects/CollectableData", order = 0)]
public class CollectableData : ScriptableObject
{
    public Sprite sprite;
    public float delayForDestroy = 0.4f;
    public float waitForPlayer = 1f;
    public int score = 1;
}