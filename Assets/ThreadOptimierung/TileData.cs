using UnityEngine;

public struct TileData
{
    public Vector3 Position { get; set; }
    public Color Color { get; set; }
    public int RowCount { get; set; }

    public Unity.Mathematics.Random Random { get; set; }

    public int Price { get; set; }

    public TileData(Vector3 position, Color color, int rowCount, Unity.Mathematics.Random random, int price = 100)
    {
        Position = position;
        Color = color;
        RowCount = rowCount;
        Price = price;
        Random = random;
    }

    public void CalculateTile(int index)
    {
        Vector2Int position = new();
        position.x = index % RowCount;
        position.y = index / RowCount;

        var randCol = Random.NextFloat3();
        Color = new Color(randCol.x, randCol.y, randCol.z);

        Position = new Vector3(position.x, 0, position.y);
    }

    public void UpdatePrice(int index)
    {
        var rand = Random.NextFloat(-1f, 1f);
        Price += (int)(rand * 50f);
        Price = Unity.Mathematics.math.max(100, Price);

        float normalizedRandom = Unity.Mathematics.math.saturate(0.0f + (float)(Price - 100) * (1f - 0f) / (1000f - 100f));
        Unity.Mathematics.float3 newColor = Unity.Mathematics.math.lerp(new Unity.Mathematics.float3(0f, 1f, 0f), new Unity.Mathematics.float3(1f, 0f, 0f), normalizedRandom);
        Color = new Color(newColor.x, newColor.y, newColor.z);
    }
}
