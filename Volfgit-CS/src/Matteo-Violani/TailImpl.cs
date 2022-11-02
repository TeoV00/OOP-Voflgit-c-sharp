using TestProject1.utility;

namespace vg.model.entity.dynamicEntity.player;

using System.Collections.Generic;
using System.Collections.Immutable;
public class TailImpl : ITail
{
    /// <summary>
    /// List of all extremity point of segment.
    /// </summary>
    private List<V2D> _coordinates;

    public static ITail EmptyTail() {
        return new TailImpl();
    }
    private TailImpl() {
        _coordinates = new List<V2D>();
    }

    public List<V2D> GetCoordinates() {
        return _coordinates.ToImmutableList().ToList();
    }
    
    public void ResetTail() {
        _coordinates = new List<V2D>();
    }
    
    public V2D? GetLastCoordinate() {
        if (_coordinates.Count > 0)
        {
            return _coordinates[_coordinates.Count - 1];
        } else {
            return new Nullable<V2D>();
        }
    }
    
    public void AddPoint(V2D point) {
        if (!this._coordinates.Contains(point)) {
            _coordinates.Add(point);
        }
    }
    
    public List<V2D> GetVertex() {
        return V2DUtility.GetVertex(this._coordinates);
    }
}