using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer.Web.Mvc;
using GameHUB.Models.Blocks;

namespace GameHUB.Controllers
{
    public class TwitchBlockController : BlockController<TwitchBlock>
    {
        public override ActionResult Index(TwitchBlock currentBlock)
        {
            return PartialView(currentBlock);
        }
    }
}