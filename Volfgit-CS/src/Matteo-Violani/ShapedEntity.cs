using vg.utility;

namespace vg.model.entity.dynamicEntity.player;

/// <summary>
/// ShapedEntity implements {@link Entity} and add the {@link Shape}
/// to it (Circle or Square). It has {@link #radius} that defines
/// show large the entity is.
/// </summary>
public abstract class ShapedEntity
{
    /**
     * 2D coordinates to keep current entity position in map.
     */
    private V2D _position;
    /**
     * shape defines the shape of the shaped entity.
     * @see Shape
     */
    private readonly Shape _shape;
    /**
     * radius defines the radius of the shaped entity,
     * for now only squares and circles are available
     * as Shapes, so radius is actually the radius if
     * Shape is circle, and radius is the half-width
     * and half-height if shape is square.
     * @see Shape
     */
    private readonly int _radius;
    /**
     * @see MassTier
     */
    private MassTier _massTier;

    /**
     * Constructor of ShapedEntity class.
     * @param position the value of starting position
     * @param radius the value of the radius
     * @param shape the value of the shape
     * @param massTier the value of the mass tier
     * @see V2D
     * @see Shape
     * @see Entity
     * @see MassTier
     */
    protected ShapedEntity(V2D position, int radius, Shape shape, MassTier massTier) {
        this._position = position;
        this._radius = radius;
        this._shape = shape;
        this._massTier = massTier;
    }
    public V2D GetPosition() {
      return this._position;
    }

    /**
     * Update entity position with a new one.
     * @param position new position of entity
     */
    public void SetPosition(V2D position) {
        this._position = position;
    }

    /**
     * Getter of the radius of this entity. If the entity is a circle then it is
     * an actual radius from the center. If the entity is a square then it is the
     * half-width and half-height of the entity.
     * @return the radius or half-width/half-height
     * @see Shape
     */
    public int GetRadius() {
        return this._radius;
    }

    /**
     * Returns the shape of this entity.
     * @return the shape of this entity
     * @see Shape
     */
    public Shape GetShape() {
        return this._shape;
    }
    /**
     * Checks if the given position collides with this ShapedEntity.
     * @param position The position to check if it is in shape of this entity
     */
    public bool IsInShape(V2D position) {
        //return this.shape.isInShape(this.GetPosition(), position, this.GetRadius());
        //method not used for testing player
        return false;
    }

    /**
     * Checks if the two shaped entities are colliding.
     * @param other the ShapedEntity to check if this is colling with.
     * @return true if the two entities are colliding, false otherwise
     */
    public bool IsInShape(ShapedEntity other) {
        //return this.shape.isInShape(this.GetPosition(), other.GetPosition(), this.getRadius(), other.GetRadius(), other.GetShape());
        //method not used for testing player
        return false;
    }

    /**
     * {@inheritDoc}
     * @return the mass tier
     */
    public MassTier GetMassTier() {
        return this._massTier;
    }

    /**
     * {@inheritDoc}
     * @param toSet the mass tier to set to
     */
    public void SetMassTier(MassTier toSet) {
        this._massTier = toSet;
    }
}