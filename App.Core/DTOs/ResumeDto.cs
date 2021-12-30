using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Core.DTOs
{
    public class ResumeDto
    {
        
        public BioDataDto BioData { get; set; }
        //public Socials Socials { get; set; }
        public List<GenericType> Socials { get; set; }
        public List<string> Tools { get; set; }
        public List<string> Competencies { get; set; }
        public List<SkillsDto> Skills { get; set; }
        public EducationDto Education { get; set; }
        public WorkExperienceDto WorkExperience { get; set; }
        public CertificationsTrainingsDto CertificationsTrainings { get; set; }
    }

    public class BioDataDto
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string Othername { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        [Required]
        public string PhoneNumbers { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Summary { get; set; }
    }

    public class CertificationsTrainingsDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class SkillsDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Range(1, 100)]
        public int Rating { get; set; }
    }

    public class WorkExperienceDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string CompanyNme { get; set; }
        public List<string> Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public bool IsCurrent { get; set; }
    }

    public class EducationDto
    {
        public string Degree { get; set; }
        public string SchoolName { get; set; }
        public string Achievements { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public bool IsCurrent { get; set; }
    }

    public class GenericType
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
