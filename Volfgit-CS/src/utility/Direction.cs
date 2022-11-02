namespace TestProject1.utility;

public enum Direction
{
    LEFT(-1, 0),

    /**
     * Right.
     */
    RIGHT(1, 0),

    /**
     * Up.
     */
    UP(0, -1),

    /**
     * Down.
     */
    DOWN(0, 1),

    /**
     * No direction. No movement.
     */
    NONE(0, 0);


    /// Horizontal coordinate.
    private double X { get; }

    /// Vertical coordinate.
    private double y;
    
    public Direction(double x, double y) {
        X= x;
        Y = y;
    }

    public double getY() {
        return y;
    }

    public double getX() {
        return x;
    }

    ///
    public V2D GetVector() {
        return new V2D(this.x, this.y);
    }
}