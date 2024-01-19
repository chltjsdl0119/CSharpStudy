namespace Inheritance
{
    // 추상 멤버를 가지고 있다
    // -> 해당 멤버를 가지는 클래스가 인스턴스화 가능하다면 해당 함수를 호출할 수 있어야하는데 모순이 생긴다.
    // -> 추상 멤버를 가지고 있으면, 클래스도 마찬가지로 추상 클래스여야 한다. 
    public abstract class Character : Creature, IDamageable
    {
        // 프로퍼티
        // get, set 접근자
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
                
                if (_hp == value)
                    return;
                        
                _hp = value;
                
                // if (onHpChanged != null)
                //     onHpChanged(value); // 직접 호출

                onHpChanged?.Invoke(value); // 간접 호출 // ? : null check 연산자. null이면 실행 안 한다.
            }
        }
        private float _hp;

        public delegate void HpChangedHandler(float value);
        public event HpChangedHandler onHpChanged; // event 한정자 : 대리자의 접근 제한을 위한 한정자, (+=/-=, 구독/구독취소)는 외부 클래스에서 접근 가능. = 은 접근 불가능
        // 구독에 대한 표현은 여러 가지다. : Resister, Observe, Listen, Subscribe = 다 같은 말
        // event를 호출한다는 표현 : Notify = 구독자들에게 알림 통지
        
        
        
        // public float GetHp()
        // {
        //     return _hp;
        // }
        // public void SetHp(float value)
        // {
        //     if (value < 0)
        //         value = 0;
        //     _hp = value;
        // }
        public abstract void UniqueSkill(); // 추상 함수는 정의하지 않고 선언만 한다. // 인스턴스로 접근할 수 없다. 그러므로 클래스도 추상 클래스여야 한다.
        public void Damage(float amount)
        {
            hp -= amount; // == hp = hp - amount;
        }
    }
}