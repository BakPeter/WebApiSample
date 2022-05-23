using Microsoft.AspNetCore.Mvc;
using WebApiSample.Model;

namespace WebApiSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly List<Person> Persons = new() {
            new Person { Id=0, LastName="cohen", FirstName="eli", Age=30, IsMale=true},
            new Person { Id=1, LastName="levi", FirstName="eshkol", Age=80, IsMale=true},
            new Person { Id=2, LastName="Meir", FirstName="Golda", Age=20, IsMale=false}
        };

        [HttpGet]
        public List<Person> GetPersons()
        {
            return Persons;
        }

        [HttpGet]
        [Route("{id}")]
        public Person? GetPerson([FromRoute] int id)
        {
            Person? response = null;

            foreach (var person in Persons)
            {
                if (person.Id == id)
                    response = person;
            }

            return response;
        }


        [HttpPost]
        public int CreatePerson([FromBody] CreatePersonReqDTO dto)
        {
            var id = Persons.Count;
            var person = new Person
            {
                Id = id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Age = dto.Age,
                IsMale = dto.IsMale
            };

            Persons.Add(person);

            return id;
        }

        [HttpPut]
        public bool UpdatePerson([FromQuery] int id,  [FromBody] UpdatePersonReqDTO dto)
        {
            return true;
        }

    }
}
