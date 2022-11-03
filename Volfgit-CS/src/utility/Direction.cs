namespace TestProject1.utility;

public enum EDirection
{
    Left,
    Right,
    Up,
    Down,
    None
}

public static class Direction
{
    private static readonly Dictionary<EDirection, V2D> DirectionV2Ds = new Dictionary<EDirection, V2D>()
    {
        {EDirection.Left, new V2D(-1, 0)},
        {EDirection.Right, new V2D(1, 0)},
        {EDirection.Up, new V2D(0, -1)},
        {EDirection.Down, new V2D(0, 1)},
        {EDirection.None, new V2D(0, 0)},
    };
    
    public static V2D GetVector(EDirection direction) {
        return DirectionV2Ds[direction];
    }
} 