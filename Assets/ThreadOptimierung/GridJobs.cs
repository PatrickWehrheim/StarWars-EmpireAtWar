using Unity.Collections;
using Unity.Jobs;

public class GridJobs
{
    public struct GridCreationJob : IJobParallelFor
    {
        public NativeArray<TileData> TileDatas;

        public void Execute(int index)
        {
            TileData td = TileDatas[index];
            td.CalculateTile(index);

            TileDatas[index] = td;
        }
    }

    public struct GridPriceJob : IJobParallelFor
    {
        public NativeArray<TileData> TileDatas;

        public void Execute(int index)
        {
            TileData td = TileDatas[index];
            td.CalculateTile(index);

            TileDatas[index] = td;
        }
    }
}
