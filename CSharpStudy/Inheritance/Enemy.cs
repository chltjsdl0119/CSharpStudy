namespace Inheritance
{
    public abstract class Enemy : Creature, IDamageable
    {
        public float hp
        {
            get
            {
                return _hp;
            }
            set
            {
                if (value < 0)
                    value = 0;
                _hp = value;
            }
        }
        private float _hp;

        public void Damage(float amount)
        {
            hp -= amount;
        }
    }
}