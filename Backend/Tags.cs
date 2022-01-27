using System.Collections.Generic;
using Backend.Database;

namespace Backend
{
    public class Tags
    {
        private string _objectId;
        private readonly List<string> _tagList;
        private readonly MongoBase _mongoBase;

        public Tags(List<string> tagList, string objectId)
        {
            _tagList = tagList;
            this._objectId = objectId;
            //_mongoBase = new MongoBase("baseName");
        }

        public void SendTagsToDb()
        {
            //_mongoBase.SendTags(_tagList); not implemented yet
        }
    }
}