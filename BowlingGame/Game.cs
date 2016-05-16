using System.Collections.Generic;

namespace BowlingGame
{
    public class Game : IGame
    {
        private List<int> rolls = new List<int>(21);
        private int currentRoll = 0;
        public Game()
        {
            for (int i = 0; i < 22; i++)
            {
                rolls.Add(0);
            }
        }
        public void Roll(int pinsDown)
        {
            rolls[currentRoll++] = pinsDown;

        }

        public int Score()
        {
            
                int score = 0;
                int frameIndex = 0;
                for (int frame = 0; frame < 10; frame++)
                {
                    if (IsStrike(frameIndex))
                    {
                        score += 10 + BonusForStrike(frameIndex);
                        frameIndex++;
                    }
                    else if (IsSpare(frameIndex))
                    {
                        score += 10 + BonusForSpare(frameIndex);
                        frameIndex += 2;
                    }
                    else
                    {
                        score += NormalCase(frameIndex);
                        frameIndex += 2;
                    }

                }
                return score;
           
        }

        private int NormalCase(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }

        private int BonusForSpare(int frameIndex)
        {
            return rolls[frameIndex + 2];
        }

        private int BonusForStrike(int frameIndex)
        {
            return rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        private bool IsStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }

        private bool IsSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }
    }
}