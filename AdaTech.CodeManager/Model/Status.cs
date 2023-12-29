using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.CodeManager.Model
{
    public enum Status
    {
        BACKLOG = 1,
        TO_DO = 2,
        DOING = 3,
        CODE_REVIEW = 4,
        TESTING = 5,
        DONE = 6,
        DEPLOYED = 7,
        CANCELLED = 8
    }
}
