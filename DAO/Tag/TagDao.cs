using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusikQuiz.Data;
using MusikQuiz.Models;

namespace MusikQuiz.DAO
{
    public class TagDao : ITagDao
    {
        private readonly ApplicationDbContext _context;

        public TagDao(ApplicationDbContext context)
        {
            _context = context;
        }

        public Tag getTag(string tagId)
        {
            var tag = _context.Tag.SingleOrDefault(x => x.Id == tagId);
            return tag;
        }


        public Tag addTag(Tag tag)
        {
            _context.Add(tag);
            _context.SaveChanges();

            return tag;
        }

        public void deleteTag(string tagId)
        {
            var tag = getTag(tagId);

            _context.Tag.Remove(tag);
            _context.SaveChanges();
        }

        public void updateTag(string tagId, string tagName)
        {
            var tag = getTag(tagId);
            tag.Name = tagName;

            _context.SaveChanges();

        }

        public List<Tag> AllTags()
        {
            var allTags = _context.Tag.ToList();

            return allTags;

        }
    }
}
