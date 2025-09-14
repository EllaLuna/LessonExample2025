using UnityEngine;

public class GameState : MonoBehaviour
{
    public StateSO stateData;
    public bool isCurrentState;
    public GameState previousState;
    GameState nextState;
    //TODO: Add Transitions
    public bool wasTransitionedInto;
    public bool inTransition;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
