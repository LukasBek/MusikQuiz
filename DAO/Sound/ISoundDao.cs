using MusikQuiz.Models;

namespace MusikQuiz.DAO
{
    interface ISoundDao
    {
        Sound AddSound(Sound sound);
        Sound GetSound(string soundId);
        void UpdateSound(string soundId, Sound newSound);
        void DeleteSound(string soundId);
    }

    /**
     *     public class Sound
    {
        public string Id { get; set; }
        public QuestionNumber QuestionNumber { get; set; }
        public string SongName { get; set; }
        public string Artist { get; set; }
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string AudioLink { get; set; }
        public Provider Provider { get; set; }
    }
     */
}
