using Microsoft.AspNetCore.Mvc;
using BC = BCrypt.Net.BCrypt;
using ManagementSystemAPI.DataAccess;
using System;
using System.Collections.Generic;
using ManagementSystemAPI.Models;
using static ManagementSystemAPI.Common.Constant;
using ManagementSystemAPI.Helpers;
using Microsoft.AspNetCore.Cors;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly IUsersProvider _userAccessProvider;
        private readonly IDistributorsProvider _distributorAccessProvider;
        private readonly IManufacturesProvider _manufacturesAccessProvider;
        private readonly IMedstoresProvider _medstoresAccessProvider;

        public UsersController(IUsersProvider dataAccessProvider, IDistributorsProvider distributorsProvider, IManufacturesProvider manufacturesProvider, IMedstoresProvider medstoresProvider)
        {
            _userAccessProvider = dataAccessProvider;
            _distributorAccessProvider = distributorsProvider;
            _manufacturesAccessProvider = manufacturesProvider;
            _medstoresAccessProvider = medstoresProvider;
        }

        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return _userAccessProvider.GetUsersRecords();
        }

        [EnableCors("Signup")]
        [HttpPost]
        public IActionResult Create([FromBody] UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {

                int userID = _userAccessProvider.AddUsersRecord(new Users { 
                    username = userDetails.username,
                    password = userDetails.password,
                    detail_type = userDetails.detail_type,
                    email = userDetails.email,
                    is_active = true
                });

                if(userDetails.detail_type== "distributors")
                {
                    
                    _distributorAccessProvider.AddDistributorsRecord(new Distributors { 
                        distributors_lisence = userDetails.lisence,
                        distributors_name = userDetails.name,
                        distributors_number = userDetails.number,
                        users_id = userID
                    });
                }
                if (userDetails.detail_type.Equals(DetailType.manufactures.ToString()))
                {

                    _manufacturesAccessProvider.AddManufacturesRecord(new Manufactures
                    {
                        manufactures_lisence = userDetails.lisence,
                        manufactures_name = userDetails.name,
                        manufactures_address = userDetails.address,
                        distributors_id = 1,
                        users_id = userID
                    });
                }
                if (userDetails.detail_type.Equals(DetailType.medstores.ToString()))
                {

                    _medstoresAccessProvider.AddMedstoresRecord(new Medstores
                    {
                        medstores_lisence = userDetails.lisence,
                        medstores_name = userDetails.name,
                        medstores_address = userDetails.address,
                        medstores_number = userDetails.number,
                        users_id = userID
                    });
                }
                return Ok();
            }
            return BadRequest();
        }

        [EnableCors("Login")]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] Users users)
            {
            if (ModelState.IsValid)
            {
                var response = _userAccessProvider.Authenticate(users);
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public Users Details(int id)
        {
            return _userAccessProvider.GetUsersSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Users users)
        {
            if (ModelState.IsValid)
            {
                _userAccessProvider.UpdateUsersRecord(users);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = _userAccessProvider.GetUsersSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _userAccessProvider.DeleteUsersRecord(id);
            return Ok();
        }
        [Authorize]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var users = _userAccessProvider.GetAll();
            return Ok(users);
        }

    }
}
