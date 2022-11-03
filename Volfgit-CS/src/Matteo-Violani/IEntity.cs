using vg.utility;

namespace vg.model.entity.dynamicEntity.player;

/// <summary>
///  Entity is the upper interface that describes an object on the map,
/// that can be static/dynamic, with a shape or not (a V2D position basically).
/// Every entity has a MassTier, even the ones without a shape. If this interfaces
/// is implemented and is not a {@link ShapedEntity}, {@link #isInShape(ShapedEntity)}
/// can use the ShapedEntity {@link ShapedEntity#isInShape(V2D)} internally.
/// </summary>
public interface IEntity 
{
    /// <summary>
    /// Returns the position of the entity.
    /// </summary>
    /// <returns>the position of the entity</returns>
    V2D GetPosition();

    /// <summary>
    /// Check if this entity (that is at least a V2D position) is in the same position as another.
    /// </summary>
    /// <param name="position">the position to check if is on the same position as this.</param>
    /// <returns>true if the position is the same, false otherwise.</returns>
    bool IsInShape(V2D position);
    
    /// <summary>
    ///  Check if this entity (that is at least a V2D position) is contained or colliding with a ShapedEntity.
    /// </summary>
    /// <param name="entity">the ShapedEntity to check if this is colling with.</param>
    /// <returns>true if the position of this is in shape of the entity, false otherwise</returns>
    bool IsInShape(ShapedEntity entity);
    
    /// <summary>
    /// Returns the mass tier of the entity.
    /// </summary>
    /// <returns>the mass tier of the entity.</returns>
    MassTier GetMassTier();
    
    /// <summary>
    /// Sets the mass tier of the entity.
    /// </summary>
    /// <param name="toSet">the mass tier to set to</param>
    void SetMassTier(MassTier toSet);

}