

using System.Collections.Generic;
using UnityEngine;

public class CloudNoiseGenerator
{
    private List<ComputeBuffer> bufferToRelease;
    private ComputeShader noiseCompute;

    private void CreateWorleyPointsBuffer(int numCellPerAxis, string bufferName)
    {
        var points = new Vector3[numCellPerAxis * numCellPerAxis * numCellPerAxis];
        float cellSize = 1f / numCellPerAxis;

        for (int x = 0; x < numCellPerAxis; x++)
        {
            for (int y = 0; y < numCellPerAxis; y++)
            {
                for (int z = 0; z < numCellPerAxis; z++)
                {
                    var randomOffset = new Vector3(Random.value, Random.value, Random.value);
                    var position = (new Vector3(x, y, z) + randomOffset) * cellSize;
                    int index = x + numCellPerAxis * (y + z * numCellPerAxis);
                    points[index] = position;
                }
            }
        }

        CreateBuffer(points, sizeof(float) * 3, bufferName);
    }

    private void CreateBuffer(System.Array data, int stride, string bufferName, int kernel = 0)
    {
        var buffer = new ComputeBuffer(data.Length, stride, ComputeBufferType.Raw);
        bufferToRelease.Add(buffer);
        buffer.SetData(data);
        noiseCompute.SetBuffer(kernel, bufferName, buffer);
    }
}
