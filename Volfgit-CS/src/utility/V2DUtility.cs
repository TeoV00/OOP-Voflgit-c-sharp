namespace TestProject1.utility;

public class V2DUtility
{
    /// <summary>
    /// From a list of coordinates extract vertex points.
    /// Each point is subtracted to the previous one and is checked the resulting vector if it corresponds
    /// to the previous direction.
    /// </summary>
    /// <param name="coordinates">list of point</param>
    /// <returns>list of point that are vertex of polyline</returns>
    public static List<V2D> GetVertex(List<V2D> coordinates) {
        List<V2D> vertex = new List<V2D>();
        if (coordinates.Count > 0) {
            EDirection prevDir = EDirection.None;
            V2D prev = coordinates[0];
            coordinates.RemoveAt(0);
            vertex.Add(prev);
            foreach (var nextCoordinate in coordinates)
            {
                //if prev direction and current are different, it means that
                // direction changed so "next" V2D is a vector
                EDirection diffDir = V2DUtility.GetDirection(nextCoordinate.Diff(prev));
                if (prevDir != diffDir) {
                    vertex.Add(nextCoordinate.Diff(nextCoordinate.Diff(prev)));
                    prevDir = diffDir;
                }
                prev = nextCoordinate;
            }
        }
        return vertex;
    }
    
    /// <summary>
    /// Utility method to get direction from vector considering coordinate sign.
    /// Example: (5,0) is {@link Direction#RIGHT}, (0, -4) is {@link Direction#UP}
    /// </summary>
    /// <param name="vector">V2D vector where extract direction.</param>
    /// <returns>corresponding DIRECTION</returns>
    public static EDirection GetDirection(V2D vector) {
        V2D vec = vector.GetSingVector();
        if (vec.Equals(Direction.GetVector(EDirection.Down))) {
            return EDirection.Down;
        } else if (vec.Equals(Direction.GetVector(EDirection.Up))) {
            return EDirection.Up;
        } else if (vec.Equals(Direction.GetVector(EDirection.Left))) {
            return EDirection.Left;
        } else if (vec.Equals(Direction.GetVector(EDirection.Right))) {
            return EDirection.Right;
        } else {
            return EDirection.None;
        }
    }
}