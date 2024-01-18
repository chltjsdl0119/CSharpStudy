using System;

namespace Inheritance
{
    public class Knight : Character
    {
        public override void UniqueSkill()
        {
            Console.WriteLine("Knight 소유 스킬 발동");
        }
    }
}