namespace vg.model.timedObject;

public interface ITimedObject
{
    /// <summary>
    /// True if timeout expired.
    /// </summary>
    /// <returns>True if timeout expired.</returns>
    Boolean IsTimeOver();

    /// <summary>
    /// Call this method in order to update timer of bonus.
    /// </summary>
    /// <param name="elapsedTime">
    /// time elapsed from previous game loop cycle to current one
    /// </param>
    void UpdateTimer(double elapsedTime);

    /// <returns>remaining time of timer</returns>
    double GetRemainingTime();

}