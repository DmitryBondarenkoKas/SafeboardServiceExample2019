using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web.API.Core;
using Web.API.Models;

namespace Web.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<Book>), 200)]
        [ProducesResponseType(400)]
        public IActionResult GetBooks()
        {
            try
            {
                return Ok(BooksKeeper.Instance.GetBooks());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(Book), 200)]
        [ProducesResponseType(400)]
        public IActionResult GetBook(int id)
        {
            try
            {
                return Ok(BooksKeeper.Instance.GetBook(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult AddBook([FromBody] Book book)
        {
            try
            {
                BooksKeeper.Instance.AddBook(book);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Delete(int id)
        {
            try
            {
                BooksKeeper.Instance.DeleteBook(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
