namespace vg.model.entity.dynamicEntity.player
{
    public class BasePlayer : IPlayer
    {
        ///Maximum player life.
        public const int PLAYER_MAX_LIFE = 6;
  
        ///Default player speed.
        public const V2D DEFAULT_PLAYER_SPEED = new V2D(1, 1);
        
        ///Default player radius shape.
        public const int DEFAULT_PLAYER_RADIUS = 2;

        ///Default state of capability to shoot of player.
        public const bool DEFAULT_SHOOT_CAPABILITY = false;
        
        ///Default state of capability to shoot of player.
        const Direction DEFAULT_DIRECTION = Direction.NONE;
        
        /// Life of player.
        private int _life;
        
        /// <summary>
        /// Alternative speed of Player with speed bonus improvement applied. It can be bigger or smaller than actual.
        /// This field keep saved direction and module of speed.
        /// </summary>
        private Optional<V2D> speedImproved;

        /// Current moving direction.
        private Direction direction;

        /// Previous moving direction excluded when NONE.
        private Direction lastMovingDir;

        /// Tail created by player while moves in map.
        private Tail tail;
        
        /// Player shield.
        private Shield shield;

        private bool canShoot;
        
        /// <param name="position">starting position of player</param>
        /// <returns>Player with default life</returns>
        public static BasePlayer NewPlayer(V2D position) {
            return new BasePlayer(position, PLAYER_MAX_LIFE, DEFAULT_PLAYER_SPEED, Shield.create(Shield.DEFAULT_DURATION, true));
        }
        
        /// <summary>
        /// If position is negative or greater than maximum life then is set to the maximum allowed.
        /// </summary>
        /// <param name="position">starting position</param>
        /// <param name="life">starting life of player</param>
        /// <returns>Player with user define position and life</returns>
        public static BasePlayer NewPlayer(V2D position, int life) {
            int playerLife = life < 0 || life > PLAYER_MAX_LIFE ? PLAYER_MAX_LIFE : life;
            return new BasePlayer(position,
                    playerLife,
                    DEFAULT_PLAYER_SPEED,
                    Shield.create(Shield.DEFAULT_DURATION, true));
        }

        private BasePlayer(V2D position, int life, V2D speed, Shield shield) {
            super(position, speed, DEFAULT_PLAYER_RADIUS, Shape.CIRCLE, MassTier.NOCOLLISION);
            this._life = life;
            this.tail = TailImpl.emptyTail();
            this.shield = shield;
            this.canShoot = DEFAULT_SHOOT_CAPABILITY;
            this.speedImproved = Optional.absent();
            this.direction = DEFAULT_DIRECTION;
        }

        public void DecLife() {
            this._life = this.life > 0 ? this.life - 1 : 0;
            if (!this.shield.isActive()) {
                this.shield = Shield.create((double) Shield.DEFAULT_DURATION/2, true);
            }
        }
        
        public void IncLife() {
            this._life = this.life + 1;
        }
        
        public int GetLife() {
            return this._life;
        }
        
        public Tail GetTail() {
            return this.tail;
        }

        public void SetShield(Shield shield) {
            this.shield = shield;
        }

        public Shield GetShield() {
            return this.shield;
        }
        
        public void ChangeDirection(Direction dir, boolean isOnBorder) {
            if (lastMovingDir == null) {
                lastMovingDir = dir;
            }
            if (!isOnBorder && ((lastMovingDir == Direction.DOWN && dir == Direction.UP)
                    || (lastMovingDir == Direction.UP && dir == Direction.DOWN)
                    || (lastMovingDir == Direction.LEFT && dir == Direction.RIGHT)
                    || (lastMovingDir == Direction.RIGHT && dir == Direction.LEFT))
            ) {
                this.direction = Direction.NONE;
            } else {
                this.direction = dir;
                if (dir != Direction.NONE) {
                    lastMovingDir = dir;
                }
            }
        }

        public Direction GetDirection()
        {
            return this.direction;
        }
        
        public void Move() {
            V2D newPos = this.getPosition().sum(this.getSpeed().mul(this.direction.getVector()));
            if (!this.tail.getCoordinates().contains(newPos)) {
                setPosition(newPos);
            }
        }

        public void EnableSpeedUp(V2D speed) {
            /*
            * In order to not change direction of move by speed vector
            * is checked if coordinates are negative
            */
            if (!this.speedImproved.isPresent() && speed.getX() >= 0 && speed.getY() > 0) {
                this.speedImproved = Optional.of(this.getSpeed().sum(speed));
            }
        }
        
        public void DisableSpeedUp() {
            this.speedImproved = Optional.absent();
        }

        public bool CanShoot() {
            return this.canShoot;
        }
        
        public void EnableShoot() {
            this.canShoot = true;
        }
        
        public void DisableShoot() {
            this.canShoot = false;
        }

        public V2D GetSpeed() {
            // if speedUp is set return it else return original speed
            if (this.speedImproved.isPresent()) {
                return speedImproved.get();
            } else {
                return super.GetSpeed();
            }
        }
        
        public void AfterCollisionAction(MassTier other) {
            super.afterCollisionAction(other);
            if (this.GetMassTier().compareTo(other) > MassTier.NOCOLLISION.ordinal()) {
                DecLife();
            }

        }

    }
}