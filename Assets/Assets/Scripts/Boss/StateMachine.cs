using UnityEngine;

public class StateMachine
{
   public BasebossState currentState {get; private set;}
    
   public void Initialize(BasebossState _startState)
   {
    currentState = _startState;
    currentState.Enter();
    
   }

   public void ChangeState(BasebossState _newState)
   {
    currentState.Exit();
    currentState = _newState;
    currentState.Enter();
   }
}
