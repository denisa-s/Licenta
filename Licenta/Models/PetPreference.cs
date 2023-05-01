using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class PetPreference
    {
        public string Question { get; set; }
        public List<string> Choices { get; set; }
        public List<int> Scores { get; set; }

        public int GetScoreForAnswer(string answer)
        {
            int index = Choices.IndexOf(answer);
            return Scores[index];
        }
    }

}
