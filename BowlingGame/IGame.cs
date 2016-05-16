namespace BowlingGame
{
    public interface IGame
    {
        void Roll(int pinsDown);
        int Score();
    }
}