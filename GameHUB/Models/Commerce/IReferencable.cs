using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Core;

namespace GameHUB.Models.Commerce
{
    public interface IReferencable
    {
        ContentReference GetGameReference();
    }
}
