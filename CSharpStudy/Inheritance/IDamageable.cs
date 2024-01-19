namespace Inheritance
{
    // interface
    // 멤버들의 접근 제한자는 기본적으로 public.
    public interface IDamageable
    {
        float hp { get; set; }
        void Damage(float amount);
    }
}