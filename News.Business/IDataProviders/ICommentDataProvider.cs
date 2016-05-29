using News.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Business.IDataProviders
{
    public interface ICommentDataProvider : IDataProvider<Comment>
    {
        IList<Comment> GetByTidingId(string eventId);
    }
}
