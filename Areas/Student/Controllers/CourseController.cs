using Learnix.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Learnix.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = "Student")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }



        public async Task<IActionResult> Enroll(int id)
        {
            var crs = _courseService.GetById(id);
            if (crs == null)
                return View("NotFound");

            Claim IDClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            //bool result = await _courseService.EnrollInCourse(id, IDClaim.Value);

            //if (result)
            //{
            //    return RedirectToAction("Index", "Student");
            //    //return Content("Enrolled Successfully");
            //}
            //else
            //{
            //    return View("FailEnroll");
            //}



            var result = await _courseService.EnrollInCourse(id, IDClaim.Value);

            if (!result.Success)
            {
                if (result.Reason == "Student is already enrolled in this course")
                {
                    ViewBag.FailMsg = "You already Enrolled in this Course";
                    return View("FailEnroll");
                }
                else if (result.Reason == "Insufficient balance")
                {
                    ViewBag.FailMsg = "Your Balance is Insufficient";
                    return View("FailEnroll");
                }
                else
                {
                    ViewBag.FailMsg = "Unfortunately, we couldn't complete your enrollment. Please try again later or contact support if the problem persists.";
                    return View("FailEnroll");
                }

            }
            else
            {
                return RedirectToAction("Index", "Student");
            }
        }
    }
}
