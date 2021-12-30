using App.Core.DTOs;
using App.Core.Models;
using App.Core.Services;
using App.Database.DbContext;
using App.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeGenerator.API.Repository
{
    public class ResumeRepository : IResumeRepository
    {
        //private readonly IDataContext dataContext;
        private readonly AppConfigurations appConfigurations;
        private readonly PostmarkService postmarkService;
        public ResumeRepository(PostmarkService postmarkService, AppConfigurations appConfigurations)
        {
            //dataContext = new DataContext(appConfigurations.ConnectionString);
            this.appConfigurations = appConfigurations;
            this.postmarkService = postmarkService;
        }


        public async void SendMail(ResumeDto resumeDto)
        {
            try
            {
                var response = await postmarkService.SendEmail();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
