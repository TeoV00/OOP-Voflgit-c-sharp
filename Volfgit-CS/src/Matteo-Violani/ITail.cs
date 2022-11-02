using TestProject1.utility;

namespace vg.model.entity.dynamicEntity.player;

public interface ITail
{
    /// <summary>
    /// Get all coordinates that define tail of player.
    /// </summary>
    /// <returns>list of all point of tail saved</returns>
    List<V2D> GetCoordinates();
    
    /// <summary>
    /// Get all vertex point of tail
    /// </summary>
    /// <returns>list of V2D that are vertex of tail</returns>
    List<V2D> GetVertex();
    
    /// <summary>
    /// Remove al saved coordinates of tail.
    /// </summary>
    void ResetTail();
    
    /// <summary>
    /// Get last added coordinate of tail.
    /// </summary>
    /// <returns>Optional of V2D, if tail is empty is returned an {@link  Optional#absent()}</returns>
    V2D? GetLastCoordinate();

    /// <summary>
    /// Append new point to tail.
    /// </summary>
    /// <param name="point"> new point to add</param>
    void AddPoint(V2D point);
}