using vg.utility;

namespace vg.model.entity.dynamicEntity.player;

public abstract class DynamicEntity : ShapedEntity
{
    /// <summary>
    /// Entity movement speed.
    /// </summary>
    private V2D _speed;
    private V2D _speedSaved;

    public DynamicEntity(V2D position, V2D speed, int radius, Shape shape, MassTier massTier) 
        : base(position, radius, shape, massTier) {
        this._speed = speed;
        this._speedSaved = speed;
    }

    /// <summary>
    /// Sums the speed to position and sets the result to position.
    /// </summary>
    public void Move() {
        SetPosition(GetPosition().Sum(GetSpeed()));
    }
    
    /// <summary>
    /// Return vector that represent current entity speed.
    /// </summary>
    /// <returns>  current entity speed</returns>
    public V2D GetSpeed() {
        return this._speed;
    }

    /// <summary>
    /// Sets the speed of the entity.
    /// </summary>
    /// <param name="newSpeed">newSpeed the speed to set to</param>
    public void SetSpeed(V2D newSpeed) {
        this._speed = newSpeed;
    }
    
    /// <summary>
    /// Evaluates what happens to the entity after a
    /// collision. Generally an entity will "bounce"
    /// if a collision occurs with another entity which
    /// {@link MassTier} equal or higher, than it will
    /// bounce, otherwise not. An exception is for entities
    /// with mass tier of {@link MassTier#NOCOLLISION}, this
    /// type of mass tier will never "bounce".
    /// </summary>
    /// <param name="other">the mass tier of the entity comparing to</param>
    public void AfterCollisionAction(MassTier other) {
        this.Bounces();
    }

    private void Bounces() {
    }

    public void SaveMySpeed() {
        this._speedSaved = _speed;
    }

    public void RestoreMySpeed() {
        this._speed = _speedSaved;
    }
}