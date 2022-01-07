using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingLeaderboard
{
    /// <Task>
    /// An arcade game player wants to climb to the top of the leaderboard and track their ranking. 
    /// The game uses Dense Ranking, so its leaderboard works like this:
    /// The player with the highest score is ranked number  on the leaderboard.
    /// Players who have equal scores receive the same ranking number, and the next player(s) receive the immediately following ranking number.
    /// </Task>
    public class ClimbingTheLeaderboard
    {
        public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
        {
            List<int> ranks = new List<int>();
            ranked = ranked.Distinct().ToList();

            foreach (int i in player)
            {
                int position = 0;

                if (BinSearch(ranked, i, 0, ranked.Count - 1, ref position) < 0)
                    if (i < ranked[ranked.Count - 1])
                        position = ranked.Count;

                ranks.Add(position + 1);
            }

            return ranks;
        }

        public static int BinSearch(List<int> ranked, int target, int start, int end, ref int position)
        {
            if (end < start)
                return -1;

            else
            {
                int mid = (start + end) / 2;

                if (ranked[mid] == target)
                {
                    position = mid;
                    return mid;
                }
                else if (ranked[mid] > target)
                {
                    position = mid + 1;
                    return BinSearch(ranked, target, mid + 1, end, ref position);
                }
                else
                {
                    return BinSearch(ranked, target, start, mid - 1, ref position);
                }
            }
        }
    }
}
