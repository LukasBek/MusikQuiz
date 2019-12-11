using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProviderEnum;
using QuestionNumberEnum;

namespace MusikQuiz.DTO
{
    public class SoundDto
    {
        public QuestionNumber QuestionNumber { get; set; }
        public string SongName { get; set; }
        public string Artist { get; set; }
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string AudioLink { get; set; }
        public Provider Provider { get; set; }
    }
}
