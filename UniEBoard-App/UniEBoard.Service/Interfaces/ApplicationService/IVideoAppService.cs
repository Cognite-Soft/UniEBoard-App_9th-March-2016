using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Service.Models;
using UniEBoard.Service.Models.Units;

namespace UniEBoard.Service.Interfaces.ApplicationService
{
    public interface IVideoAppService
    {

        /// <summary>
        /// Gets the video by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        VideoViewModel GetVideoById(int id);
    }
}
