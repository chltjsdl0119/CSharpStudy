using System;
using System.Threading;

namespace HorseRacing
{
    internal class Program
    {
        private const float GOAL_DISTANCE = 200.0f;
        private const int TOTAL_HORSE = 5;
        
        public static void Main(string[] args)
        {
            Horse[] horses = new Horse[TOTAL_HORSE];
            
            for (int i = 0; i < TOTAL_HORSE; i++)
            {
                horses[i] = new Horse();
                horses[i].name = $"경주마{i}";
            }

            string[] rankArray = new string[TOTAL_HORSE];
            int currentGrade = 0;
            int elapsedSec = 0;

            while (currentGrade < TOTAL_HORSE)
            {
                Console.WriteLine($"========== {elapsedSec++}초 경과 ==========");
                // 말이 달리는 내용 작성
                for (int i = 0; i < TOTAL_HORSE; i++)
                {
                    if (horses[i].distance < GOAL_DISTANCE)
                    {
                        horses[i].Run();
                        Console.WriteLine($"{horses[i].name}가 달린 거리 : {horses[i].distance}");

                        if (horses[i].distance >= GOAL_DISTANCE)
                        {
                            rankArray[currentGrade] = horses[i].name;
                            currentGrade++;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{horses[i].name}는 이미 도착함.");
                    }
                }
                
                Thread.Sleep(1000);
            }
            
            Console.WriteLine($"========== 경기 끝 ==========");
            
            for (int i = 0; i < rankArray.Length; i++)
            {
                Console.WriteLine($"{rankArray[i]} 가 {i + 1}등");
            }
        }
    }
}