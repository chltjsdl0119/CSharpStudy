using System;

namespace Inheritance
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Creature creature1 = new Creature();
            // creature1.Breath();

            NPC npc1 = new NPC();
            npc1.Breath();
            npc1.Interaction();
            
            // !중요함! 공변성 : 하위 타입을 기반 타입으로 참조할 수 있는 성질.
            Creature creature2 = new NPC();
            // NPC npc2 = new Creature(); // 인스턴스 멤버 함수 호출 시. caller(this)에 인스턴스 참조를 넘겨주는데, 기반 타입 객체를 넘겨주면 할당되지 않은 멤버에 접근하게되므로 불가능하다.
            creature2.Breath();
            // creature2.Interaction(); // 객체가 어떤 멤버들을 가지고 있던지, 참조 변수 타입에 따라 멤버 접근이 가능하다.
            
            // npc2.Interaction();

            Character[] characters = { new Knight(), new Magicain(), new SwordMan() };

            for (int i = 0; i < characters.Length; i++)
            {
                characters[i].UniqueSkill();

                if (characters[i] is Knight)
                {
                    Console.WriteLine("기사 발견");
                }
            }
        }
    }
}