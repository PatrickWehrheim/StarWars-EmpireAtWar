using UnityEngine;

public class FighterSpawner : MonoBehaviour
{
    [SerializeField] private KIBehaviorSettings _kiBehaviorSettings;
    [SerializeField] private SelectedUnitsSettings _selectedUnitsSettings;
    [SerializeField] private GameObject _spriteBaseObject;
    
    [SerializeField] private GameObject _friendlyFighter;
    [SerializeField] private Vector3 _friendlyFighterStartPosition;

    [SerializeField] private GameObject _enemyFighter;
    [SerializeField] private Vector3 _enemyFighterStartPosition;

    [SerializeField] private float _fighterDistanceInSquad;
    [SerializeField] private Sprite _fighterSprite;

    [SerializeField] private bool _spawnFighter;
    [SerializeField] private GameObject _laserGreenObject;

    void Start()
    {
        if (_spawnFighter)
        {
            SpawnSquad("FriendlySquad", _friendlyFighter, _friendlyFighterStartPosition, false);
            SpawnSquad("EnemySquad", _enemyFighter, _enemyFighterStartPosition, true);
        }
    }

    private void SpawnSquad(string name, GameObject fighterToSpawn , Vector3 startPosition, bool isEnemy)
    {
        GameObject squadObject = GetNewSquadObject(name, startPosition);

        int rowCount = 0;
        for (int i = 0; i < _kiBehaviorSettings.FighterPerSquad; i++)
        {
            GameObject fighter = Instantiate(fighterToSpawn);
            fighter.tag = "Fighter";
            FighterController fighterController = fighter.AddComponent<FighterController>();
            fighterController.LaserGreenObject = _laserGreenObject;
            fighterController.LaserGreenObject.GetComponent<Laser>().Demage = 10;
            fighterController.SquadController = squadObject.GetComponent<SquadController>();
            BoxCollider boxCollider = fighter.AddComponent<BoxCollider>();
            boxCollider.size = new Vector3(10, 10, 25);
            boxCollider.center = new Vector3(0, 2, 0);
            Vector3 fighterPosition = new Vector3(squadObject.transform.position.x, 
                squadObject.transform.position.y, squadObject.transform.position.z - _fighterDistanceInSquad);

            if (i % 2 == 0)
            {
                fighterPosition.x += _fighterDistanceInSquad * rowCount;
            }
            else
            {
                rowCount++;
                fighterPosition.x -= _fighterDistanceInSquad * rowCount;
            }
            fighterPosition.z -= _fighterDistanceInSquad * rowCount;
            fighter.transform.position = fighterPosition;
            fighterController.Data.CurrentTarget = fighter.transform.position;
            

            SquadController controller = fighterController.SquadController;
            if (isEnemy)
            {
                fighter.layer = 9;
                squadObject.layer = 9;
                for (int j = 0; j < fighter.transform.childCount; j++)
                {
                    fighter.transform.GetChild(j).gameObject.layer = 9;
                    fighter.transform.GetChild(j).gameObject.tag = "Fighter";
                }
                for (int j = 0; j < squadObject.transform.childCount; j++)
                {
                    squadObject.transform.GetChild(j).gameObject.layer = 9;
                    squadObject.transform.GetChild(j).gameObject.tag = "Squad";
                }
                controller.Fighters.Add(fighterController);
                controller.Data.TargetLayerMask = GameManager.Instance.PlayerLayer;
                controller.Data.ObstacleAvoidanceLayerMask = GameManager.Instance.PlayerLayer + GameManager.Instance.ObstacleLayer;

            }
            else
            {
                fighter.layer = 7;
                squadObject.layer = 7;
                for (int j = 0; j < fighter.transform.childCount; j++)
                {
                    fighter.transform.GetChild(j).gameObject.layer = 7;
                    fighter.transform.GetChild(j).gameObject.tag = "Fighter";
                }
                for (int j = 0; j < squadObject.transform.childCount; j++)
                {
                    squadObject.transform.GetChild(j).gameObject.layer = 7;
                    squadObject.transform.GetChild(j).gameObject.tag = "Squad";
                }
                controller.Fighters.Add(fighterController);
                controller.Data.TargetLayerMask = GameManager.Instance.EnemyLayer;
                controller.Data.ObstacleAvoidanceLayerMask = GameManager.Instance.EnemyLayer + GameManager.Instance.ObstacleLayer;
            }

            fighterController.Data.TargetLayerMask = controller.Data.TargetLayerMask;
            fighterController.Data.ObstacleAvoidanceLayerMask = controller.Data.ObstacleAvoidanceLayerMask;
        }
    }

    private GameObject GetNewSquadObject(string name, Vector3 position)
    {
        GameObject squadObject = Instantiate(_spriteBaseObject);
        squadObject.name = name;
        squadObject.transform.position = position;
        squadObject.tag = "Squad";

        SquadController squadController = squadObject.GetComponent<SquadController>();
        squadController.SelectedUnitsSettings = _selectedUnitsSettings;
        squadController.LaserGreenObject = _laserGreenObject;

        SpriteRenderer spriteRenderer = squadObject.GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = _fighterSprite;

        return squadObject;
    }
}
