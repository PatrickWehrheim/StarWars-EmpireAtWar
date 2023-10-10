using UnityEngine;

public class TaskFlyInFormation : Node
{
    public override NodeState Evaluate()
    {
        FighterController fighterController = (FighterController)GetData(nameof(FighterController));
        FighterData fighterData = (FighterData)GetData(nameof(FighterData));

        fighterController.SeperationValue = 1.5f;
        fighterController.MoveToPoint(fighterController.SquadController.Position);

        _state = NodeState.Running;
        return _state;
    }
}
