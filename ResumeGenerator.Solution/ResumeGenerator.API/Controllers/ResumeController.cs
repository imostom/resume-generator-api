using App.Core.DTOs;
using App.Core.Models;
using App.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResumeGenerator.API.Repository;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeGenerator.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly IResumeRepository repository;
        private readonly AppConfigurations appConfigurations;
        private readonly PostmarkService postmark;

        public ResumeController(IResumeRepository repository)//, AppConfigurations appConfigurations, PostmarkService postmark)
        {
            //this.postmark = postmark;
            this.repository = repository;
            //this.appConfigurations = appConfigurations;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "GENERATE", Description = "This endpoint generates and sends the resume to user's email")]
        public async Task<ActionResult> GenerateAsync(ResumeDto resumeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Object Supplied");

            repository.SendMail(resumeDto);

            await Task.Delay(2000);
            return Ok();
        }
    }
}
