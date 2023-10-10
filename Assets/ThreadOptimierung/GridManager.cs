using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private NativeArray<TileData> _gridCreations;
    private NativeArray<TileData> _gridPrices;
    private Material[] _materials;
    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        _gridCreations = new NativeArray<TileData>(1024, Allocator.Persistent);

        for (int i = 0; i < _gridCreations.Length; i++)
        {
            var td = new TileData();
            td.RowCount = (int)Mathf.Sqrt(_gridCreations.Length);
            td.Random = new Unity.Mathematics.Random((uint)UnityEngine.Random.Range(0, 100000));

            _gridCreations[i] = td;
        }

        var job = new GridJobs.GridCreationJob 
        {
            TileDatas = _gridCreations
        };
        var jobHandle = job.Schedule(1024, 1);
        jobHandle.Complete();

        for (int i = 0; i < _gridCreations.Length; i++)
        {
            var gameObject = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), _gridCreations[i].Position, Quaternion.identity);
            _materials[i] = gameObject.GetComponent<Renderer>().material;
            gameObject.GetComponent<Renderer>().material.color = _gridCreations[i].Color;
        }

        _gridPrices = new NativeArray<TileData>(1024, Allocator.TempJob);

        for (int i = 0; i < _gridPrices.Length; i++)
        {
            var td = _gridCreations[i];
            td.Random = new Unity.Mathematics.Random((uint)UnityEngine.Random.Range(0, 100000));

            _gridPrices[i] = td;
        }

        _gridCreations.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer >= 1.0f)
        {
            var job = new GridJobs.GridPriceJob
            {
                TileDatas = _gridPrices
            };

            var jobHandle = job.Schedule(_gridPrices.Length, 1);
            jobHandle.Complete();

            _timer = 0.0f;
        }
        else
        {
            _timer += Time.deltaTime;
        }
    }

    private void OnDestroy()
    {
        _gridPrices.Dispose();
    }
}
