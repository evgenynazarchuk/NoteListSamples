using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteList.Services;
using System.Linq;

namespace NoteList.Services
{
    public class NoteImageRepository : Repository<NoteImage>
    {
        public NoteImageRepository(
            DataWriteContext dbWrite,
            DataReadContext dbRead
            )
            : base(dbWrite, dbRead)
        { }
    }
}
