namespace Strategy
{
    // 전략 패턴의 인터페이스
    public interface IManeuverBehaviour
    {
        void Maneuver(Drone drone);
    }
}