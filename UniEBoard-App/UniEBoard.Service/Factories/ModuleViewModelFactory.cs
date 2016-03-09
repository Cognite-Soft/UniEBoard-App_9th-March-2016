using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Service.Models;
using UniEBoard.Service.Models.Quizzes;

namespace UniEBoard.Service.Factories
{
    public class ModuleViewModelFactory
    {
        #region Methods

        /// <summary>
        /// Creates the course view models.
        /// </summary>
        /// <param name="courses">The courses.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static List<ModuleViewModel> CreateModuleViewModels(List<Module> modules, IObjectMapperAdapter objectMapper)
        {
            List<ModuleViewModel> moduleModels = new List<ModuleViewModel>();
            foreach (Module moduleItem in modules)
            {
                ModuleViewModel moduleViewModel = objectMapper.Map<Model.Entities.Module, ModuleViewModel>(moduleItem);

                moduleModels.Add(moduleViewModel);
            }

            return moduleModels;
        }


        /// <summary>
        /// Creates the course view models.
        /// </summary>
        /// <param name="course">The course.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static ModuleViewModel CreateModuleViewModels(Module module, IObjectMapperAdapter objectMapper)
        {
            ModuleViewModel moduleViewModel = objectMapper.Map<Model.Entities.Module, ModuleViewModel>(module);
            moduleViewModel.Quizzes = new List<QuizzesViewModel>();
            moduleViewModel.Units = new List<UnitViewModel>();

            foreach (ModuleQuiz moduleQuizItem in module.ModuleQuizs)
            {
                if (moduleQuizItem.Quiz != null)
                {
                    moduleViewModel.Quizzes.Add(objectMapper.Map<Model.Entities.Quiz, QuizzesViewModel>(moduleQuizItem.Quiz));
                }
            }

            foreach (Unit unitItem in module.Units)
            {
                moduleViewModel.Units.Add(objectMapper.Map<Model.Entities.Unit, UnitViewModel>(unitItem));
            }

            return moduleViewModel;
        }



        #endregion
    }
}
