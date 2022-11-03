namespace vg.model.entity.dynamicEntity.player;

public class TimedObject : ITimedObject
{
    /// <summary>
    /// Time durationMillis of bonus.
    /// </summary>
    private double _duration;

    public TimedObject(double duration) {
        this._duration = duration;
    }

    public bool IsTimeOver() {
        return _duration <= 0;
    }

    public double GetRemainingTime() {
        return this._duration;
    }
    
    public void UpdateTimer(double elapsedTime) {
        if (!this.IsTimeOver() && elapsedTime < _duration) {
            this._duration = this._duration - elapsedTime;
        } else if (!this.IsTimeOver() && elapsedTime >= _duration) {
            this._duration = 0;
        }
    }
}