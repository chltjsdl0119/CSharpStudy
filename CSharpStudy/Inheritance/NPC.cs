using System;

namespace Inheritance
{
    public class NPC : Creature
    {
        public int ID;
        public void Interaction()
        {
            Console.WriteLine("NPC와의 상호작용 시작.");
        }

        // override 재정의 키워드
        // 가상/추상 멤버를 재정의할 때 쓴다.
        public override void Breath()
        {
            Console.Write("NPC가 ");
            // base 키워드
            // 기반 타입 참조 키워드
            base.Breath();
        }
    }
}