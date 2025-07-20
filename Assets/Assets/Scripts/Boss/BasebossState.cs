using UnityEngine;

public class BasebossState
{
    protected CreepBoss creepBoss;
    protected StateMachine stateMachine;
    private string animboolname;

    public BasebossState(CreepBoss _creepBoss, StateMachine _stateMachine, string _animboolname)
    {
        this.creepBoss = _creepBoss;
        this.stateMachine = _stateMachine;
        this.animboolname = _animboolname;
    }


    public virtual void Enter()
    {
        creepBoss.anim.SetBool(animboolname, true);
    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {
        creepBoss.anim.SetBool(animboolname, false);
    }
}
