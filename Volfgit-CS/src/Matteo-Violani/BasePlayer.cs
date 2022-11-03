using TestProject1.utility;

namespace vg.model.entity.dynamicEntity.player
{
    public class BasePlayer : IPlayer
    {
        ///Maximum player life.
        public const int PlayerMaxLife = 6;
  
        ///Default player speed.
        public static readonly V2D DefaultPlayerSpeed = new V2D(1, 1);
        
        ///Default player radius shape.
        public const int DefaultPlayerRadius = 2;

        ///Default state of capability to shoot of player.
        public const bool DefaultShootCapability = false;
        
        ///Default state of capability to shoot of player.
        public const EDirection DefaultDirection = EDirection.None;
        
        /// Life of player.
        private int _life;
        
        /// <summary>
        /// Alternative speed of Player with speed bonus improvement applied. It can be bigger or smaller than actual.
        /// This field keep saved direction and module of speed.
        /// </summary>
        private V2D? _speedImproved;

        /// Current moving direction.
        private EDirection _direction;

        /// Previous moving direction excluded when None.
        private EDirection _lastMovingDir;

        /// Tail created by player while moves in map.
        private readonly ITail _tail;
        
        /// Player shield.
        private Shield _shield;

        private bool _canShoot;
        
        /// <param name="position">starting position of player</param>
        /// <returns>Player with default life</returns>
        public static BasePlayer NewPlayer(V2D position) {
            return new BasePlayer(position, PlayerMaxLife, DefaultPlayerSpeed, Shield.Create(Shield.DefaultDuration, true));
        }
        
        /// <summary>
        /// If position is negative or greater than maximum life then is set to the maximum allowed.
        /// </summary>
        /// <param name="position">starting position</param>
        /// <param name="life">starting life of player</param>
        /// <returns>Player with user define position and life</returns>
        public static BasePlayer NewPlayer(V2D position, int life) {
            int playerLife = life < 0 || life > PlayerMaxLife ? PlayerMaxLife : life;
            return new BasePlayer(position,
                    playerLife,
                    DefaultPlayerSpeed,
                    Shield.Create(Shield.DefaultDuration, true));
        }

        private BasePlayer(V2D position, int life, V2D speed, Shield shield){
            base(position, speed, DefaultPlayerRadius, Shape.Circle, MassTier.Nocollision);
            this._life = life;
            this._tail = TailImpl.EmptyTail();
            this._shield = shield;
            this._canShoot = DefaultShootCapability;
            this._speedImproved = null;
            this._direction = DefaultDirection;
        }

        public void DecLife() {
            this._life = this._life > 0 ? this._life - 1 : 0;
            if (!this._shield.IsActive()) {
                this._shield = Shield.Create((double) Shield.DefaultDuration/2, true);
            }
        }
        
        public void IncLife() {
            this._life = _life + 1;
        }
        
        public int GetLife() {
            return this._life;
        }

        public ITail GetTail() {
            return this._tail;
        }

        ITail IPlayer.GetTail()
        {
            return this._tail;
        }

        public void SetShield(Shield shield) {
            this._shield = shield;
        }

        public Shield GetShield() {
            return this._shield;
        }

        public void ChangeDirection(EDirection dir, bool isOnBorder) {
            if (_lastMovingDir == null) {
                _lastMovingDir = dir;
            }
            if (!isOnBorder && ((_lastMovingDir == EDirection.Down && dir == EDirection.Up)
                    || (_lastMovingDir == EDirection.Up && dir == EDirection.Down)
                    || (_lastMovingDir == EDirection.Left && dir == EDirection.Right)
                    || (_lastMovingDir == EDirection.Right && dir == EDirection.Left))
            ) {
                this._direction = EDirection.None;
            } else {
                this._direction = dir;
                if (dir != EDirection.None) {
                    _lastMovingDir = dir;
                }
            }
        }

        public EDirection GetDirection()
        {
            return this._direction;
        }
        
        public void Move() {
            V2D newPos = this.GetPosition().Sum(this.GetSpeed().Mul(Direction.GetVector(this._direction)));
            if (!this._tail.GetCoordinates().Contains(newPos)) {
                this.SetPosition(newPos);
            }
        }

        public void EnableSpeedUp(V2D speed)
        {
            /*
            * In order to not change direction of move by speed vector
            * is checked if coordinates are negative
            */
            if (!this._speedImproved.HasValue && speed.X >= 0 && speed.Y > 0) {
                this._speedImproved = this.GetSpeed().Sum(speed);
            }
        }
        
        public void DisableSpeedUp() {
            this._speedImproved = null;
        }

        public bool CanShoot() {
            return this._canShoot;
        }
        
        public void EnableShoot() {
            this._canShoot = true;
        }
        
        public void DisableShoot() {
            this._canShoot = false;
        }

        public V2D GetSpeed() {
            // if speedUp is set return it else return original speed
            if (this._speedImproved.HasValue) {
                return _speedImproved.Value;
            } else {
                return base.GetSpeed();
            }
        }
        
        public void AfterCollisionAction(MassTier other) {
            base.afterCollisionAction(other);
            if (this.GetMassTier().compareTo(other) > MassTier.Nocollision.ordinal()) {
                DecLife();
            }
        }

    }
}