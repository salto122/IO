using System.Collections.Generic;
using MyTag.Database;

namespace MyTag
{
    public class Tags
    {
        private List<string> TagList;
        private MongoBase _mongoBase;

        public Tags(List<string> tagList)
        {
            TagList = tagList;
            _mongoBase = new MongoBase("baseName");
        }

        public void SendTagsToDB()
        {
            _mongoBase.SendTags(TagList);
        }
    }
}