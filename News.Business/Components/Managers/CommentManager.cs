using News.Business.IDataProviders;
using News.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Business.Components.Managers
{
    public class CommentManager : BaseManager<Comment, ICommentDataProvider>
    {
        public CommentManager(ICommentDataProvider provider) : base(provider) { }

        public IList<Comment> GetByEventId(string id)
        {
            return provider.GetByTidingId(id);
        }
    }
}
