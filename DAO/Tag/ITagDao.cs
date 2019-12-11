using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusikQuiz.Models;

namespace MusikQuiz.DAO
{
    interface ITagDao
    {
        Tag getTag(string tagId);
        Tag addTag(Tag Tag);
        void deleteTag(string tagId);
        void updateTag(string tagId, string tagName);
        List<Tag> AllTags();
    }
}
