using System;

namespace Inheritance
{
    // abstract : 추상 키워드
    // 추상화 용도로 사용한다는 것을 명시하는 키워드이고, 동적 할당 불가능하는 얘기다.
    public abstract class Creature
    {
        public int DNAcode;
        
        // virtual 가상 키워드
        // 함수를 자식이 재정의할 수 있게 하는 키워드
        public virtual void Breath()
        {
            Console.WriteLine("숨쉬기.");
        }
    }
}