using System.Linq;
using MusikQuiz.Data;
using MusikQuiz.Models;

namespace MusikQuiz.DAO
{
    public class SoundDao : ISoundDao
    {
        private readonly ApplicationDbContext _context;

        public SoundDao(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public Sound AddSound(Sound sound)
        {
            _context.Add(sound);
            _context.SaveChanges();

            return sound;
        }

        public Sound GetSound(string soundId)
        {
            return _context.Sound.SingleOrDefault(x => x.Id.Equals(soundId));
        }

        public void UpdateSound(string soundId, Sound newSound)
        {
            var sound = GetSound(soundId);
            sound = newSound;

            _context.SaveChanges();
        }

        public void DeleteSound(string soundId)
        {
            var sound = GetSound(soundId);

            _context.Sound.Remove(sound);
            _context.SaveChanges();
        }
    }
}
