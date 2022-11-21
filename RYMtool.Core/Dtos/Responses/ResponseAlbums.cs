using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RYMtool.Core.Dtos.Responses
{
    public class ResponseAlbums : Response
    {
        public IEnumerable<AlbumDto>? Albums { get; set; }
    }
}
