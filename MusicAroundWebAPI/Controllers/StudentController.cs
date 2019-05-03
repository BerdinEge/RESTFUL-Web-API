using MusicAroundWebAPI.Models;
using Newtonsoft.Json.Linq;
using RethinkDb.Driver;
using RethinkDb.Driver.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicAroundWebAPI.Controllers
{
    public class StudentController : ApiController
    {
        public static RethinkDB R = RethinkDB.R;

        public IHttpActionResult PostNewUserModel(StudentViewModel studentViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var conn = connection();

            /*var newUserModel = new UserModel
            {
                UserId = userModel.UserId,
                Name = userModel.Name,
                UserName = userModel.UserName,
                Bio = userModel.Bio,
                ImageUrl = userModel.ImageUrl,
                LastArtist = userModel.LastArtist,
                LastSong = userModel.LastSong,
                LastLocation_Lat = userModel.LastLocation_Lat,
                LastLocation_Lng = userModel.LastLocation_Lng,
                LastOnline = userModel.LastOnline
            };*/

            var newStudentViewModel = new StudentViewModel
            {
                FirstName  = studentViewModel.FirstName,
                Id = studentViewModel.Id,
                LastName = studentViewModel.LastName
            };

            R.Db("MusicAroundDB").Table("pkDeneme").Insert(newStudentViewModel).Run(conn);


            return Ok();
        }

        public IHttpActionResult GetAllStudents()
        {
            var conn = connection();
            JArray result = R.Db("MusicAroundDB").Table("pkDeneme").OrderBy("id").Run(conn);


            IList<StudentViewModel> students = result.ToObject<List<StudentViewModel>>();


            if (students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }
        /*
        public IHttpActionResult DeleteUserModel(int id)
        {
            if (id < 0)
                return BadRequest("Not a valid student id");

            var conn = connection();

            R.Db("test").Table("UserModel").Get(id).Delete().Run(conn);


            return Ok();
        }*/

        public IHttpActionResult Deleteprimarykeydeneme(int id)
        {
            if (id < 0)
                return BadRequest("Not a valid student id");

            var conn = connection();

            R.Db("test").Table("primarykeydeneme").Get(id).Delete().Run(conn);


            return Ok();
        }

        public IHttpActionResult Put(UserModel userModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var conn = connection();

            var existingUserModel = R.Db("test").Table("UserModel").Get(userModel.UserId).Run(conn);

            if (existingUserModel != null)
            {
                R.Db("test").Table("UserModel").Get(userModel.UserId).Update(R.HashMap("Bio", userModel.Bio.ToString())).Run(conn);
            }
            else
            {
                return NotFound();
            }


            return Ok();
        }

        public static Connection connection()
        {
            var conn = R.Connection()
                     .Hostname("localhost")
                     .Port(RethinkDBConstants.DefaultPort)
                     .Timeout(60)
                     .Connect();
            
            return conn;
        }

    }
}
