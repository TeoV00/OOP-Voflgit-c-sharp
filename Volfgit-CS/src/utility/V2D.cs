namespace TestProject1.utility;

public struct V2D
{
    public double X { get; }
    public double Y { get; }

    public V2D(double x, double y)
    {
        X = x;
        Y = y;
    }

    public V2D Sum(V2D pos)
    {
        return new V2D(X + pos.X, Y + pos.Y);
    }
    
    public V2D Diff(V2D pos) {
        return new V2D(X - pos.X, Y - pos.Y);
    }

    public V2D Mul(V2D pos) {
        return new V2D(X * pos.X, Y * pos.Y);
    }

    public V2D Mul(double x, double y) {
        return new V2D(X * x, Y * y);
    }

    public V2D ScalarMul(double scalar) {
        return this.Mul(new V2D(scalar, scalar));
    }
    
    /// <returns>vector with absolute value of coordinates</returns>
    public V2D RemoveSign() {
        return new V2D(Math.Abs(this.X), Math.Abs(this.Y));
    }
    
    /// <summary>
    /// Change coordinate sign to the passed signs of signVector
    /// Each nth-coordinate of current vector gets sing of nth-sign of passed vector.
    /// </summary>
    /// <param name="signVector">vector to get signs of coordinates</param>
    /// <returns>V2D with the updated sign</returns>
    public V2D UpdateSign(V2D signVector) {
        //remove signs
        V2D absVector = this.RemoveSign();
        double xSign = signVector.X < 0 ? -1 : 1;
        double ySign = signVector.Y < 0 ? -1 : 1;
        return absVector.Mul(xSign, ySign);
    }
    /// <summary>
    /// Return a new vector where if coordinates are sign of vector coordinate. So they can assume only values 1, -1 and 0.
    /// </summary>
    /// <returns>Vector which coordinate can only assume values 1, -1, 0</returns>
    public V2D GetSingVector() {
        int x = GetValueSign(this.X);
        int y = GetValueSign(this.Y);
        return new V2D(x, y);
    }
    
    private int GetValueSign(double value)
    {
        return value switch
        {
            > 0 => 1,
            < 0 => -1,
            _ => 0
        };
    }
    
    /// <summary>
    /// Checks if the argument is adjacent.
    /// </summary>
    /// <param name="other">the other V2D</param>
    /// <returns>
    /// true if the difference between the two points
    /// is either (-1,0) (0,-1) (1,0) or (0,1)
    /// </returns>
    public bool IsAdj(V2D other) {
        //TODO: understand how use stream in c#
        return Stream.of(-1, 1)
            .flatMap(e -> Stream.of(new V2D(e, 0), new V2D(0, e)))
            .anyMatch(e -> e.equals(other.Sum(this.ScalarMul(-1))));
    }

    public new string ToString()
    {
        return $"Position x={this.X}, y={this.Y}";
    }

    public bool Equals(V2D other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y);
    }

    public override bool Equals(object? obj)
    {
        return obj is V2D other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
    
}