using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Service.Interfaces.ApplicationService;
using UniEBoard.Service.Models;

namespace UniEBoard.Service.ApplicationServices
{
    public class VideoAppService: BaseAppService, IVideoAppService
    {
        private IVideoDomainService _iVideoDomainService;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitModuleAppService"/> class.
        /// </summary>
        /// <param name="unitManager">The unit manager.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="cacheService">The cache service.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public VideoAppService(
           
            IObjectMapperAdapter objectMapper,
            ICacheAdapter cacheService,
            IExceptionManagerAdapter exceptionManager,
            ILoggingServiceAdapter loggingService,
            IVideoDomainService iVideoDomainService)
            : base(objectMapper, cacheService, exceptionManager, loggingService)
        {
            _iVideoDomainService = iVideoDomainService;
        }

        #endregion


        #region IVideoAppService Members

        public Models.VideoViewModel GetVideoById(int id)
        {
            return ObjectMapper.Map<Model.Entities.Video, VideoViewModel>(_iVideoDomainService.FindVideoById(id));
        }

        #endregion
    }
}
