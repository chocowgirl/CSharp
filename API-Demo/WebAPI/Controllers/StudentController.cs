using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> _list = new List<Student>()
        {
            new Student() {Student_Id= 1, First_Name ="Charifa", Last_Name = "Znifech" },
            new Student() {Student_Id= 2, First_Name ="Khaoula", Last_Name = "Ayari" },
            new Student() {Student_Id= 3, First_Name ="Jessica", Last_Name = "Conrad" },
            new Student() {Student_Id= 4, First_Name ="Mélusine", Last_Name = "Christophe" },
            new Student() {Student_Id= 5, First_Name ="Dorothée", Last_Name = "Valentyn" },
            new Student() {Student_Id= 6, First_Name ="Jenny", Last_Name = "Fernandez Garcia" },
            new Student() {Student_Id= 7, First_Name ="Marwa", Last_Name = "Chanu" },
            new Student() {Student_Id= 8, First_Name ="Anaïs", Last_Name = "Aerts" },
            new Student() {Student_Id= 9, First_Name ="Amalia", Last_Name = "Langlet Tessaro" },
            new Student() {Student_Id= 10, First_Name ="Leslie", Last_Name = "Habimana" },
            new Student() {Student_Id= 11, First_Name ="Debby", Last_Name = "Clerckx" },
            new Student() {Student_Id= 12, First_Name ="Emilie", Last_Name = "Blanckaert" },
        };


        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            List<Student> model = _list;
            return Ok(model); // Ok is equivalent to 200
        }

        [HttpGet("{id}")]//this avoids routing conflict for the get.  When we execute we will input the value (number) of student id we are looking for, so 12 for Emilie
        //essentially what is in the "{}" is the parameter of the action
        //and
        [ProducesResponseType<Student>(200)] 
        [ProducesResponseType(404)] //this can also be typed as [ProducesResponseType(int(HttpResponse.NotFound))]
        //No need to add <Student> to the 404 since it returns nothing
        public IActionResult Get(int id)
        {
            Student model = _list.Where(st => st.Student_Id == id).SingleOrDefault();
            if (model is not null) {
                return Ok(model);
            }
            return NotFound(); // returns a 404 code
            //return StatusCode(404); //same as above said differently
        }



        [HttpPost]
        [ProducesResponseType<Student>(201)] //response meaning that the thing was created
        [ProducesResponseType(415)] //response meaning that the expected input was not satisfied
        public IActionResult Post(Student student)
        {
            try
            {
                if (student.Last_Name == "string" || student.First_Name == "string") throw new ArgumentException(nameof(student));
                int id = _list.Max(st => st.Student_Id) + 1; //this part is b/c we don't have an autoincrementing db
                student.Student_Id = id;
                _list.Add(student);
                return CreatedAtAction(nameof(Get), new { id }, student);
            }
            catch (Exception)
            {
                return StatusCode(415);
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType<Student>(201)]
        [ProducesResponseType(415)] //response meaning that the expected input was not satisfied
        [ProducesResponseType(404)] //response meaning that the expected input was not satisfied
        public IActionResult Put(int id, Student student)
        {
            try
            {
                Student model = _list.Where(st => st.Student_Id == id).SingleOrDefault();
                if (model is null) throw new ArgumentException(nameof(id));
                if (student.Last_Name == "string" || student.First_Name == "string") throw new ArgumentException(nameof(student));
                model.First_Name = student.First_Name;
                model.Last_Name = student.Last_Name;
                return CreatedAtAction(nameof(Get), new { id }, model);
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound();
            }
            catch (ArgumentException)
            {
                return StatusCode(415);
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(204)] // yes done but can't show anything (b/c its gone)
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            try
            {
                Student model = _list.Where(st => st.Student_Id == id).SingleOrDefault(); //later this will be studentService.Delete blah blah
                if (model is null) throw new ArgumentOutOfRangeException(nameof(id));
                _list.Remove(model);
                return NoContent();
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound();
            }
        }




    }
}
