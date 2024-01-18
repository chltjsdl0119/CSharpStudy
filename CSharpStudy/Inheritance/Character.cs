namespace Inheritance
{
    // 추상 멤버를 가지고 있다
    // -> 해당 멤버를 가지는 클래스가 인스턴스화 가능하다면 해당 함수를 호출할 수 있어야하는데 모순이 생긴다.
    // -> 추상 멤버를 가지고 있으면, 클래스도 마찬가지로 추상 클래스여야 한다. 
    public abstract class Character : Creature
    {
        public abstract void UniqueSkill(); // 추상 함수는 정의하지 않고 선언만 한다. // 인스턴스로 접근할 수 없다. 그러므로 클래스도 추상 클래스여야 한다.
    }
}