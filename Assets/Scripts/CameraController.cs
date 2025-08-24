using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] PlayerController target;

    void Start()
    {
       target = FindFirstObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position= new(target.transform.position.x, target.transform.position.y, -10);
    }
}
