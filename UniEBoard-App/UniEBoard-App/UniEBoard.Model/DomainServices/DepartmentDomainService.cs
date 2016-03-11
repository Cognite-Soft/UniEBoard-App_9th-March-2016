using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Factories;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Model.Interfaces.Repository;

namespace UniEBoard.Model.DomainServices
{
    public class DepartmentDomainService : BaseDomainService<Department, IDepartmentRepository>, IDepartmentDomainService
    {
        #region Properties

        /// <summary>
        /// Department Repository Instance
        /// </summary>
        public IDepartmentRepository DepartmentRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseDomainService"/> class.
        /// </summary>
        /// <param name="courseRepository">The course repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public DepartmentDomainService(IDepartmentRepository departmentRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(departmentRepository, exceptionManager, loggingService)
        {
            DepartmentRepository = departmentRepository;
        }

        #endregion

        /// <summary>
        /// Finds all Department registration.
        /// </summary>
        /// <returns>List of all Department registrations.</returns>
        IQueryable<Department> FindAll(List<string> associations)
        {
            return DepartmentRepository.FindAll(associations);
        }
    }
}
