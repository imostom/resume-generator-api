using App.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeGenerator.API.Repository
{
    public interface IResumeRepository
    {
        void SendMail(ResumeDto resumeDto);
    }
}
