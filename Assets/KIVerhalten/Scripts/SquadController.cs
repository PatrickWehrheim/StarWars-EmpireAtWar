using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SquadController : ControllerBase
{
    public float FighterDistanceInSquad = 50f;
    public List<FighterController> Fighters;

    private SquadBehaviorTree _squadBehaviorTree;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        Data = new SquadData();

        //Data.TargetPositionChached = transform.position;

        Fighters = new List<FighterController>();
        _squadBehaviorTree = new SquadBehaviorTree(this);
    }

    private void Start()
    {
        Data.CurrentTarget = Position;

        _squadBehaviorTree.Start();

        foreach (FighterController controller in Fighters)
        {
            controller.FighterNeighboursInSquad = Fighters;
        }
    }

    private void Update()
    {
        _squadBehaviorTree.Update();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(Data.CurrentTarget, transform.position) > 80f)
        {
            _navMeshAgent.destination = Data.CurrentTarget;
        }
        else
        {
            Data.PatrolPositions.Remove(Data.CurrentTarget);
        }
    }

    public override void IsClicked()
    {
        foreach (var fighter in Fighters)
        {
            fighter.SquadClicked();
        }
    }

    public override void Deselect()
    {
        foreach (var fighter in Fighters)
        {
            fighter.Deselect();
        }
    }

    public void RemoveFighter(FighterController fighter)
    {
        Fighters.Remove(fighter);
        if(Fighters.Count == 0)
        {
            Die();
        }
    }
}
