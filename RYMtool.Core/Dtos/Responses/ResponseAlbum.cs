using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RYMtool.Core.Dtos.Responses
{
    public class ResponseAlbum : Response
    {
        public AlbumListReviewDto? Album { get; set; }
    }
}
