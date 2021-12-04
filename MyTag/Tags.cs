using System.Collections.Generic;
using MyTag.Database;

namespace MyTag
{
    public class Tags
    {
        private readonly List<string> _tagList;
        private readonly MongoBase _mongoBase;

        public Tags(List<string> tagList)
        {
            _tagList = tagList;
            _mongoBase = new MongoBase("baseName");
        }

        public void SendTagsToDb()
        {
            _mongoBase.SendTags(_tagList);
        }
    }
}