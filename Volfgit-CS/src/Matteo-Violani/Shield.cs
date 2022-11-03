namespace vg.model.timedObject;

public class Shield : TimedObject
{
    /// <summary>
    /// Default duration of shield in game loop time unit.
    /// </summary>
    public const int DefaultDuration = 70000;

    /// <summary>
    /// Shield activation status.
    /// </summary>
    private bool _isActive;

    private Shield(double duration, bool isActive) : base(duration) {
        this._isActive = isActive;
    }

    public static Shield Create(double duration, bool isActive) {
        return new Shield(duration, isActive);
    }

    /// <summary>
    /// Get status of shield. if it is active or not.
    /// Its state depend on internal timer.
    /// </summary>
    /// <returns>true if active, false if not</returns>
    public bool IsActive() {
        return this._isActive && !this.IsTimeOver();
    }

    /// <summary>
    /// Disable shield.
    /// </summary>
    public void DisableShield() {
        this._isActive = false;
    }
    
    /// <summary>
    /// Enable shield if timeout isn'thread expired.
    /// </summary>
    public void EnableShield() {
        this._isActive = !this.IsTimeOver();
    }
    
    /// <summary>
    /// Updates timer if shield is active.
    /// </summary>
    /// <param name="elapsedTime"></param>
    public new void UpdateTimer(double elapsedTime) {
        if (this.IsActive()) {
            base.UpdateTimer(elapsedTime);
        }
    }
}