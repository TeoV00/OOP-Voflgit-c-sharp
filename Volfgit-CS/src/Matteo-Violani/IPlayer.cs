
using vg.utility;

namespace vg.model.entity.dynamicEntity.player
{
    public interface IPlayer : IEntity
    {
        /// <summary>
        /// Decrement player's life of one unit.
        /// If shield has expired, create new shield with half of previous one.
        /// </summary>
        void DecLife();
         
        /// <summary>
        ///Increment player's life of one unit but not over maximum value.
        ///</summary>
        void IncLife();
            
        /// <summary>
        /// Get current player's life.
        /// </summary>
        /// <returns>numeric value of player's life</returns>
        int GetLife();

        /// <summary>
        /// Enable or change current player speed with new one.
        /// </summary>
        /// <param name="speed">Vector that represent speed</param>
        void EnableSpeedUp(V2D speed);
        
        /// <summary>
        /// Disable speed improvement if enabled.
        /// </summary>
        void DisableSpeedUp();
        
        /// <summary>
        /// Return true if player can shoot.
        /// </summary>
        /// <returns>true if player can shoot, false if not</returns>
        bool CanShoot();

        /// <summary>
        /// Enable player capability to shoot.
        /// </summary>
        void EnableShoot();
        
        /// <summary>
        /// Disable player capability to shoot if enabled.
        /// </summary>
        void DisableShoot();

        /// <summary>
        /// Move player to new position coordinate in congruence to current direction.
        /// This method overrides the one of superclass {@link DynamicEntity#move()} but its logic is totally different.
        /// The player needs to move depending on direction and the speed
        /// (that in player represent only the module of movement).
        /// </summary>
        void Move();
        
        /// <summary>
        /// Change player's moving direction
        /// </summary>
        /// <param name="direction">new direction</param>
        /// <param name="isOnBorder">flag if player is on border</param> 
        void ChangeDirection(EDirection direction, bool isOnBorder);

        /// <summary>
        /// Current player direction.
        /// </summary>
        /// <returns>Direction</returns>
        EDirection GetDirection();

        /// <summary>
        /// Get player tail.
        /// </summary>
        /// <returns>Tail of player</returns> 
        ITail GetTail();

        /// <summary>
        /// Set new player's shield.
        /// </summary>
        /// <param name="shield">new Shield</param>
        void SetShield(Shield shield);

        /// <summary>
        /// Get current player's shield.
        /// </summary>
        /// <returns>Player's shield</returns> 
        Shield GetShield();

        /// <summary>
        /// Get player speed.
        /// </summary>
        /// <returns>vector which coordinates are in absolute value</returns> 
        V2D GetSpeed();
    }
}
